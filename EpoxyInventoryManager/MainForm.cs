using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EpoxyInventoryManager
{
    public enum Page
    {
        SMD1Page = 0,
        SMD2Page,
        SMD3Page,
        UF1Page,
        UF2Page,
        LID1Page,
        LID2Page
    }

    public partial class MainForm : Form
    {
        string localFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));

        EpoxyInventoryManagerSMD1Form m_epoxyInventoryManagerSMD1Form;
        EpoxyInventoryManagerSMD2Form m_epoxyInventoryManagerSMD2Form;
        EpoxyInventoryManagerSMD3Form m_epoxyInventoryManagerSMD3Form;

        EpoxyInventoryManagerUF1Form m_epoxyInventoryManagerUF1Form;
        EpoxyInventoryManagerUF2Form m_epoxyInventoryManagerUF2Form;
        EpoxyInventoryManagerLID1Form m_epoxyInventoryManagerLID1Form;
        EpoxyInventoryManagerLID2Form m_epoxyInventoryManagerLID2Form;

        public MainForm()
        {
            InitializeComponent();

            SubFormCreate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (INFO_LOAD() == "SMD")
            {
                SubFormShow((byte)Page.SMD1Page);

                F_ButtonVisible(true, true, true, false, false, false, false);
                F_ButtonEnabled_SMD(false, true, true);
            }
            else if (INFO_LOAD() == "FCBGA")
            {
                SubFormShow((byte)Page.UF1Page);

                F_ButtonVisible(false, false, false, true, true, true, true);
                F_ButtonEnabled_FCBGA(false, true, true, true);
            }
            
            F_FILE_INIT();
        }

        private void SubFormCreate()
        {
            m_epoxyInventoryManagerSMD1Form = new EpoxyInventoryManagerSMD1Form();
            m_epoxyInventoryManagerSMD1Form.MdiParent = this;
            m_epoxyInventoryManagerSMD1Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerSMD1Form.Show();

            m_epoxyInventoryManagerSMD2Form = new EpoxyInventoryManagerSMD2Form();
            m_epoxyInventoryManagerSMD2Form.MdiParent = this;
            m_epoxyInventoryManagerSMD2Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerSMD2Form.Show();

            m_epoxyInventoryManagerSMD3Form = new EpoxyInventoryManagerSMD3Form();
            m_epoxyInventoryManagerSMD3Form.MdiParent = this;
            m_epoxyInventoryManagerSMD3Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerSMD3Form.Show();

            m_epoxyInventoryManagerUF1Form = new EpoxyInventoryManagerUF1Form();
            m_epoxyInventoryManagerUF1Form.MdiParent = this;
            m_epoxyInventoryManagerUF1Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerUF1Form.Show();

            m_epoxyInventoryManagerUF2Form = new EpoxyInventoryManagerUF2Form();
            m_epoxyInventoryManagerUF2Form.MdiParent = this;
            m_epoxyInventoryManagerUF2Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerUF2Form.Show();

            m_epoxyInventoryManagerLID1Form = new EpoxyInventoryManagerLID1Form();
            m_epoxyInventoryManagerLID1Form.MdiParent = this;
            m_epoxyInventoryManagerLID1Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerLID1Form.Show();

            m_epoxyInventoryManagerLID2Form = new EpoxyInventoryManagerLID2Form();
            m_epoxyInventoryManagerLID2Form.MdiParent = this;
            m_epoxyInventoryManagerLID2Form.Dock = DockStyle.Fill;
            m_epoxyInventoryManagerLID2Form.Show();
        }

        private void SubFormShow(byte PageNum)
        {
            try
            {
                switch (PageNum)
                {
                    case (byte)Page.SMD1Page:
                        {
                            m_epoxyInventoryManagerSMD1Form.Activate();
                            m_epoxyInventoryManagerSMD1Form.BringToFront();

                            F_ButtonEnabled_SMD(false, true, true);
                        }
                        break;

                    case (byte)Page.SMD2Page:
                        {
                            m_epoxyInventoryManagerSMD2Form.Activate();
                            m_epoxyInventoryManagerSMD2Form.BringToFront();

                            F_ButtonEnabled_SMD(true, false, true);
                        }
                        break;

                    case (byte)Page.SMD3Page:
                        {
                            m_epoxyInventoryManagerSMD3Form.Activate();
                            m_epoxyInventoryManagerSMD3Form.BringToFront();

                            F_ButtonEnabled_SMD(true, true, false);
                        }
                        break;

                    case (byte)Page.UF1Page:
                        {
                            m_epoxyInventoryManagerUF1Form.Activate();
                            m_epoxyInventoryManagerUF1Form.BringToFront();

                            F_ButtonEnabled_FCBGA(false, true, true, true);
                        }
                        break;

                    case (byte)Page.UF2Page:
                        {
                            m_epoxyInventoryManagerUF2Form.Activate();
                            m_epoxyInventoryManagerUF2Form.BringToFront();

                            F_ButtonEnabled_FCBGA(true, false, true, true);
                        }
                        break;

                    case (byte)Page.LID1Page:
                        {
                            m_epoxyInventoryManagerLID1Form.Activate();
                            m_epoxyInventoryManagerLID1Form.BringToFront();

                            F_ButtonEnabled_FCBGA(true, true, false, true);
                        }
                        break;

                    case (byte)Page.LID2Page:
                        {
                            m_epoxyInventoryManagerLID2Form.Activate();
                            m_epoxyInventoryManagerLID2Form.BringToFront();

                            F_ButtonEnabled_FCBGA(true, true, true, false);
                        }
                        break;
                }
            }
            catch
            {
                MessageBox.Show("폼 양식을 가져오는 도중 오류가 발생했습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string INFO_LOAD()
        {            
            string sTmpData = string.Empty;
            string FileName = "LineInfo.txt";

            if (File.Exists(localFilePath + FileName))
            {
                byte[] bytes;
                using (var fs = File.Open(localFilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    sTmpData = Encoding.Default.GetString(bytes);                    
                }

                return sTmpData;
            }
            else
            {
                return sTmpData;
            }
        }

        private void F_ButtonVisible(bool bSMD1Btn, bool bSMD2Btn, bool bSMD3Btn, bool bUF1Btn, bool bUF2Btn, bool bLID1Btn, bool bLID2Btn)
        {
            btnSMD_1.Visible = bSMD1Btn;
            btnSMD_2.Visible = bSMD2Btn;
            btnSMD_3.Visible = bSMD3Btn;

            btnUF_1.Visible = bUF1Btn;
            btnUF_2.Visible = bUF2Btn;
            btnLID_1.Visible = bLID1Btn;
            btnLID_2.Visible = bLID2Btn;
        }

        private void F_ButtonEnabled_SMD(bool bSMD1Btn, bool bSMD2Btn, bool bSMD3Btn)
        {
            btnSMD_1.Enabled = bSMD1Btn;
            btnSMD_2.Enabled = bSMD2Btn;
            btnSMD_3.Enabled = bSMD3Btn;            
        }

        private void F_ButtonEnabled_FCBGA(bool bUF1Btn, bool bUF2Btn, bool bLID1Btn, bool bLID2Btn)
        {
            btnUF_1.Enabled = bUF1Btn;
            btnUF_2.Enabled = bUF2Btn;
            btnLID_1.Enabled = bLID1Btn;
            btnLID_2.Enabled = bLID2Btn;
        }

        private void F_FILE_INIT()
        {
            string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));
            string fileName = "epoxystock.fdb";

            if (File.Exists(filePath + fileName))
            {
                File.Delete(filePath + fileName);
            }
        }

        private void btnSMD_1_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerSMD2Form.iMode != (byte)MODE._None) || 
                (m_epoxyInventoryManagerSMD3Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.SMD1Page);
            }            
        }

        private void btnSMD_2_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerSMD1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerSMD3Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.SMD2Page);
            }
        }

        private void btnSMD_3_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerSMD1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerSMD2Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.SMD3Page);
            }
        }

        private void btnUF_1_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerUF2Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID2Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.UF1Page);
            }
        }

        private void btnUF_2_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerUF1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID2Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.UF2Page);
            }
        }

        private void btnLID_1_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerUF1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerUF2Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID2Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.LID1Page);
            }
        }

        private void btnLID_2_Click(object sender, EventArgs e)
        {
            if ((m_epoxyInventoryManagerUF1Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerUF2Form.iMode != (byte)MODE._None) ||
                (m_epoxyInventoryManagerLID1Form.iMode != (byte)MODE._None))
            {
                MessageBox.Show("Material 정보를 편집 중입니다", "알림");
            }
            else
            {
                SubFormShow((byte)Page.LID2Page);
            }
        }
    }
}
