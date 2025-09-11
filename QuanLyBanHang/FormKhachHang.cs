using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excle = Microsoft.Office.Interop.Excel;
namespace QuanLyBanHang
{
    public partial class FormKhachHang : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        private DataTable dtKhachHang; // Lưu dữ liệu khách hàng để tìm kiếm

        public FormKhachHang()
        {
            InitializeComponent();
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += buttonThoat_Click;
            dataGridViewKhachHang.CellClick += DataGridViewKhachHang_CellClick;
            this.Load += FormKhachHang_Load;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemKhachHang();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            ResetForm();
        }

        private void LoadKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    // Lấy đúng tên cột gốc, không dùng alias
                    string sql = "SELECT ID, Ten, GioiTinh, NgaySinh, DiaChi, SDT FROM KhachHang";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        dtKhachHang = new DataTable();
                        adapter.Fill(dtKhachHang);
                        dataGridViewKhachHang.DataSource = dtKhachHang;

                        dataGridViewKhachHang.AutoGenerateColumns = false; // QUAN TRỌNG!
dataGridViewKhachHang.Columns.Clear();
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã KH", DataPropertyName = "ID", Name = "ID" });
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "TênKH", DataPropertyName = "Ten", Name = "Ten" });
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giới Tính", DataPropertyName = "GioiTinh", Name = "GioiTinh" });
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày Sinh", DataPropertyName = "NgaySinh", Name = "NgaySinh" });
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi", Name = "DiaChi" });
dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số Điện Thoại", DataPropertyName = "SDT", Name = "SDT" });
                       
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
            textBoxMaKH.Text = "";
            textBoxTenKH.Text = "";
            radioButtonNam.Checked = true;
            radioButtonNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
            textBoxDiaChi.Text = "";
            textBoxSoDienThoai.Text = "";
        }

        private void DataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewKhachHang.Rows[e.RowIndex];

                // Kiểm tra null trước khi gán
                textBoxMaKH.Text = row.Cells["ID"].Value?.ToString();
                textBoxTenKH.Text = row.Cells["Ten"].Value?.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                if (gioiTinh == "Nam")
                {
                    radioButtonNam.Checked = true;
                    radioButtonNu.Checked = false;
                }
                else
                {
                    radioButtonNam.Checked = false;
                    radioButtonNu.Checked = true;
                }

                if (row.Cells["NgaySinh"].Value != null)
                    dateTimePickerNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                textBoxDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                textBoxSoDienThoai.Text = row.Cells["SDT"].Value?.ToString();
            }
        }


        private void ButtonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "INSERT INTO KhachHang (Ten, GioiTinh, NgaySinh, DiaChi, SDT) VALUES (@Ten, @GioiTinh, @NgaySinh, @DiaChi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", textBoxTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButtonNam.Checked ? "Nam" : "Nữ");
                        cmd.Parameters.AddWithValue("@NgaySinh", dateTimePickerNgaySinh.Value.Date);
                        cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", textBoxSoDienThoai.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadKhachHang();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();
                    string sql = "UPDATE KhachHang SET Ten=@Ten, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, DiaChi=@DiaChi, SDT=@SDT WHERE ID=@ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaKH.Text));
                        cmd.Parameters.AddWithValue("@Ten", textBoxTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButtonNam.Checked ? "Nam" : "Nữ");
                        cmd.Parameters.AddWithValue("@NgaySinh", dateTimePickerNgaySinh.Value.Date);
                        cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", textBoxSoDienThoai.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Sửa khách hàng thành công!");
                LoadKhachHang();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        conn.Open();
                        string sql = "DELETE FROM KhachHang WHERE ID=@ID";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaKH.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa khách hàng thành công!");
                    LoadKhachHang();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TimKiemKhachHang()
        {
            if (dtKhachHang == null) return;

            string tuKhoa = textBoxTimKiem.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewKhachHang.DataSource = dtKhachHang; // hiển thị lại toàn bộ
            }
            else
            {
                DataView dv = new DataView(dtKhachHang);
                dv.RowFilter = $"Ten LIKE '%{tuKhoa}%' OR SDT LIKE '%{tuKhoa}%'";
                dataGridViewKhachHang.DataSource = dv;
            }
        }
        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            // Xuất tiêu đề cột
            for (int i = 0; i < dataGridViewKhachHang.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridViewKhachHang.Columns[i].HeaderText;
            }

            // Xuất dữ liệu 
            for (int i = 0; i < dataGridViewKhachHang.Rows.Count; i++)
            {
                if (dataGridViewKhachHang.Rows[i].IsNewRow) continue; // bỏ qua dòng trống

                for (int j = 0; j < dataGridViewKhachHang.Columns.Count; j++)
                {
                    var value = dataGridViewKhachHang.Rows[i].Cells[j].Value;
                    application.Cells[i + 2, j + 1] = value == null ? "" : value.ToString();
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit(); // đóng Excel để giải phóng
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Excel File";
            saveFileDialog.Filter = "Excel File|*.xlsx;*.xls;*.xlsm";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

    }
}
