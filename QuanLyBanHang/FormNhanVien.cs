using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormNhanVien : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormNhanVien()
        {
            InitializeComponent();
            dataGridViewNhanVien.Columns.Clear();
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", DataPropertyName = "ID" });
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ten", HeaderText = "Tên NV", DataPropertyName = "Ten" });
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", HeaderText = "Giới Tính", DataPropertyName = "GioiTinh" });
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", HeaderText = "Ngày Sinh", DataPropertyName = "NgaySinh" });
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChi", HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi" });
            dataGridViewNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "Số Điện Thoại", DataPropertyName = "SoDienThoai" });
            dataGridViewNhanVien.AutoGenerateColumns = false; // Ngăn tự động tạo cột

            // Gán sự kiện cho DataGridView
            dataGridViewNhanVien.CellClick += DataGridViewNhanVien_CellClick;
            // Gán sự kiện cho các nút
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += ButtonThoat_Click;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            ResetForm();
        }

        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "SELECT * FROM NhanVien1";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewNhanVien.DataSource = dt;
                        dataGridViewNhanVien.AutoGenerateColumns = false;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
               
            }
        }

        private void ResetForm()
        {
            textBoxID.Text = "";
            textBoxTenNV.Text = "";
            radioButtonNam.Checked = true;
            radioButtonNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
            textBoxDiaChi.Text = "";
            textBoxSoDienThoai.Text = "";
        }

        private void DataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewNhanVien.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                DataGridViewRow row = dataGridViewNhanVien.Rows[e.RowIndex];
                textBoxID.Text = row.Cells["ID"].Value.ToString();
                textBoxTenNV.Text = row.Cells["Ten"].Value.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                radioButtonNam.Checked = gioiTinh == "Nam";
                radioButtonNu.Checked = gioiTinh == "Nữ";
                dateTimePickerNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                textBoxDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                textBoxSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "INSERT INTO NhanVien1 (Ten, GioiTinh, DiaChi, NgaySinh, SoDienThoai) VALUES (@Ten, @GioiTinh, @DiaChi, @NgaySinh, @SoDienThoai)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", textBoxTenNV.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButtonNam.Checked ? "Nam" : "Nữ");
                        cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dateTimePickerNgaySinh.Value.Date);
                        cmd.Parameters.AddWithValue("@SoDienThoai", textBoxSoDienThoai.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadNhanVien();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "UPDATE NhanVien1 SET Ten=@Ten, GioiTinh=@GioiTinh, DiaChi=@DiaChi, NgaySinh=@NgaySinh, SoDienThoai=@SoDienThoai WHERE ID=@ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxID.Text));
                        cmd.Parameters.AddWithValue("@Ten", textBoxTenNV.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButtonNam.Checked ? "Nam" : "Nữ");
                        cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dateTimePickerNgaySinh.Value.Date);
                        cmd.Parameters.AddWithValue("@SoDienThoai", textBoxSoDienThoai.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Sửa nhân viên thành công!");
                LoadNhanVien();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        conn.Open();
                        string sql = "DELETE FROM NhanVien1 WHERE ID=@ID";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxID.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadNhanVien();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Để trống hoặc thêm code nếu cần
        }
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            // Để trống hoặc viết xử lý nếu cần
        }

    }
}
