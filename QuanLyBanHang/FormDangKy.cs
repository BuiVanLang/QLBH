using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormDangKy : Form
    {
        private readonly string Nguon = @"Data Source=DESKTOP-87TR50A\SQLEXPRESS;Initial Catalog=QLBH3;Integrated Security=True";

        public FormDangKy()
        {
            InitializeComponent();
            this.Load += FormDangKy_Load;

            // Gắn sự kiện cho nút
            buttonDangky.Click += ButtonDangky_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += ButtonThoat_Click;
            dataGridViewDangKy.CellClick += DataGridViewDangKy_CellClick;
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            LoadTaiKhoan();
            ResetForm();
        }

        // Load dữ liệu từ bảng TaiKhoan
        private void LoadTaiKhoan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "SELECT ID, TenTaiKhoan, MatKhau FROM TaiKhoan ORDER BY ID";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewDangKy.DataSource = null;
                        dataGridViewDangKy.Columns.Clear();
                        dataGridViewDangKy.AutoGenerateColumns = false;

                        // Cột  ID
                        DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                        colID.Name = "ID";
                        colID.HeaderText = "ID";
                        colID.DataPropertyName = "ID";
                        colID.Visible = false;
                        dataGridViewDangKy.Columns.Add(colID);

                        // Cột Tên tài khoản
                        DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
                        colTen.Name = "TenTaiKhoan";
                        colTen.HeaderText = "Tên tài khoản";
                        colTen.DataPropertyName = "TenTaiKhoan";
                        colTen.Width = 200;
                        dataGridViewDangKy.Columns.Add(colTen);

                        // Cột Mật khẩu
                        DataGridViewTextBoxColumn colMK = new DataGridViewTextBoxColumn();
                        colMK.Name = "MatKhau";
                        colMK.HeaderText = "Mật khẩu";
                        colMK.DataPropertyName = "MatKhau";
                        colMK.Width = 200;
                        dataGridViewDangKy.Columns.Add(colMK);

                        dataGridViewDangKy.DataSource = dt;

                        // Cấu hình DataGridView
                        dataGridViewDangKy.ReadOnly = true;
                        dataGridViewDangKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewDangKy.MultiSelect = false;
                        dataGridViewDangKy.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            textBoxTenTaiKhoan.Clear();
            textBoxMatKhau.Clear();
            textBoxNhapLaiMatKhau.Clear();
            textBoxTenTaiKhoan.Focus();
            dataGridViewDangKy.ClearSelection();
        }

        // Khi click vào DataGridView
        private void DataGridViewDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewDangKy.Rows[e.RowIndex];
                    textBoxTenTaiKhoan.Text = row.Cells["TenTaiKhoan"].Value?.ToString() ?? "";
                    textBoxMatKhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
                    textBoxNhapLaiMatKhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Đăng ký (Thêm tài khoản mới)
        private void ButtonDangky_Click(object sender, EventArgs e)
        {
            string tk = textBoxTenTaiKhoan.Text.Trim();
            string mk = textBoxMatKhau.Text.Trim();
            string mk2 = textBoxNhapLaiMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk) || string.IsNullOrWhiteSpace(mk2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (tk.Length < 3)
            {
                MessageBox.Show("Tên tài khoản phải có ít nhất 3 ký tự!");
                textBoxTenTaiKhoan.Focus();
                return;
            }

            if (mk.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!");
                textBoxMatKhau.Focus();
                return;
            }

            if (mk != mk2)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                textBoxNhapLaiMatKhau.Focus();
                return;
            }

            if (KiemTraTrungTaiKhoan(tk))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác!");
                textBoxTenTaiKhoan.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "INSERT INTO TaiKhoan(TenTaiKhoan, MatKhau) VALUES(@tk, @mk)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tk", tk);
                        cmd.Parameters.AddWithValue("@mk", mk);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đăng ký thành công!");
                LoadTaiKhoan();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private void ButtonSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewDangKy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                return;
            }

            if (!int.TryParse(dataGridViewDangKy.CurrentRow.Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            string tk = textBoxTenTaiKhoan.Text.Trim();
            string mk = textBoxMatKhau.Text.Trim();
            string mk2 = textBoxNhapLaiMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk) || string.IsNullOrWhiteSpace(mk2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (tk.Length < 3)
            {
                MessageBox.Show("Tên tài khoản phải có ít nhất 3 ký tự!");
                return;
            }

            if (mk.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!");
                return;
            }

            if (mk != mk2)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            if (KiemTraTrungTaiKhoan(tk, id))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "UPDATE TaiKhoan SET TenTaiKhoan=@tk, MatKhau=@mk WHERE ID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tk", tk);
                        cmd.Parameters.AddWithValue("@mk", mk);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Sửa thành công!");
                LoadTaiKhoan();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewDangKy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            if (!int.TryParse(dataGridViewDangKy.CurrentRow.Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "DELETE FROM TaiKhoan WHERE ID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa thành công!");
                LoadTaiKhoan();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thoát
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) this.Close();
        }

        // Kiểm tra trùng tài khoản
        private bool KiemTraTrungTaiKhoan(string tenTK, int? excludeId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTaiKhoan = @tk";
                    if (excludeId.HasValue)
                    {
                        sql += " AND ID <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tk", tenTK);
                        if (excludeId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", excludeId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        //private void FormDangKy_Load1(object sender, EventArgs e)
        //{

        //}
    }
}
