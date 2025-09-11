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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDonBan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(452, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hóa Đơn Bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(62, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã HĐ:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(60, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã CTHĐ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(62, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã NV: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(60, 298);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã KH:";
            // 
            // textBoxMaHoaDon
            // 
            this.textBoxMaHoaDon.Location = new System.Drawing.Point(223, 86);
            this.textBoxMaHoaDon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxMaHoaDon.Name = "textBoxMaHoaDon";
            this.textBoxMaHoaDon.Size = new System.Drawing.Size(240, 26);
            this.textBoxMaHoaDon.TabIndex = 5;
            this.textBoxMaHoaDon.TextChanged += new System.EventHandler(this.textBoxMaHoaDon_TextChanged);
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThem.Location = new System.Drawing.Point(594, 86);
            this.buttonThem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(90, 44);
            this.buttonThem.TabIndex = 9;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            // 
            // buttonSua
            // 
            this.buttonSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonSua.Location = new System.Drawing.Point(594, 158);
            this.buttonSua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(90, 53);
            this.buttonSua.TabIndex = 10;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonXoa.Location = new System.Drawing.Point(594, 234);
            this.buttonXoa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(90, 47);
            this.buttonXoa.TabIndex = 11;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            // 
            // buttonThoat
            // 
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThoat.Location = new System.Drawing.Point(594, 313);
            this.buttonThoat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(92, 44);
            this.buttonThoat.TabIndex = 12;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHoaDonBan
            // 
            this.dataGridViewHoaDonBan.AllowUserToAddRows = false;
            this.dataGridViewHoaDonBan.AllowUserToDeleteRows = false;
            this.dataGridViewHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoaDonBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_ChiTietHoaDon,
            this.ID_NhanVien,
            this.ID_KhachHang});
            this.dataGridViewHoaDonBan.Location = new System.Drawing.Point(130, 393);
            this.dataGridViewHoaDonBan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridViewHoaDonBan.Name = "dataGridViewHoaDonBan";
            this.dataGridViewHoaDonBan.ReadOnly = true;
            this.dataGridViewHoaDonBan.RowHeadersWidth = 62;
            this.dataGridViewHoaDonBan.RowTemplate.Height = 28;
            this.dataGridViewHoaDonBan.Size = new System.Drawing.Size(887, 168);
            this.dataGridViewHoaDonBan.TabIndex = 13;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "Mã Hóa Đơn";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 117;
            // 
            // ID_ChiTietHoaDon
            // 
            this.ID_ChiTietHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID_ChiTietHoaDon.HeaderText = "Mã Chi Tiết Hóa Đơn";
            this.ID_ChiTietHoaDon.MinimumWidth = 8;
            this.ID_ChiTietHoaDon.Name = "ID_ChiTietHoaDon";
            this.ID_ChiTietHoaDon.ReadOnly = true;
            this.ID_ChiTietHoaDon.Width = 139;
            // 
            // ID_NhanVien
            // 
            this.ID_NhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID_NhanVien.HeaderText = "Mã Nhân Viên";
            this.ID_NhanVien.MinimumWidth = 8;
            this.ID_NhanVien.Name = "ID_NhanVien";
            this.ID_NhanVien.ReadOnly = true;
            this.ID_NhanVien.Width = 124;
            // 
            // ID_KhachHang
            // 
            this.ID_KhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID_KhachHang.HeaderText = "Mã Khách Hàng";
            this.ID_KhachHang.MinimumWidth = 8;
            this.ID_KhachHang.Name = "ID_KhachHang";
            this.ID_KhachHang.ReadOnly = true;
            this.ID_KhachHang.Width = 135;
            // 
            // comboBoxMaChiTietHoaDon
            // 
            this.comboBoxMaChiTietHoaDon.FormattingEnabled = true;
            this.comboBoxMaChiTietHoaDon.Location = new System.Drawing.Point(223, 157);
            this.comboBoxMaChiTietHoaDon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxMaChiTietHoaDon.Name = "comboBoxMaChiTietHoaDon";
            this.comboBoxMaChiTietHoaDon.Size = new System.Drawing.Size(240, 27);
            this.comboBoxMaChiTietHoaDon.TabIndex = 14;
            // 
            // comboBoxMaKhachHang
            // 
            this.comboBoxMaKhachHang.FormattingEnabled = true;
            this.comboBoxMaKhachHang.Location = new System.Drawing.Point(223, 301);
            this.comboBoxMaKhachHang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxMaKhachHang.Name = "comboBoxMaKhachHang";
            this.comboBoxMaKhachHang.Size = new System.Drawing.Size(240, 27);
            this.comboBoxMaKhachHang.TabIndex = 15;
            // 
            // comboBoxMaNhanVien
            // 
            this.comboBoxMaNhanVien.FormattingEnabled = true;
            this.comboBoxMaNhanVien.Location = new System.Drawing.Point(223, 234);
            this.comboBoxMaNhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxMaNhanVien.Name = "comboBoxMaNhanVien";
            this.comboBoxMaNhanVien.Size = new System.Drawing.Size(240, 27);
            this.comboBoxMaNhanVien.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(750, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 26);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tìm Kiếm:";
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Location = new System.Drawing.Point(877, 98);
            this.textBoxTimKiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(156, 26);
            this.textBoxTimKiem.TabIndex = 18;
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonExport.Location = new System.Drawing.Point(755, 165);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(108, 38);
            this.buttonExport.TabIndex = 19;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // FormHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 629);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxMaNhanVien);
            this.Controls.Add(this.comboBoxMaKhachHang);
            this.Controls.Add(this.comboBoxMaChiTietHoaDon);
            this.Controls.Add(this.dataGridViewHoaDonBan);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.textBoxMaHoaDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormHoaDonBan";
            this.Load += new System.EventHandler(this.FormHoaDonBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDonBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}