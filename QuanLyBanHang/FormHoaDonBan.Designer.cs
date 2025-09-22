namespace QuanLyBanHang
{
    partial class FormHoaDonBan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMaHoaDon = new System.Windows.Forms.TextBox();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.dataGridViewHoaDonBan = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_ChiTietHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMaChiTietHoaDon = new System.Windows.Forms.ComboBox();
            this.comboBoxMaKhachHang = new System.Windows.Forms.ComboBox();
            this.comboBoxMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelInputs = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDonBan)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelInputs.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(420, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "HÓA ĐƠN BÁN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Hóa Đơn";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(25, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã Chi Tiết HĐ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã Nhân Viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(25, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã Khách Hàng";
            // 
            // textBoxMaHoaDon
            // 
            this.textBoxMaHoaDon.BackColor = System.Drawing.Color.White;
            this.textBoxMaHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxMaHoaDon.Location = new System.Drawing.Point(200, 25);
            this.textBoxMaHoaDon.Name = "textBoxMaHoaDon";
            this.textBoxMaHoaDon.Size = new System.Drawing.Size(280, 30);
            this.textBoxMaHoaDon.TabIndex = 5;
            this.textBoxMaHoaDon.TextChanged += new System.EventHandler(this.textBoxMaHoaDon_TextChanged);
            // 
            // buttonThem
            // 
            this.buttonThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.buttonThem.FlatAppearance.BorderSize = 0;
            this.buttonThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.buttonThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThem.ForeColor = System.Drawing.Color.White;
            this.buttonThem.Location = new System.Drawing.Point(15, 15);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(120, 45);
            this.buttonThem.TabIndex = 9;
            this.buttonThem.Text = "✚ Thêm";
            this.buttonThem.UseVisualStyleBackColor = false;
            // 
            // buttonSua
            // 
            this.buttonSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.buttonSua.FlatAppearance.BorderSize = 0;
            this.buttonSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.buttonSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonSua.ForeColor = System.Drawing.Color.White;
            this.buttonSua.Location = new System.Drawing.Point(15, 75);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(120, 45);
            this.buttonSua.TabIndex = 10;
            this.buttonSua.Text = "✏ Sửa";
            this.buttonSua.UseVisualStyleBackColor = false;
            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonXoa.FlatAppearance.BorderSize = 0;
            this.buttonXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.buttonXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonXoa.ForeColor = System.Drawing.Color.White;
            this.buttonXoa.Location = new System.Drawing.Point(15, 135);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(120, 45);
            this.buttonXoa.TabIndex = 11;
            this.buttonXoa.Text = "🗑 Xóa";
            this.buttonXoa.UseVisualStyleBackColor = false;
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.buttonThoat.FlatAppearance.BorderSize = 0;
            this.buttonThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.buttonThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThoat.ForeColor = System.Drawing.Color.White;
            this.buttonThoat.Location = new System.Drawing.Point(15, 195);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(120, 45);
            this.buttonThoat.TabIndex = 12;
            this.buttonThoat.Text = "← Thoát";
            this.buttonThoat.UseVisualStyleBackColor = false;
            // 
            // dataGridViewHoaDonBan
            // 
            this.dataGridViewHoaDonBan.AllowUserToAddRows = false;
            this.dataGridViewHoaDonBan.AllowUserToDeleteRows = false;
            this.dataGridViewHoaDonBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHoaDonBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHoaDonBan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewHoaDonBan.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHoaDonBan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewHoaDonBan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewHoaDonBan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHoaDonBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHoaDonBan.ColumnHeadersHeight = 40;
            this.dataGridViewHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewHoaDonBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_ChiTietHoaDon,
            this.ID_NhanVien,
            this.ID_KhachHang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHoaDonBan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewHoaDonBan.EnableHeadersVisualStyles = false;
            this.dataGridViewHoaDonBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewHoaDonBan.Location = new System.Drawing.Point(30, 420);
            this.dataGridViewHoaDonBan.Name = "dataGridViewHoaDonBan";
            this.dataGridViewHoaDonBan.ReadOnly = true;
            this.dataGridViewHoaDonBan.RowHeadersVisible = false;
            this.dataGridViewHoaDonBan.RowHeadersWidth = 62;
            this.dataGridViewHoaDonBan.RowTemplate.Height = 35;
            this.dataGridViewHoaDonBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHoaDonBan.Size = new System.Drawing.Size(1066, 180);
            this.dataGridViewHoaDonBan.TabIndex = 13;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.HeaderText = "Mã Hóa Đơn";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ID_ChiTietHoaDon
            // 
            this.ID_ChiTietHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_ChiTietHoaDon.HeaderText = "Mã Chi Tiết Hóa Đơn";
            this.ID_ChiTietHoaDon.MinimumWidth = 8;
            this.ID_ChiTietHoaDon.Name = "ID_ChiTietHoaDon";
            this.ID_ChiTietHoaDon.ReadOnly = true;
            // 
            // ID_NhanVien
            // 
            this.ID_NhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_NhanVien.HeaderText = "Mã Nhân Viên";
            this.ID_NhanVien.MinimumWidth = 8;
            this.ID_NhanVien.Name = "ID_NhanVien";
            this.ID_NhanVien.ReadOnly = true;
            // 
            // ID_KhachHang
            // 
            this.ID_KhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_KhachHang.HeaderText = "Mã Khách Hàng";
            this.ID_KhachHang.MinimumWidth = 8;
            this.ID_KhachHang.Name = "ID_KhachHang";
            this.ID_KhachHang.ReadOnly = true;
            // 
            // comboBoxMaChiTietHoaDon
            // 
            this.comboBoxMaChiTietHoaDon.BackColor = System.Drawing.Color.White;
            this.comboBoxMaChiTietHoaDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaChiTietHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMaChiTietHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxMaChiTietHoaDon.FormattingEnabled = true;
            this.comboBoxMaChiTietHoaDon.Location = new System.Drawing.Point(200, 85);
            this.comboBoxMaChiTietHoaDon.Name = "comboBoxMaChiTietHoaDon";
            this.comboBoxMaChiTietHoaDon.Size = new System.Drawing.Size(280, 31);
            this.comboBoxMaChiTietHoaDon.TabIndex = 14;
            // 
            // comboBoxMaKhachHang
            // 
            this.comboBoxMaKhachHang.BackColor = System.Drawing.Color.White;
            this.comboBoxMaKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMaKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxMaKhachHang.FormattingEnabled = true;
            this.comboBoxMaKhachHang.Location = new System.Drawing.Point(200, 205);
            this.comboBoxMaKhachHang.Name = "comboBoxMaKhachHang";
            this.comboBoxMaKhachHang.Size = new System.Drawing.Size(280, 31);
            this.comboBoxMaKhachHang.TabIndex = 15;
            // 
            // comboBoxMaNhanVien
            // 
            this.comboBoxMaNhanVien.BackColor = System.Drawing.Color.White;
            this.comboBoxMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxMaNhanVien.FormattingEnabled = true;
            this.comboBoxMaNhanVien.Location = new System.Drawing.Point(200, 145);
            this.comboBoxMaNhanVien.Name = "comboBoxMaNhanVien";
            this.comboBoxMaNhanVien.Size = new System.Drawing.Size(280, 31);
            this.comboBoxMaNhanVien.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(15, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tìm kiếm";
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.BackColor = System.Drawing.Color.White;
            this.textBoxTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(125, 18);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(200, 30);
            this.textBoxTimKiem.TabIndex = 18;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(350, 15);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(120, 40);
            this.buttonExport.TabIndex = 19;
            this.buttonExport.Text = "📊 Export";
            this.buttonExport.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1126, 75);
            this.panelHeader.TabIndex = 20;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputs.Controls.Add(this.label2);
            this.panelInputs.Controls.Add(this.label3);
            this.panelInputs.Controls.Add(this.label4);
            this.panelInputs.Controls.Add(this.label5);
            this.panelInputs.Controls.Add(this.textBoxMaHoaDon);
            this.panelInputs.Controls.Add(this.comboBoxMaChiTietHoaDon);
            this.panelInputs.Controls.Add(this.comboBoxMaNhanVien);
            this.panelInputs.Controls.Add(this.comboBoxMaKhachHang);
            this.panelInputs.Location = new System.Drawing.Point(30, 105);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(520, 270);
            this.panelInputs.TabIndex = 21;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.buttonThem);
            this.panelButtons.Controls.Add(this.buttonSua);
            this.panelButtons.Controls.Add(this.buttonXoa);
            this.panelButtons.Controls.Add(this.buttonThoat);
            this.panelButtons.Location = new System.Drawing.Point(575, 105);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(155, 270);
            this.panelButtons.TabIndex = 22;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.label6);
            this.panelSearch.Controls.Add(this.textBoxTimKiem);
            this.panelSearch.Controls.Add(this.buttonExport);
            this.panelSearch.Location = new System.Drawing.Point(755, 105);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(341, 70);
            this.panelSearch.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(755, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 24;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1126, 629);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.dataGridViewHoaDonBan);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHoaDonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.FormHoaDonBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDonBan)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMaHoaDon;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.DataGridView dataGridViewHoaDonBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_ChiTietHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_KhachHang;
        private System.Windows.Forms.ComboBox comboBoxMaChiTietHoaDon;
        private System.Windows.Forms.ComboBox comboBoxMaKhachHang;
        private System.Windows.Forms.ComboBox comboBoxMaNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button button1;
    }
}