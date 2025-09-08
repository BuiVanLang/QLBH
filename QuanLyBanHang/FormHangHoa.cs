using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormHangHoa : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormHangHoa()
        {
            InitializeComponent();
            buttonThem.Click += buttonThem_Click;
            buttonSua.Click += buttonSua_Click;
            buttonXoa.Click += buttonXoa_Click;
            buttonThoat.Click += buttonThoat_Click;
            dataGridViewHangHoa.CellClick += dataGridViewHangHoa_CellClick;
            this.Load += FormHangHoa_Load;
        }

        // ================== FORM LOAD ==================
        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            LoadChatLieu();
            LoadData();
            ClearInputs();
        }

        // ================== LOAD COMBOBOX CHẤT LIỆU ==================
        private void LoadChatLieu()
        {
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                string sql = "SELECT ID, TenChatLieu FROM ChatLieu ORDER BY ID";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxMaChatLieu.DataSource = dt;
                comboBoxMaChatLieu.DisplayMember = "TenChatLieu";
                comboBoxMaChatLieu.ValueMember = "ID";
            }
        }

        // ================== LOAD HÀNG HÓA ==================
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                string sql = @"SELECT H.ID, H.TenHang, C.TenChatLieu, H.SoLuong, H.DonGiaNhap, H.DonGiaBan, H.GhiChu 
                               FROM HangHoa H
                               INNER JOIN ChatLieu C ON H.ID_ChatLieu = C.ID
                               ORDER BY H.ID";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewHangHoa.DataSource = dt;
            }
        }

        // ================== CLEAR INPUTS ==================
        private void ClearInputs()
        {
            textBoxMaHang.Clear();
            textBoxTenHang.Clear();
            textBoxDonGiaNhap.Clear();
            textBoxDonGiaBan.Clear();
            textBoxGhiChu.Clear();
            numericUpDownSoLuong.Value = 0;
            if (comboBoxMaChatLieu.Items.Count > 0)
                comboBoxMaChatLieu.SelectedIndex = 0;
        }

        // ================== CELL CLICK ==================
        private void dataGridViewHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.Rows[e.RowIndex];
                textBoxMaHang.Text = row.Cells["ID"].Value.ToString();
                textBoxTenHang.Text = row.Cells["TenHang"].Value.ToString();
                comboBoxMaChatLieu.Text = row.Cells["TenChatLieu"].Value.ToString();
                numericUpDownSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                textBoxDonGiaNhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
                textBoxDonGiaBan.Text = row.Cells["DonGiaBan"].Value.ToString();
                textBoxGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        // ================== THÊM ==================
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTenHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hàng!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = @"INSERT INTO HangHoa (TenHang, ID_ChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu) 
                                   VALUES (@TenHang, @ID_ChatLieu, @SoLuong, @DonGiaNhap, @DonGiaBan, @GhiChu)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@TenHang", textBoxTenHang.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID_ChatLieu", comboBoxMaChatLieu.SelectedValue);
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(numericUpDownSoLuong.Value));
                    cmd.Parameters.AddWithValue("@DonGiaNhap", Convert.ToDecimal(textBoxDonGiaNhap.Text));
                    cmd.Parameters.AddWithValue("@DonGiaBan", Convert.ToDecimal(textBoxDonGiaBan.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", textBoxGhiChu.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm hàng hóa thành công!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message);
            }
        }

        // ================== SỬA ==================
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = @"UPDATE HangHoa 
                                   SET TenHang=@TenHang, ID_ChatLieu=@ID_ChatLieu, SoLuong=@SoLuong, 
                                       DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan, GhiChu=@GhiChu 
                                   WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@TenHang", textBoxTenHang.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID_ChatLieu", comboBoxMaChatLieu.SelectedValue);
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(numericUpDownSoLuong.Value));
                    cmd.Parameters.AddWithValue("@DonGiaNhap", Convert.ToDecimal(textBoxDonGiaNhap.Text));
                    cmd.Parameters.AddWithValue("@DonGiaBan", Convert.ToDecimal(textBoxDonGiaBan.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", textBoxGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaHang.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sửa hàng hóa thành công!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message);
            }
        }

        // ================== XÓA ==================
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần xóa!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = "DELETE FROM HangHoa WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaHang.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa hàng hóa thành công!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
            }
        }

        // ================== THOÁT ==================
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
