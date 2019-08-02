namespace LRBarcodeApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_unprintlist = new System.Windows.Forms.DataGridView();
            this.选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.txtcx = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_barcode = new System.Windows.Forms.Button();
            this.dgv_barcodelist = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_pri = new System.Windows.Forms.Button();
            this.dgv_brokenlist = new System.Windows.Forms.DataGridView();
            this.c2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_tm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.dgv_exismsglist = new System.Windows.Forms.DataGridView();
            this.c3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_p = new System.Windows.Forms.Button();
            this.dgv_sublist = new System.Windows.Forms.DataGridView();
            this.c4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_sub = new System.Windows.Forms.Button();
            this.txt_fbsl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_se = new System.Windows.Forms.Button();
            this.txt_xytm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_th = new System.Windows.Forms.Button();
            this.txt_chd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgv_relist = new System.Windows.Forms.DataGridView();
            this.c6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_thsl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_Shipmentslist = new System.Windows.Forms.DataGridView();
            this.c5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_sf = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_unprintlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barcodelist)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_brokenlist)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_exismsglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sublist)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_relist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipmentslist)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::LRBarcodeApplication.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1032, 90);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 90);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1032, 449);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.txtcx);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.btn_barcode);
            this.tabPage1.Controls.Add(this.dgv_barcodelist);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btn_print);
            this.tabPage1.Controls.Add(this.btn_refresh);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1024, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计划打印";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(233, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(291, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "可输入计划编号或客户名称或客户物料号进行查询";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_unprintlist);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 159);
            this.panel1.TabIndex = 11;
            // 
            // dgv_unprintlist
            // 
            this.dgv_unprintlist.AllowUserToAddRows = false;
            this.dgv_unprintlist.AllowUserToDeleteRows = false;
            this.dgv_unprintlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_unprintlist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_unprintlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_unprintlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.选择});
            this.dgv_unprintlist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_unprintlist.Location = new System.Drawing.Point(0, 0);
            this.dgv_unprintlist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_unprintlist.Name = "dgv_unprintlist";
            this.dgv_unprintlist.ReadOnly = true;
            this.dgv_unprintlist.RowTemplate.Height = 27;
            this.dgv_unprintlist.Size = new System.Drawing.Size(1028, 159);
            this.dgv_unprintlist.TabIndex = 0;
            this.dgv_unprintlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_unprintlist_CellClick);
            this.dgv_unprintlist.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_unprintlist_CellEndEdit);
            this.dgv_unprintlist.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_unprintlist_CellEnter);
            this.dgv_unprintlist.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_unprintlist_CellMouseDown);
            this.dgv_unprintlist.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_unprintlist_DataError);
            this.dgv_unprintlist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_unprintlist_RowPostPaint);
            // 
            // 选择
            // 
            this.选择.HeaderText = "";
            this.选择.Name = "选择";
            this.选择.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(459, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 31);
            this.button3.TabIndex = 10;
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtcx
            // 
            this.txtcx.Location = new System.Drawing.Point(313, 24);
            this.txtcx.Name = "txtcx";
            this.txtcx.Size = new System.Drawing.Size(139, 21);
            this.txtcx.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(218, 29);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "历史单据查询：";
            // 
            // btn_barcode
            // 
            this.btn_barcode.Location = new System.Drawing.Point(344, 222);
            this.btn_barcode.Margin = new System.Windows.Forms.Padding(2);
            this.btn_barcode.Name = "btn_barcode";
            this.btn_barcode.Size = new System.Drawing.Size(68, 34);
            this.btn_barcode.TabIndex = 6;
            this.btn_barcode.Text = "生成清单";
            this.btn_barcode.UseVisualStyleBackColor = true;
            this.btn_barcode.Click += new System.EventHandler(this.btn_barcode_Click);
            // 
            // dgv_barcodelist
            // 
            this.dgv_barcodelist.AllowUserToAddRows = false;
            this.dgv_barcodelist.AllowUserToDeleteRows = false;
            this.dgv_barcodelist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_barcodelist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_barcodelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_barcodelist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1});
            this.dgv_barcodelist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_barcodelist.Location = new System.Drawing.Point(2, 265);
            this.dgv_barcodelist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_barcodelist.Name = "dgv_barcodelist";
            this.dgv_barcodelist.ReadOnly = true;
            this.dgv_barcodelist.RowTemplate.Height = 27;
            this.dgv_barcodelist.Size = new System.Drawing.Size(1020, 149);
            this.dgv_barcodelist.TabIndex = 5;
            this.dgv_barcodelist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_barcodelist_CellClick);
            this.dgv_barcodelist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_barcodelist_RowPostPaint);
            // 
            // c1
            // 
            this.c1.HeaderText = "";
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "条码清单";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(417, 222);
            this.btn_print.Margin = new System.Windows.Forms.Padding(2);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(68, 34);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(547, 20);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(64, 30);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "未打印计划清单";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btn_pri);
            this.tabPage2.Controls.Add(this.dgv_brokenlist);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txt_tm);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1024, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " 补  打 ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(231, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(330, 12);
            this.label16.TabIndex = 13;
            this.label16.Text = "可输入条码或计划编号或客户名称或客户物料号进行查询";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(216, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(365, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "注意！条码补打需特别谨慎，否则会造成重码！";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "条码包含信息";
            // 
            // btn_pri
            // 
            this.btn_pri.Location = new System.Drawing.Point(579, 78);
            this.btn_pri.Name = "btn_pri";
            this.btn_pri.Size = new System.Drawing.Size(75, 23);
            this.btn_pri.TabIndex = 4;
            this.btn_pri.Text = "打印";
            this.btn_pri.UseVisualStyleBackColor = true;
            this.btn_pri.Click += new System.EventHandler(this.btn_pri_Click);
            // 
            // dgv_brokenlist
            // 
            this.dgv_brokenlist.AllowUserToAddRows = false;
            this.dgv_brokenlist.AllowUserToDeleteRows = false;
            this.dgv_brokenlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_brokenlist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_brokenlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_brokenlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c2});
            this.dgv_brokenlist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_brokenlist.Location = new System.Drawing.Point(2, 152);
            this.dgv_brokenlist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_brokenlist.Name = "dgv_brokenlist";
            this.dgv_brokenlist.ReadOnly = true;
            this.dgv_brokenlist.RowTemplate.Height = 27;
            this.dgv_brokenlist.Size = new System.Drawing.Size(1020, 262);
            this.dgv_brokenlist.TabIndex = 3;
            this.dgv_brokenlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_brokenlist_CellClick);
            this.dgv_brokenlist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_brokenlist_RowPostPaint);
            // 
            // c2
            // 
            this.c2.HeaderText = "";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_tm
            // 
            this.txt_tm.Location = new System.Drawing.Point(270, 78);
            this.txt_tm.Name = "txt_tm";
            this.txt_tm.Size = new System.Drawing.Size(187, 21);
            this.txt_tm.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "请输入破损的条码：";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.dgv_exismsglist);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btn_p);
            this.tabPage3.Controls.Add(this.dgv_sublist);
            this.tabPage3.Controls.Add(this.btn_sub);
            this.tabPage3.Controls.Add(this.txt_fbsl);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btn_se);
            this.tabPage3.Controls.Add(this.txt_xytm);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1024, 416);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "分包打印";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(164, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(330, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "可输入条码或计划编号或客户名称或客户物料号进行查询";
            // 
            // dgv_exismsglist
            // 
            this.dgv_exismsglist.AllowUserToAddRows = false;
            this.dgv_exismsglist.AllowUserToDeleteRows = false;
            this.dgv_exismsglist.AllowUserToOrderColumns = true;
            this.dgv_exismsglist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_exismsglist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_exismsglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_exismsglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c3});
            this.dgv_exismsglist.Location = new System.Drawing.Point(2, 67);
            this.dgv_exismsglist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_exismsglist.Name = "dgv_exismsglist";
            this.dgv_exismsglist.ReadOnly = true;
            this.dgv_exismsglist.RowTemplate.Height = 27;
            this.dgv_exismsglist.Size = new System.Drawing.Size(1018, 139);
            this.dgv_exismsglist.TabIndex = 4;
            this.dgv_exismsglist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_exismsglist_CellClick);
            this.dgv_exismsglist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_exismsglist_RowPostPaint);
            // 
            // c3
            // 
            this.c3.HeaderText = "";
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "分包后的信息";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "条码现有信息";
            // 
            // btn_p
            // 
            this.btn_p.Location = new System.Drawing.Point(555, 217);
            this.btn_p.Name = "btn_p";
            this.btn_p.Size = new System.Drawing.Size(75, 23);
            this.btn_p.TabIndex = 9;
            this.btn_p.Text = "打印";
            this.btn_p.UseVisualStyleBackColor = true;
            this.btn_p.Click += new System.EventHandler(this.btn_p_Click);
            // 
            // dgv_sublist
            // 
            this.dgv_sublist.AllowUserToAddRows = false;
            this.dgv_sublist.AllowUserToDeleteRows = false;
            this.dgv_sublist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sublist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sublist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sublist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c4});
            this.dgv_sublist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_sublist.Location = new System.Drawing.Point(2, 262);
            this.dgv_sublist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_sublist.Name = "dgv_sublist";
            this.dgv_sublist.ReadOnly = true;
            this.dgv_sublist.RowTemplate.Height = 27;
            this.dgv_sublist.Size = new System.Drawing.Size(1020, 152);
            this.dgv_sublist.TabIndex = 8;
            this.dgv_sublist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sublist_CellClick);
            this.dgv_sublist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_sublist_RowPostPaint);
            // 
            // c4
            // 
            this.c4.HeaderText = "";
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            // 
            // btn_sub
            // 
            this.btn_sub.Location = new System.Drawing.Point(474, 217);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(75, 23);
            this.btn_sub.TabIndex = 7;
            this.btn_sub.Text = "分包";
            this.btn_sub.UseVisualStyleBackColor = true;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // txt_fbsl
            // 
            this.txt_fbsl.Location = new System.Drawing.Point(285, 219);
            this.txt_fbsl.Name = "txt_fbsl";
            this.txt_fbsl.Size = new System.Drawing.Size(183, 21);
            this.txt_fbsl.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "请输入分出数量：";
            // 
            // btn_se
            // 
            this.btn_se.Location = new System.Drawing.Point(474, 24);
            this.btn_se.Name = "btn_se";
            this.btn_se.Size = new System.Drawing.Size(75, 23);
            this.btn_se.TabIndex = 2;
            this.btn_se.Text = "查找";
            this.btn_se.UseVisualStyleBackColor = true;
            this.btn_se.Click += new System.EventHandler(this.btn_se_Click);
            // 
            // txt_xytm
            // 
            this.txt_xytm.Location = new System.Drawing.Point(285, 26);
            this.txt_xytm.Name = "txt_xytm";
            this.txt_xytm.Size = new System.Drawing.Size(183, 21);
            this.txt_xytm.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "请输入或扫描现有条码：";
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.btn_th);
            this.tabPage4.Controls.Add(this.txt_chd);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.dgv_relist);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.txt_thsl);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.dgv_Shipmentslist);
            this.tabPage4.Controls.Add(this.btn_sf);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(1024, 416);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "退货打印";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Green;
            this.label18.Location = new System.Drawing.Point(194, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(317, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "可输入出货计划编号或客户名称或客户物料号进行查询";
            // 
            // btn_th
            // 
            this.btn_th.Location = new System.Drawing.Point(463, 213);
            this.btn_th.Name = "btn_th";
            this.btn_th.Size = new System.Drawing.Size(75, 23);
            this.btn_th.TabIndex = 14;
            this.btn_th.Text = "退货";
            this.btn_th.UseVisualStyleBackColor = true;
            this.btn_th.Click += new System.EventHandler(this.btn_th_Click);
            // 
            // txt_chd
            // 
            this.txt_chd.Location = new System.Drawing.Point(301, 28);
            this.txt_chd.Name = "txt_chd";
            this.txt_chd.Size = new System.Drawing.Size(138, 21);
            this.txt_chd.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "退货后条码信息";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "出货信息";
            // 
            // dgv_relist
            // 
            this.dgv_relist.AllowUserToAddRows = false;
            this.dgv_relist.AllowUserToDeleteRows = false;
            this.dgv_relist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_relist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_relist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_relist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c6});
            this.dgv_relist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_relist.Location = new System.Drawing.Point(2, 275);
            this.dgv_relist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_relist.Name = "dgv_relist";
            this.dgv_relist.ReadOnly = true;
            this.dgv_relist.RowTemplate.Height = 27;
            this.dgv_relist.Size = new System.Drawing.Size(1020, 139);
            this.dgv_relist.TabIndex = 9;
            this.dgv_relist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_relist_CellClick);
            this.dgv_relist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_relist_RowPostPaint);
            // 
            // c6
            // 
            this.c6.HeaderText = "";
            this.c6.Name = "c6";
            this.c6.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(545, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_thsl
            // 
            this.txt_thsl.Location = new System.Drawing.Point(320, 213);
            this.txt_thsl.Name = "txt_thsl";
            this.txt_thsl.Size = new System.Drawing.Size(137, 21);
            this.txt_thsl.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "请输入退货数量：";
            // 
            // dgv_Shipmentslist
            // 
            this.dgv_Shipmentslist.AllowUserToAddRows = false;
            this.dgv_Shipmentslist.AllowUserToDeleteRows = false;
            this.dgv_Shipmentslist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Shipmentslist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Shipmentslist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Shipmentslist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c5});
            this.dgv_Shipmentslist.Location = new System.Drawing.Point(4, 72);
            this.dgv_Shipmentslist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Shipmentslist.MultiSelect = false;
            this.dgv_Shipmentslist.Name = "dgv_Shipmentslist";
            this.dgv_Shipmentslist.ReadOnly = true;
            this.dgv_Shipmentslist.RowTemplate.Height = 27;
            this.dgv_Shipmentslist.Size = new System.Drawing.Size(1016, 119);
            this.dgv_Shipmentslist.TabIndex = 5;
            this.dgv_Shipmentslist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Shipmentslist_CellClick);
            this.dgv_Shipmentslist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Shipmentslist_CellContentClick);
            this.dgv_Shipmentslist.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Shipmentslist_DataBindingComplete);
            this.dgv_Shipmentslist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Shipmentslist_RowPostPaint);
            // 
            // c5
            // 
            this.c5.HeaderText = "";
            this.c5.Name = "c5";
            this.c5.ReadOnly = true;
            // 
            // btn_sf
            // 
            this.btn_sf.Location = new System.Drawing.Point(477, 28);
            this.btn_sf.Name = "btn_sf";
            this.btn_sf.Size = new System.Drawing.Size(75, 23);
            this.btn_sf.TabIndex = 2;
            this.btn_sf.Text = "查找";
            this.btn_sf.UseVisualStyleBackColor = true;
            this.btn_sf.Click += new System.EventHandler(this.btn_sf_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "请选择出货单号：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重庆朗润机电条码数据采集程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_unprintlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barcodelist)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_brokenlist)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_exismsglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sublist)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_relist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipmentslist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_unprintlist;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_barcodelist;
        private System.Windows.Forms.Button btn_barcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_pri;
        private System.Windows.Forms.DataGridView dgv_brokenlist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_tm;
        private System.Windows.Forms.Button btn_se;
        private System.Windows.Forms.TextBox txt_xytm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_p;
        private System.Windows.Forms.DataGridView dgv_sublist;
        private System.Windows.Forms.Button btn_sub;
        private System.Windows.Forms.TextBox txt_fbsl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_exismsglist;
        private System.Windows.Forms.DataGridView dgv_relist;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_thsl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_Shipmentslist;
        private System.Windows.Forms.Button btn_sf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtcx;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c4;
        private System.Windows.Forms.TextBox txt_chd;
        private System.Windows.Forms.Button btn_th;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}