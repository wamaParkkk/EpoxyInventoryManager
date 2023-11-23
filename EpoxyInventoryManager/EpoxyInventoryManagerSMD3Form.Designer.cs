
namespace EpoxyInventoryManager
{
    partial class EpoxyInventoryManagerSMD3Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpoxyInventoryManagerSMD3Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInquire = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.requestTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uploadTimer = new System.Windows.Forms.Timer(this.components);
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridEpoxyInventory = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sidNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialDBDataSet = new EpoxyInventoryManager.MaterialDBDataSet();
            this.storageTableAdapter = new EpoxyInventoryManager.MaterialDBDataSetTableAdapters.StorageTableAdapter();
            this.textBoxSidNo = new System.Windows.Forms.TextBox();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.textBoxMaxTime = new System.Windows.Forms.TextBox();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxLotNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxExpDate = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxBarcodeData = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEpoxyInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInquire
            // 
            this.btnInquire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInquire.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInquire.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInquire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInquire.ImageIndex = 0;
            this.btnInquire.ImageList = this.imageList;
            this.btnInquire.Location = new System.Drawing.Point(465, 88);
            this.btnInquire.Name = "btnInquire";
            this.btnInquire.Size = new System.Drawing.Size(225, 63);
            this.btnInquire.TabIndex = 0;
            this.btnInquire.Text = "       재고 현황 조회";
            this.btnInquire.UseVisualStyleBackColor = true;
            this.btnInquire.Click += new System.EventHandler(this.btnInquire_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Download.png");
            this.imageList.Images.SetKeyName(1, "Upload.png");
            this.imageList.Images.SetKeyName(2, "Add.png");
            this.imageList.Images.SetKeyName(3, "Cancel.png");
            this.imageList.Images.SetKeyName(4, "Delete.png");
            this.imageList.Images.SetKeyName(5, "Edit.png");
            this.imageList.Images.SetKeyName(6, "Save.png");
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.ImageKey = "Upload.png";
            this.btnUpdate.ImageList = this.imageList;
            this.btnUpdate.Location = new System.Drawing.Point(1028, 855);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(225, 63);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "         저장 및 업데이트";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.ItemHeight = 15;
            this.listBoxHistory.Location = new System.Drawing.Point(12, 12);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(444, 139);
            this.listBoxHistory.TabIndex = 2;
            // 
            // requestTimer
            // 
            this.requestTimer.Interval = 500;
            this.requestTimer.Tick += new System.EventHandler(this.requestTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(469, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "해동기 → PC (다운로드)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1042, 827);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "PC → 해동기 (업로드)";
            // 
            // uploadTimer
            // 
            this.uploadTimer.Interval = 500;
            this.uploadTimer.Tick += new System.EventHandler(this.uploadTimer_Tick);
            // 
            // displayTimer
            // 
            this.displayTimer.Interval = 500;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // dataGridEpoxyInventory
            // 
            this.dataGridEpoxyInventory.AllowUserToAddRows = false;
            this.dataGridEpoxyInventory.AllowUserToDeleteRows = false;
            this.dataGridEpoxyInventory.AllowUserToResizeColumns = false;
            this.dataGridEpoxyInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridEpoxyInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridEpoxyInventory.AutoGenerateColumns = false;
            this.dataGridEpoxyInventory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridEpoxyInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEpoxyInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridEpoxyInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEpoxyInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.lotNoDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.maxTimeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.sidNoDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn});
            this.dataGridEpoxyInventory.DataSource = this.storageBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridEpoxyInventory.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridEpoxyInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridEpoxyInventory.EnableHeadersVisualStyles = false;
            this.dataGridEpoxyInventory.Location = new System.Drawing.Point(12, 157);
            this.dataGridEpoxyInventory.Name = "dataGridEpoxyInventory";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEpoxyInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridEpoxyInventory.RowHeadersWidth = 60;
            this.dataGridEpoxyInventory.RowTemplate.Height = 23;
            this.dataGridEpoxyInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEpoxyInventory.Size = new System.Drawing.Size(1241, 575);
            this.dataGridEpoxyInventory.TabIndex = 5;
            this.dataGridEpoxyInventory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridEpoxyInventory_DataBindingComplete);
            this.dataGridEpoxyInventory.SelectionChanged += new System.EventHandler(this.dataGridEpoxyInventory_SelectionChanged);
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "_Date";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateDataGridViewTextBoxColumn.HeaderText = "_Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 150;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lotNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.Width = 200;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.Width = 150;
            // 
            // maxTimeDataGridViewTextBoxColumn
            // 
            this.maxTimeDataGridViewTextBoxColumn.DataPropertyName = "MaxTime";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maxTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.maxTimeDataGridViewTextBoxColumn.HeaderText = "MaxTime";
            this.maxTimeDataGridViewTextBoxColumn.Name = "maxTimeDataGridViewTextBoxColumn";
            this.maxTimeDataGridViewTextBoxColumn.Width = 150;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Q\'ty";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Q\'ty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 150;
            // 
            // sidNoDataGridViewTextBoxColumn
            // 
            this.sidNoDataGridViewTextBoxColumn.DataPropertyName = "SidNo";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sidNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.sidNoDataGridViewTextBoxColumn.HeaderText = "SidNo";
            this.sidNoDataGridViewTextBoxColumn.Name = "sidNoDataGridViewTextBoxColumn";
            this.sidNoDataGridViewTextBoxColumn.Width = 150;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.expirationDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataMember = "Storage";
            this.storageBindingSource.DataSource = this.materialDBDataSet;
            // 
            // materialDBDataSet
            // 
            this.materialDBDataSet.DataSetName = "MaterialDBDataSet";
            this.materialDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // storageTableAdapter
            // 
            this.storageTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxSidNo
            // 
            this.textBoxSidNo.BackColor = System.Drawing.Color.White;
            this.textBoxSidNo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSidNo.Location = new System.Drawing.Point(767, 790);
            this.textBoxSidNo.Name = "textBoxSidNo";
            this.textBoxSidNo.Size = new System.Drawing.Size(145, 23);
            this.textBoxSidNo.TabIndex = 43;
            // 
            // textBoxQty
            // 
            this.textBoxQty.BackColor = System.Drawing.Color.White;
            this.textBoxQty.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQty.Location = new System.Drawing.Point(616, 790);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(145, 23);
            this.textBoxQty.TabIndex = 42;
            // 
            // textBoxMaxTime
            // 
            this.textBoxMaxTime.BackColor = System.Drawing.Color.White;
            this.textBoxMaxTime.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxTime.Location = new System.Drawing.Point(465, 790);
            this.textBoxMaxTime.Name = "textBoxMaxTime";
            this.textBoxMaxTime.Size = new System.Drawing.Size(145, 23);
            this.textBoxMaxTime.TabIndex = 41;
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.BackColor = System.Drawing.Color.White;
            this.textBoxVolume.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVolume.Location = new System.Drawing.Point(314, 790);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(145, 23);
            this.textBoxVolume.TabIndex = 40;
            // 
            // textBoxDate
            // 
            this.textBoxDate.BackColor = System.Drawing.Color.White;
            this.textBoxDate.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDate.Location = new System.Drawing.Point(12, 790);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(145, 23);
            this.textBoxDate.TabIndex = 38;
            // 
            // textBoxLotNo
            // 
            this.textBoxLotNo.BackColor = System.Drawing.Color.White;
            this.textBoxLotNo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLotNo.Location = new System.Drawing.Point(163, 790);
            this.textBoxLotNo.Name = "textBoxLotNo";
            this.textBoxLotNo.Size = new System.Drawing.Size(145, 23);
            this.textBoxLotNo.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 772);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 772);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Lot No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(315, 772);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Volume (cc)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(466, 772);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Max Time (시간)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(617, 772);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Qty (수량)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(768, 772);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 49;
            this.label8.Text = "Sid No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(919, 772);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 51;
            this.label9.Text = "Exp. Date";
            // 
            // textBoxExpDate
            // 
            this.textBoxExpDate.BackColor = System.Drawing.Color.White;
            this.textBoxExpDate.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExpDate.Location = new System.Drawing.Point(918, 790);
            this.textBoxExpDate.Name = "textBoxExpDate";
            this.textBoxExpDate.Size = new System.Drawing.Size(145, 23);
            this.textBoxExpDate.TabIndex = 50;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageKey = "Add.png";
            this.btnAdd.ImageList = this.imageList;
            this.btnAdd.Location = new System.Drawing.Point(332, 855);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 63);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "        추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxBarcodeData
            // 
            this.textBoxBarcodeData.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBarcodeData.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBarcodeData.Location = new System.Drawing.Point(12, 738);
            this.textBoxBarcodeData.Name = "textBoxBarcodeData";
            this.textBoxBarcodeData.Size = new System.Drawing.Size(1241, 23);
            this.textBoxBarcodeData.TabIndex = 53;
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChange.ImageKey = "Edit.png";
            this.btnChange.ImageList = this.imageList;
            this.btnChange.Location = new System.Drawing.Point(463, 855);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(125, 63);
            this.btnChange.TabIndex = 54;
            this.btnChange.Text = "        수정";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageKey = "Delete.png";
            this.btnDelete.ImageList = this.imageList;
            this.btnDelete.Location = new System.Drawing.Point(594, 855);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 63);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "        삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageKey = "Cancel.png";
            this.btnCancel.ImageList = this.imageList;
            this.btnCancel.Location = new System.Drawing.Point(856, 855);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 63);
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "        취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageKey = "Save.png";
            this.btnSave.ImageList = this.imageList;
            this.btnSave.Location = new System.Drawing.Point(725, 855);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 63);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "        저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(1175, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 25);
            this.label10.TabIndex = 58;
            this.label10.Text = "FR-D03";
            // 
            // EpoxyInventoryManagerSMD3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1265, 930);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.textBoxBarcodeData);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxExpDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSidNo);
            this.Controls.Add(this.textBoxQty);
            this.Controls.Add(this.textBoxMaxTime);
            this.Controls.Add(this.textBoxVolume);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxLotNo);
            this.Controls.Add(this.dataGridEpoxyInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInquire);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EpoxyInventoryManagerSMD3Form";
            this.Text = "Epoxy Inventory Manager";
            this.Activated += new System.EventHandler(this.EpoxyInventoryManagerForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EpoxyInventoryManagerForm_FormClosing);
            this.Load += new System.EventHandler(this.EpoxyInventoryManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEpoxyInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInquire;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Timer requestTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer uploadTimer;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.DataGridView dataGridEpoxyInventory;
        private MaterialDBDataSet materialDBDataSet;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private MaterialDBDataSetTableAdapters.StorageTableAdapter storageTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBoxSidNo;
        private System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.TextBox textBoxMaxTime;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxExpDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxBarcodeData;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label10;
    }
}

