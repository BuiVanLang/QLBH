namespace QuanLyBanHang
{
    partial class FormThongKeTheoDonHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupChucNang = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.groupChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.groupThongTin.SuspendLayout();
            this.groupChucNang.SuspendLayout();
            this.groupChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(311, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(420, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thống Kê Theo Đơn Hàng";
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.txtNhanVien);
            this.groupThongTin.Controls.Add(this.txtKhachHang);
            this.groupThongTin.Controls.Add(this.txtMaHD);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupThongTin.Location = new System.Drawing.Point(20, 80);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(420, 170);
            this.groupThongTin.TabIndex = 1;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông Tin Đơn Hàng";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Location = new System.Drawing.Point(150, 120);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(230, 30);
            this.txtNhanVien.TabIndex = 5;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Location = new System.Drawing.Point(150, 80);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Size = new System.Drawing.Size(230, 30);
            this.txtKhachHang.TabIndex = 4;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(150, 40);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(230, 30);
            this.txtMaHD.TabIndex = 3;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHoaDon_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhân Viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khách Hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã HĐ:";
            // 
            // groupChucNang
            // 
            this.groupChucNang.Controls.Add(this.buttonExport);
            this.groupChucNang.Controls.Add(this.btnThongKe);
            this.groupChucNang.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupChucNang.Location = new System.Drawing.Point(460, 80);
            this.groupChucNang.Name = "groupChucNang";
            this.groupChucNang.Size = new System.Drawing.Size(180, 170);
            this.groupChucNang.TabIndex = 2;
            this.groupChucNang.TabStop = false;
            this.groupChucNang.Text = "Chức Năng";
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(25, 95);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(120, 40);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Xuất Excel";
            this.buttonExport.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(25, 40);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(120, 40);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // groupChiTiet
            // 
            this.groupChiTiet.Controls.Add(this.dgvThongKe);
            this.groupChiTiet.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupChiTiet.Location = new System.Drawing.Point(20, 270);
            this.groupChiTiet.Name = "groupChiTiet";
            this.groupChiTiet.Size = new System.Drawing.Size(860, 200);
            this.groupChiTiet.TabIndex = 3;
            this.groupChiTiet.TabStop = false;
            this.groupChiTiet.Text = "Chi Tiết Đơn Hàng";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.LightGray;
            this.dgvThongKe.Location = new System.Drawing.Point(3, 26);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 62;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.Size = new System.Drawing.Size(854, 171);
            this.dgvThongKe.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(29, 486);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(124, 25);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng Cộng:";
            // 
            // FormThongKeTheoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.groupChiTiet);
            this.Controls.Add(this.groupChucNang);
            this.Controls.Add(this.groupThongTin);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormThongKeTheoDonHang";
            this.Text = "Thống Kê Đơn Hàng";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.groupChucNang.ResumeLayout(false);
            this.groupChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupChucNang;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.GroupBox groupChiTiet;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label lblTongTien;
    }
}
