using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EpoxyInventoryManager
{
    enum MODE: byte
    {
        _None = 0,
        _Add,
        _Change
    }

    public partial class EpoxyInventoryManagerSMD1Form : Form
    {
        string localPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));
        string materialDataPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\MaterialDB.accdb"));

        string ftpPath = "ftp://10.141.12.165/Material/SMD_FR-D01/";
        string user = "K5FC";
        string pwd = "K5fc123!";

        FTPclient ftpClient;

        public byte iMode;   

        #region imm32.dll :: Get_IME_Mode IME가져오기
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll")]
        public static extern Boolean ImmSetConversionStatus(IntPtr hIMC, Int32 fdwConversion, Int32 fdwSentence);
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr IParam);

        public const int IME_CMODE_ALPHANUMERIC = 0x0;  //영문
        public const int IME_CMODE_NATIVE = 0x1;        //한글
        #endregion      

        public EpoxyInventoryManagerSMD1Form()
        {
            InitializeComponent();
        }

        private void EpoxyInventoryManagerForm_Load(object sender, EventArgs e)
        {
            Width = 1265;
            Height = 930;
            Top = 0;
            Left = 0;

            // 키보드 영문 전환
            ChangeIME();

            ftpClient = new FTPclient(ftpPath, user, pwd);

            _button_enabled(true, true, true, false, false);
            _textBox_enabled(false, false, false, false, false, false, false);

            iMode = (byte)MODE._None;

            displayTimer.Enabled = true;
        }

        private void EpoxyInventoryManagerForm_Activated(object sender, EventArgs e)
        {
            // DataGridView 버벅임 방지.
            SetDoubleBuffered(dataGridEpoxyInventory);

            SetDoubleBuffered(listBoxHistory);
        }

        private void EpoxyInventoryManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            displayTimer.Enabled = false;
        }

        private void ChangeIME()
        {
            IntPtr hwnd = ImmGetContext(this.Handle);
            Int32 dwConversion = 0;
            dwConversion = IME_CMODE_ALPHANUMERIC;
            ImmSetConversionStatus(hwnd, dwConversion, 0);
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            listBoxHistory.SelectedIndex = listBoxHistory.Items.Count - 1;
            listBoxHistory.SelectedIndex = -1;
        }

        private void btnInquire_Click(object sender, EventArgs e)
        {            
            string fileName = "epoxystock.fdb";

            if (File.Exists(localPath + fileName))
            {
                File.Delete(localPath + fileName);
            }

            // 재고 현황 파일 업로드 요청
            if (_ftpFileUpload("Request.txt"))
            {
                _listBox_Log_Clear();

                listBoxHistory.Items.Add(string.Format("[{0}] Client → 재고 현황 파일 업로드(조회) 요청", DateTime.Now.ToString()));

                requestTimer.Enabled = true;                
            }
        }

        private void requestTimer_Tick(object sender, EventArgs e)
        {
            if (ftpClient.FtpFileExists("RequestComplete.txt"))
            {
                _listBox_Log_Clear();

                listBoxHistory.Items.Add(string.Format("[{0}] Host → 재고 현황 파일 업로드 완료", DateTime.Now.ToString()));

                // 재고 현황 파일 다운로드
                if (_ftpFileDownload("epoxystock.fdb"))
                {
                    listBoxHistory.Items.Add(string.Format("[{0}] Client → 재고 현황 파일 다운로드 완료", DateTime.Now.ToString()));                    

                    ftpClient.FtpDelete("RequestComplete.txt");

                    ftpClient.FtpDelete("epoxystock.fdb");

                    _data_parsing();

                    requestTimer.Enabled = false;

                    MessageBox.Show("재고 현황 파일을 다운로드 했습니다.", "알림");
                }                               
            }            
        }

        private void _data_parsing()
        {
            string connStr = materialDataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {
                    string sql = "CREATE TABLE Storage (_Date nvarchar(30), LotNo nvarchar(30), Volume nvarchar(10), MaxTime nvarchar(10), Q'ty nvarchar(10), SidNo nvarchar(30), ExpirationDate nvarchar(30))";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    StreamReader sr = new StreamReader(localPath + "epoxystock.fdb");
                    string zipStr;
                    long count = 0;

                    // 현재의 테이블 내용을 삭제
                    // 테이블에 주키가 없기 때문에 삭제하지 않으면 이 프로그램을 실행 할 때마다                
                    // 같은 데이터가 추가되기 때문이다               
                    cmd.CommandText = "DELETE FROM Storage";
                    cmd.ExecuteNonQuery();

                    // 비어 있는 DB 테이블에 텍스트 파일의 모든 내용을                 
                    // 테이블에 추가                
                    while (!sr.EndOfStream)
                    {
                        // 텍스트 파일에서 한 줄의 내용을 읽기                    
                        zipStr = sr.ReadLine();
                        if (zipStr == "")
                            break;

                        // tab키를 구분자로 사용하여 문자열을 여러개의 작은 문자열로 분리                    
                        string[] words = zipStr.Split('\t');
                        sql = "INSERT INTO Storage VALUES('" + words[0] + "' , '" + words[1] + "' , '" + words[2] + "' , '" + words[3] + "' , " +
                                                "'" + words[4] + "' , '" + words[5] + "' , '" + words[6] + "')";

                        // 명령객체의 CommandText에 쿼리 문자열을 대입                    
                        cmd.CommandText = sql;
                        // 쿼리를 실행                    
                        cmd.ExecuteNonQuery();
                        count++;
                    }

                    // 텍스트 파일 닫기                
                    sr.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "알림");
                    return;
                }
                finally
                {
                    // DB 연결 끊기                
                    conn.Close();
                }

                DataUpdate();
            }
        }

        private void DataUpdate()
        {
            try
            {
                // TODO: 이 코드는 데이터를 'materialDBDataSet.Storage' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
                this.storageTableAdapter.Fill(this.materialDBDataSet.Storage);

                // Fill 전달 전에 DataSet객체 생성
                DataSet ds = new DataSet();

                // DataAdapter는 자동으로 Connection을 핸들링함. conn.Open() 불필요.                
                string connStr = materialDataPath;
                OleDbConnection conn = new OleDbConnection(connStr);

                string sql = "SELECT * FROM Storage";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                adp.Fill(ds);

                // 가져온 데이타를 DataGridView 컨트롤에 바인딩.
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dataGridEpoxyInventory.DataSource = ds.Tables[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "알림");                
            }
        }        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Data table의 내용을 epoxystock.fdb로 저장            
            if (_file_save())
            {
                // 재고 현황 파일 ftp서버에 업로드 (업데이트)
                if (_ftpFileUpload("epoxystock.fdb"))
                {
                    // 재고 현황 파일 업로드 완료
                    if (_ftpFileUpload("Update.txt"))
                    {
                        _listBox_Log_Clear();

                        listBoxHistory.Items.Add(string.Format("[{0}] Client → 재고 현황 파일 업로드(업데이트) 완료", DateTime.Now.ToString()));
                        MessageBox.Show("재고 현황 파일을 업데이트 했습니다.", "알림");

                        uploadTimer.Enabled = true;
                    }
                }
            }            
        }

        private bool _file_save()
        {
            TextWriter writer = new StreamWriter(localPath + "epoxystock.fdb");
            for (int i = 0; i < dataGridEpoxyInventory.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridEpoxyInventory.Columns.Count; j++)
                {
                    writer.Write(dataGridEpoxyInventory.Rows[i].Cells[j].Value.ToString() + "\t");
                }
                writer.WriteLine("");
            }
            writer.Close();

            return true;
        }

        private void uploadTimer_Tick(object sender, EventArgs e)
        {
            if (ftpClient.FtpFileExists("UpdateComplete.txt"))
            {
                _listBox_Log_Clear();

                listBoxHistory.Items.Add(string.Format("[{0}] Host → 재고 현황 파일 다운로드(업데이트) 완료", DateTime.Now.ToString()));

                ftpClient.FtpDelete("UpdateComplete.txt");

                uploadTimer.Enabled = false;
            }
        }

        private bool _ftpFileUpload(string fileName)
        {
            if (ftpClient.Upload(localPath + fileName, fileName))
                return true;
            else
                return false;
        }

        private bool _ftpFileDownload(string fileName)
        {
            if (ftpClient.Download(fileName, localPath + fileName, true))
                return true;
            else
                return false;
        }       
        
        private void _listBox_Log_Clear()
        {
            if (listBoxHistory.Items.Count > 100)
                listBoxHistory.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ActiveControl = textBoxBarcodeData;
            textBoxBarcodeData.Focus();

            _button_enabled(false, false, false, true, true);
            _textBox_enabled(true, true, true, true, true, true, true);

            iMode = (byte)MODE._Add;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            _button_enabled(false, false, false, true, true);
            _textBox_enabled(true, true, true, true, true, true, true);

            iMode = (byte)MODE._Change;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = materialDataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {
                    string sql = "CREATE TABLE Storage (_Date nvarchar(30), LotNo nvarchar(30), Volume nvarchar(10), MaxTime nvarchar(10), Q'ty nvarchar(10), SidNo nvarchar(30), ExpirationDate nvarchar(30))";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    string strDate = textBoxDate.Text.ToString();
                    string strLotNo = textBoxLotNo.Text.ToString();
                    string strVolume = textBoxVolume.Text.ToString();
                    string strMaxTime = textBoxMaxTime.Text.ToString();
                    string strQty = textBoxQty.Text.ToString();
                    string strSidNo = textBoxSidNo.Text.ToString();
                    string strExpDate = textBoxExpDate.Text.ToString();

                    if ((strDate != string.Empty) && (strDate != null))
                    {
                        if ((strLotNo != string.Empty) && (strLotNo != null))
                        {
                            if ((strVolume != string.Empty) && (strVolume != null))
                            {
                                if ((strMaxTime != string.Empty) && (strMaxTime != null))
                                {
                                    if ((strQty != string.Empty) && (strQty != null))
                                    {
                                        if ((strSidNo != string.Empty) && (strSidNo != null))
                                        {
                                            if ((strExpDate != string.Empty) && (strExpDate != null))
                                            {
                                                if (iMode == (byte)MODE._Add)
                                                {
                                                    sql = "INSERT INTO Storage VALUES('" + strDate + "' , '" + strLotNo + "' , '" + strVolume + "' , " +
                                                    "'" + strMaxTime + "' , '" + strQty + "' , '" + strSidNo + "' , '" + strExpDate + "')";

                                                    cmd.CommandText = sql;
                                                    cmd.ExecuteNonQuery();

                                                    MessageBox.Show("Material 추가를 완료했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    textBoxDate.Text = "";
                                                    textBoxLotNo.Text = "";
                                                    textBoxVolume.Text = "";                                                    
                                                    textBoxMaxTime.Text = "";
                                                    textBoxQty.Text = "";
                                                    textBoxSidNo.Text = "";
                                                    textBoxExpDate.Text = "";
                                                }
                                                else if (iMode == (byte)MODE._Change)
                                                {
                                                    sql = "UPDATE Storage SET [_Date] = @Date, [LotNo] = @LotNo, [Volume] = @Volume, [MaxTime] = @MaxTime, " +
                                                        "[Q'ty] = @Qty, [SidNo] = @SidNo, [ExpirationDate] = @ExpDate WHERE [LotNo] = '" + textBoxLotNo.Text.ToString() + "' and [SidNo] = '" + textBoxSidNo.Text.ToString() + "'";

                                                    cmd.Parameters.AddWithValue("@Date", textBoxDate.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@LotNo", textBoxLotNo.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@Volume", textBoxVolume.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@MaxTime", textBoxMaxTime.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@Qty", textBoxQty.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@SidNo", textBoxSidNo.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@ExpDate", textBoxExpDate.Text.ToString());

                                                    cmd.CommandText = sql;
                                                    cmd.ExecuteNonQuery();

                                                    MessageBox.Show("Material 수정을 완료했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    textBoxDate.Text = "";
                                                    textBoxLotNo.Text = "";
                                                    textBoxVolume.Text = "";                                                    
                                                    textBoxMaxTime.Text = "";
                                                    textBoxQty.Text = "";
                                                    textBoxSidNo.Text = "";
                                                    textBoxExpDate.Text = "";
                                                }                                                
                                            }
                                            else
                                            {
                                                MessageBox.Show("유효기간을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sid 번호를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("수량을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Max Time을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("용량을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lot 번호를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("날짜를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "알림");
                    return;
                }
                finally
                {
                    conn.Close();
                }

                DataUpdate();

                _button_enabled(true, true, true, false, false);
                _textBox_enabled(false, false, false, false, false, false, false);

                iMode = (byte)MODE._None;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((textBoxDate.Text == "") || (textBoxDate.Text == null) ||
                (textBoxLotNo.Text == "") || (textBoxLotNo.Text == null) ||
                (textBoxVolume.Text == "") || (textBoxVolume.Text == null) ||
                (textBoxMaxTime.Text == "") || (textBoxMaxTime.Text == null) ||
                (textBoxQty.Text == "") || (textBoxQty.Text == null) ||
                (textBoxSidNo.Text == "") || (textBoxSidNo.Text == null) ||
                (textBoxExpDate.Text == "") || (textBoxExpDate.Text == null))
            {
                MessageBox.Show("삭제 할 Material을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Material을 삭제 하겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string connStr = materialDataPath;
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();

                    try
                    {
                        string sql = "DELETE FROM Storage WHERE [_Date] = '" + textBoxDate.Text.ToString() + "' and [LotNo] = '" + textBoxLotNo.Text.ToString() +
                            "' and [Volume] = '" + textBoxVolume.Text.ToString() + "' and [MaxTime] = '" + textBoxMaxTime.Text.ToString() + "' and [Q'ty] = '" + textBoxQty.Text.ToString() + 
                            "' and [SidNo] = '" + textBoxSidNo.Text.ToString() + "' and [ExpirationDate] = '" + textBoxExpDate.Text.ToString() + "'";
                        
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();                        

                        MessageBox.Show("Material 삭제를 완료했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "알림");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }

                    textBoxDate.Text = "";
                    textBoxLotNo.Text = "";
                    textBoxVolume.Text = "";
                    textBoxMaxTime.Text = "";
                    textBoxQty.Text = "";
                    textBoxSidNo.Text = "";
                    textBoxExpDate.Text = "";

                    DataUpdate();                                        
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _button_enabled(true, true, true, false, false);
            _textBox_enabled(false, false, false, false, false, false, false);

            iMode = (byte)MODE._None;
        }

        private void dataGridEpoxyInventory_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridEpoxyInventory.CurrentCell != null)
                {
                    if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 0)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 4, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 5, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 6, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 1)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 4, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 5, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 2)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 4, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 3)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 4)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 5)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 4, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex + 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridEpoxyInventory.CurrentCell.ColumnIndex == 6)
                    {
                        textBoxDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxLotNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 5, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxVolume.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 4, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxMaxTime.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 3, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxQty.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 2, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxSidNo.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex - 1, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                        textBoxExpDate.Text = dataGridEpoxyInventory[dataGridEpoxyInventory.CurrentCell.ColumnIndex, dataGridEpoxyInventory.CurrentRow.Index].Value.ToString();
                    }
                }                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                //
            }
        }

        private void dataGridEpoxyInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString("000");
            }
        }   
        
        private void _button_enabled(bool bAdd, bool bDel, bool bChange, bool bSave, bool bCancel)
        {
            btnAdd.Enabled = bAdd;
            btnDelete.Enabled = bDel;
            btnChange.Enabled = bChange;
            btnSave.Enabled = bSave;
            btnCancel.Enabled = bCancel;
        }

        private void _textBox_enabled(bool bDate, bool bLot, bool bVol, bool bMaxTime, bool bQty, bool bSid, bool bExpDate)
        {
            textBoxDate.Enabled = bDate;
            textBoxLotNo.Enabled = bLot;
            textBoxVolume.Enabled = bVol;
            textBoxMaxTime.Enabled = bMaxTime;
            textBoxQty.Enabled = bQty;
            textBoxSidNo.Enabled = bSid;
            textBoxExpDate.Enabled = bExpDate;
        }        
    }
}
