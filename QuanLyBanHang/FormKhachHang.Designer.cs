using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    partial class FormKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMaKH = new System.Windows.Forms.TextBox();
            this.textBoxTenKH = new System.Windows.Forms.TextBox();
            this.panelGioiTinh = new System.Windows.Forms.Panel();
            this.radioButtonNam = new System.Windows.Forms.RadioButton();
            this.radioButtonNu = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxSoDienThoai = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.dataGridViewKhachHang = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxThongTin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelGioiTinh.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1245, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "👥 Thông Tin Khách Hàng";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.groupBoxThongTin);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Controls.Add(this.dataGridViewKhachHang);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1245, 583);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.BackColor = System.Drawing.Color.White;
            this.groupBoxThongTin.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxThongTin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxThongTin.Location = new System.Drawing.Point(23, 23);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxThongTin.Size = new System.Drawing.Size(600, 350);
            this.groupBoxThongTin.TabIndex = 0;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "📋 Thông tin chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMaKH, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTenKH, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelGioiTinh, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerNgaySinh, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDiaChi, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSoDienThoai, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 47);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 288);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "🆔 Mã KH:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "👤 Tên KH:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "⚧ Giới Tính:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "📅 Ngày Sinh:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(3, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "🏠 Địa Chỉ:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(3, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "📞 Số Điện Thoại:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMaKH
            // 
            this.textBoxMaKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMaKH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxMaKH.Location = new System.Drawing.Point(202, 3);
            this.textBoxMaKH.Name = "textBoxMaKH";
            this.textBoxMaKH.Size = new System.Drawing.Size(300, 37);
            this.textBoxMaKH.TabIndex = 0;
            // 
            // textBoxTenKH
            // 
            this.textBoxTenKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTenKH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxTenKH.Location = new System.Drawing.Point(202, 50);
            this.textBoxTenKH.Name = "textBoxTenKH";
            this.textBoxTenKH.Size = new System.Drawing.Size(300, 37);
            this.textBoxTenKH.TabIndex = 1;
            // 
            // panelGioiTinh
            // 
            this.panelGioiTinh.Controls.Add(this.radioButtonNam);
            this.panelGioiTinh.Controls.Add(this.radioButtonNu);
            this.panelGioiTinh.Location = new System.Drawing.Point(202, 97);
            this.panelGioiTinh.Name = "panelGioiTinh";
            this.panelGioiTinh.Size = new System.Drawing.Size(300, 35);
            this.panelGioiTinh.TabIndex = 2;
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioButtonNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.radioButtonNam.Location = new System.Drawing.Point(10, 5);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(84, 34);
            this.radioButtonNam.TabIndex = 0;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // radioButtonNu
            // 
            this.radioButtonNu.AutoSize = true;
            this.radioButtonNu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioButtonNu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.radioButtonNu.Location = new System.Drawing.Point(120, 5);
            this.radioButtonNu.Name = "radioButtonNu";
            this.radioButtonNu.Size = new System.Drawing.Size(67, 34);
            this.radioButtonNu.TabIndex = 1;
            this.radioButtonNu.Text = "Nữ";
            this.radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(202, 144);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(300, 37);
            this.dateTimePickerNgaySinh.TabIndex = 3;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDiaChi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxDiaChi.Location = new System.Drawing.Point(202, 191);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(300, 37);
            this.textBoxDiaChi.TabIndex = 4;
            // 
            // textBoxSoDienThoai
            // 
            this.textBoxSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxSoDienThoai.Location = new System.Drawing.Point(202, 238);
            this.textBoxSoDienThoai.Name = "textBoxSoDienThoai";
            this.textBoxSoDienThoai.Size = new System.Drawing.Size(300, 37);
            this.textBoxSoDienThoai.TabIndex = 5;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.buttonThem);
            this.panelButtons.Controls.Add(this.buttonSua);
            this.panelButtons.Controls.Add(this.buttonXoa);
            this.panelButtons.Controls.Add(this.buttonThoat);
            this.panelButtons.Controls.Add(this.buttonExport);
            this.panelButtons.Location = new System.Drawing.Point(650, 23);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(200, 350);
            this.panelButtons.TabIndex = 1;
            // 
            // buttonThem
            // 
            this.buttonThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.buttonThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThem.FlatAppearance.BorderSize = 0;
            this.buttonThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonThem.ForeColor = System.Drawing.Color.White;
            this.buttonThem.Location = new System.Drawing.Point(20, 30);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(160, 45);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Text = "➕ Thêm";
            this.buttonThem.UseVisualStyleBackColor = false;
            // 
            // buttonSua
            // 
            this.buttonSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.buttonSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSua.FlatAppearance.BorderSize = 0;
            this.buttonSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonSua.ForeColor = System.Drawing.Color.White;
            this.buttonSua.Location = new System.Drawing.Point(20, 90);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(160, 45);
            this.buttonSua.TabIndex = 1;
            this.buttonSua.Text = "✏️ Sửa";
            this.buttonSua.UseVisualStyleBackColor = false;
            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.buttonXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXoa.FlatAppearance.BorderSize = 0;
            this.buttonXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonXoa.ForeColor = System.Drawing.Color.White;
            this.buttonXoa.Location = new System.Drawing.Point(20, 150);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(160, 45);
            this.buttonXoa.TabIndex = 2;
            this.buttonXoa.Text = "🗑️ Xóa";
            this.buttonXoa.UseVisualStyleBackColor = false;
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThoat.FlatAppearance.BorderSize = 0;
            this.buttonThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonThoat.ForeColor = System.Drawing.Color.White;
            this.buttonThoat.Location = new System.Drawing.Point(20, 270);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(160, 45);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "🚪 Thoát";
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.buttonExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(20, 210);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(160, 45);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "📊 Export";
            this.buttonExport.UseVisualStyleBackColor = false;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.label8);
            this.panelSearch.Controls.Add(this.textBoxTimKiem);
            this.panelSearch.Controls.Add(this.pictureBoxSearch);
            this.panelSearch.Location = new System.Drawing.Point(870, 23);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(350, 108);
            this.panelSearch.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(26, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 32);
            this.label8.TabIndex = 0;
            this.label8.Text = "🔍 Tìm Kiếm";
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxTimKiem.Location = new System.Drawing.Point(24, 50);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(280, 37);
            this.textBoxTimKiem.TabIndex = 0;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearch.Location = new System.Drawing.Point(310, 47);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxSearch.TabIndex = 1;
            this.pictureBoxSearch.TabStop = false;
            // 
            // dataGridViewKhachHang
            // 
            this.dataGridViewKhachHang.AllowUserToAddRows = false;
            this.dataGridViewKhachHang.AllowUserToDeleteRows = false;
            this.dataGridViewKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKhachHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ten,
            this.GioiTinh,
            this.NgaySinh,
            this.DiaChi,
            this.SDT});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewKhachHang.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewKhachHang.EnableHeadersVisualStyles = false;
            this.dataGridViewKhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dataGridViewKhachHang.Location = new System.Drawing.Point(23, 390);
            this.dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            this.dataGridViewKhachHang.ReadOnly = true;
            this.dataGridViewKhachHang.RowHeadersWidth = 62;
            this.dataGridViewKhachHang.RowTemplate.Height = 35;
            this.dataGridViewKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKhachHang.Size = new System.Drawing.Size(1197, 170);
            this.dataGridViewKhachHang.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "Mã KH";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Ten
            // 
            this.Ten.HeaderText = "Tên KH";
            this.Ten.MinimumWidth = 8;
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.MinimumWidth = 8;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.MinimumWidth = 8;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // SDT
            // 
            this.SDT.HeaderText = "Số Điện Thoại";
            this.SDT.MinimumWidth = 8;
            this.SDT.Name = "SDT";
            this.SDT.ReadOnly = true;
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1245, 663);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Hàng";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxThongTin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelGioiTinh.ResumeLayout(false);
            this.panelGioiTinh.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Panel panelMain;
        private Panel panelButtons;
        private Panel panelSearch;
        private Panel panelGioiTinh;
        private GroupBox groupBoxThongTin;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxSearch;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;

        private TextBox textBoxMaKH;
        private TextBox textBoxTenKH;
        private TextBox textBoxDiaChi;
        private TextBox textBoxSoDienThoai;
        private TextBox textBoxTimKiem;

        private RadioButton radioButtonNam;
        private RadioButton radioButtonNu;

        private Button buttonThem;
        private Button buttonSua;
        private Button buttonXoa;
        private Button buttonThoat;
        private Button buttonExport;

        private DateTimePicker dateTimePickerNgaySinh;
        private DataGridView dataGridViewKhachHang;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Ten;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn SDT;

        // Event handler cho button Thoát
        private void buttonThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Thêm các event handlers khác để tăng tính tương tác
        private void AddEventHandlers()
        {
            // Hover effects cho buttons
            buttonThem.MouseEnter += (s, e) => buttonThem.BackColor = Color.FromArgb(39, 174, 96);
            buttonThem.MouseLeave += (s, e) => buttonThem.BackColor = Color.FromArgb(46, 204, 113);

            buttonSua.MouseEnter += (s, e) => buttonSua.BackColor = Color.FromArgb(41, 128, 185);
            buttonSua.MouseLeave += (s, e) => buttonSua.BackColor = Color.FromArgb(52, 152, 219);

            buttonXoa.MouseEnter += (s, e) => buttonXoa.BackColor = Color.FromArgb(192, 57, 43);
            buttonXoa.MouseLeave += (s, e) => buttonXoa.BackColor = Color.FromArgb(231, 76, 60);

            buttonExport.MouseEnter += (s, e) => buttonExport.BackColor = Color.FromArgb(142, 68, 173);
            buttonExport.MouseLeave += (s, e) => buttonExport.BackColor = Color.FromArgb(155, 89, 182);

            buttonThoat.MouseEnter += (s, e) => buttonThoat.BackColor = Color.FromArgb(127, 140, 141);
            buttonThoat.MouseLeave += (s, e) => buttonThoat.BackColor = Color.FromArgb(149, 165, 166);

            // Focus events cho textboxes
            foreach (Control control in groupBoxThongTin.Controls)
            {
                if (control is TableLayoutPanel tlp)
                {
                    foreach (Control childControl in tlp.Controls)
                    {
                        if (childControl is TextBox tb)
                        {
                            tb.Enter += TextBox_Enter;
                            tb.Leave += TextBox_Leave;
                        }
                    }
                }
            }

            textBoxTimKiem.Enter += TextBox_Enter;
            textBoxTimKiem.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.BackColor = Color.FromArgb(255, 255, 240);
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.BackColor = Color.White;
            }
        }

        // Override OnLoad để áp dụng các style và event handlers
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AddEventHandlers();

            // Set default values
            radioButtonNam.Checked = true;
            dateTimePickerNgaySinh.Value = DateTime.Now.AddYears(-18);

            // Style cho form
            this.BackColor = Color.FromArgb(236, 240, 241);

            // Tùy chỉnh DataGridView
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            // Header styling
            dataGridViewKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewKhachHang.ColumnHeadersHeight = 40;

            // Alternating row colors
            dataGridViewKhachHang.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewKhachHang.DefaultCellStyle.BackColor = Color.White;
            dataGridViewKhachHang.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewKhachHang.DefaultCellStyle.SelectionForeColor = Color.White;

            // Border and grid styling
            dataGridViewKhachHang.BorderStyle = BorderStyle.None;
            dataGridViewKhachHang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewKhachHang.GridColor = Color.FromArgb(189, 195, 199);

            // Row styling
            dataGridViewKhachHang.RowTemplate.Height = 35;
            dataGridViewKhachHang.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridViewKhachHang.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            // Selection mode
            dataGridViewKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKhachHang.MultiSelect = false;
        }

        // Phương thức để làm tròn góc cho controls (optional - nâng cao)
        private void ApplyRoundedCorners()
        {
            // Có thể thêm code để làm tròn góc cho các panel và button
            // Điều này yêu cầu custom painting hoặc sử dụng các thư viện bổ sung
        }

        // Validation methods
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã KH!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaKH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên KH!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenKH.Focus();
                return false;
            }

            if (!radioButtonNam.Checked && !radioButtonNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Phương thức clear form
        private void ClearForm()
        {
            textBoxMaKH.Clear();
            textBoxTenKH.Clear();
            textBoxDiaChi.Clear();
            textBoxSoDienThoai.Clear();
            radioButtonNam.Checked = true;
            dateTimePickerNgaySinh.Value = DateTime.Now.AddYears(-18);
            textBoxMaKH.Focus();
        }
    }

    // Class để định nghĩa model KhachHang
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public KhachHang()
        {
            MaKH = "";
            TenKH = "";
            GioiTinh = "Nam";
            NgaySinh = DateTime.Now;
            DiaChi = "";
            SoDienThoai = "";
        }

        public KhachHang(string maKH, string tenKH, string gioiTinh,
                        DateTime ngaySinh, string diaChi, string soDienThoai)
        {
            MaKH = maKH;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}