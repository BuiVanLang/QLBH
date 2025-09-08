using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormChatLieu : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormChatLieu()
        {
            InitializeComponent();
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += ButtonThoat_Click;
            dataGridViewChatLieu.CellClick += DataGridViewChatLieu_CellClick;
            this.Load += FormChatLieu_Load;
        }

        private void FormChatLieu_Load(object sender, EventArgs e)
        {
            LoadChatLieu();
            ResetForm();
        }

        private void LoadChatLieu()
        {
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();
                string sql = "SELECT ID, TenChatLieu FROM ChatLieu ORDER BY ID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewChatLieu.DataSource = dt;
                }
            }
        }

        private void ResetForm()
        {
            textBoxMaChatLieu.Text = "";
            textBoxTenChatLieu.Text = "";
        }

        private void DataGridViewChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxMaChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxTenChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        // ================== NÚT THÊM ==================
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTenChatLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chất liệu!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();
                string sql = "INSERT INTO ChatLieu (TenChatLieu) VALUES (@TenChatLieu)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenChatLieu", textBoxTenChatLieu.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }

            LoadChatLieu();
            ResetForm();
            MessageBox.Show("Thêm chất liệu thành công!");
        }

        // ================== NÚT SỬA ==================
        private void ButtonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaChatLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn chất liệu cần sửa!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();
                string sql = "UPDATE ChatLieu SET TenChatLieu=@TenChatLieu WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenChatLieu", textBoxTenChatLieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaChatLieu.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            LoadChatLieu();
            ResetForm();
            MessageBox.Show("Sửa chất liệu thành công!");
        }

        // ================== NÚT XÓA ==================
        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaChatLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn chất liệu cần xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "DELETE FROM ChatLieu WHERE ID=@ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaChatLieu.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadChatLieu();
                ResetForm();
                MessageBox.Show("Xóa chất liệu thành công!");
            }
        }

        // ================== NÚT THOÁT ==================
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
