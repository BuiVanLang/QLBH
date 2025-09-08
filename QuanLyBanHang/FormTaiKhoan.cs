using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormTaiKhoan : Form
    {
        public FormTaiKhoan()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút
            buttonDangNhap.Click += buttonDangNhap_Click;
            buttonDangKy.Click += buttonDangKy_Click;
            buttonThoat.Click += buttonThoat_Click;
            linkLabel.Click += buttonQuenMK_Click;
            checkBox1.CheckedChanged += checkBoxHienThiMatKhau_CheckedChanged;

            // Ẩn mật khẩu khi nhập
            textBoxMatKhau.UseSystemPasswordChar = true;
        }

        String Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        // ===== Nút Đăng nhập =====
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = textBoxTaiKhoan.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTaiKhoan = @TenTaiKhoan AND MatKhau = @MatKhau";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTK);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Sau khi đăng nhập thành công có thể mở form chính
                            // FormMain frm = new FormMain();
                            // frm.Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMatKhau.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== Nút Quên mật khẩu =====
        private void buttonQuenMK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để lấy lại mật khẩu.",
                            "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Nút Đăng ký =====
        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký
            FormDangKy formDangKy = new FormDangKy();
            formDangKy.ShowDialog();
        }

        // ===== Nút Thoát =====
       // ===== Nút Thoát =====
private void buttonThoat_Click(object sender, EventArgs e)
{
    DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng form này không?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (result == DialogResult.Yes)
    {
        this.Close(); // Chỉ đóng form hiện tại, không thoát toàn bộ ứng dụng
    }
}

        // ===== Checkbox hiện/ẩn mật khẩu =====
        private void checkBoxHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMatKhau.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì ở đây
        }
    }
}
