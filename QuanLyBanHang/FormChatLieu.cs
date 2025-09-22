using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excle = Microsoft.Office.Interop.Excel;

namespace QuanLyBanHang
{
    public partial class FormChatLieu : Form
    {
       
        // Chuỗi kết nối đến CSDL
        private readonly string Nguon = @"Data Source=DESKTOP-87TR50A\SQLEXPRESS;Initial Catalog=QLBH3;Integrated Security=True";
        // DataTable để chứa dữ liệu chất liệu từ SQL
        private DataTable dtChatLieu;


        // Khởi tạo form và gán sự kiện cho các button + datagridview
        public FormChatLieu()
        {
            InitializeComponent();

            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += ButtonThoat_Click;
            dataGridViewChatLieu.CellClick += DataGridViewChatLieu_CellClick;
            this.Load += FormChatLieu_Load;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }

        // ===================== FORM LOAD =====================
        // Khi form load -> gọi hàm Load dữ liệu và reset textbox
        private void FormChatLieu_Load(object sender, EventArgs e)
        {
            LoadChatLieu();
            ResetForm();
        }

        // ===================== LOAD DỮ LIỆU & RESET FORM =====================
        // Hàm load danh sách chất liệu từ SQL lên DataGridView
        private void LoadChatLieu()
        {
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();
                string sql = "SELECT ID, TenChatLieu FROM ChatLieu ORDER BY ID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    dtChatLieu = new DataTable();
                    adapter.Fill(dtChatLieu);
                    dataGridViewChatLieu.DataSource = dtChatLieu;
                }
            }
        }

        // Reset các textbox sau khi thêm/sửa/xóa
        private void ResetForm()
        {
            textBoxMaChatLieu.Text = "";
            textBoxTenChatLieu.Text = "";
        }
        // cell click
        private void DataGridViewChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxMaChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxTenChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        // ===================== CRUD: THÊM CHẤT LIỆU =====================
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
                    // Gán giá trị từ textbox vào @TenChatLieu
                    cmd.Parameters.AddWithValue("@TenChatLieu", textBoxTenChatLieu.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }

            LoadChatLieu();
            ResetForm();
            MessageBox.Show("Thêm chất liệu thành công!");
        }

        // ===================== CRUD: SỬA CHẤT LIỆU =====================
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

        // ===================== CRUD: XÓA CHẤT LIỆU =====================
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

        // ===================== NÚT THOÁT =====================
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes) this.Close();
        }

        // ===================== TÌM KIẾM =====================
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemChatLieu();
        }


        private void TimKiemChatLieu()
        {
            if (dtChatLieu == null) return;

            string tuKhoa = textBoxTimKiem.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewChatLieu.DataSource = dtChatLieu;
            }
            else
            {
                DataView dv = new DataView(dtChatLieu);
                dv.RowFilter = $"TenChatLieu LIKE '%{tuKhoa}%'";
                dataGridViewChatLieu.DataSource = dv;
            }
        }

        // ===================== XUẤT FILE EXCEL =====================
        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);
            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // --- Tiêu đề ---
            worksheet.Cells[1, 1] = "Thông Tin Chất Liệu";
            worksheet.Range["A1:E1"].Merge();
            worksheet.Range["A1"].Font.Size = 16;
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter;

            int startRow = 5;

            // --- Header ---
            for (int i = 0; i < dataGridViewChatLieu.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dataGridViewChatLieu.Columns[i].HeaderText;
            }

            // --- Dữ liệu ---
            for (int i = 0; i < dataGridViewChatLieu.Rows.Count; i++)
            {
                if (dataGridViewChatLieu.Rows[i].IsNewRow) continue;
                for (int j = 0; j < dataGridViewChatLieu.Columns.Count; j++)
                {
                    var value = dataGridViewChatLieu.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            // --- Format bảng ---
            worksheet.Columns.AutoFit(); 
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChatLieu.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChatLieu.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            // xác định vùng có dữ liệu
            int lastRow = startRow + dataGridViewChatLieu.Rows.Count - 1;
            Excle.Range usedRange = worksheet.Range[
                worksheet.Cells[startRow, 1],
                worksheet.Cells[lastRow, dataGridViewChatLieu.Columns.Count]
            ];
            // Định dạng viền cho vùng dữ liệu
            usedRange.Borders.LineStyle = Excle.XlLineStyle.xlContinuous;
            usedRange.Borders.Weight = Excle.XlBorderWeight.xlThin;

            // Lưu file
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        // Sự kiện click nút Export
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
