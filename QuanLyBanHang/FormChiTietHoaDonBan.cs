using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excle = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormChiTietHoaDonBan : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";
        private DataTable dtChiTietHoaDon;
        public FormChiTietHoaDonBan()
        {
            InitializeComponent();
            SetupEventHandlers();
        }
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemChiTietHoaDonBan();
        }

        private void SetupEventHandlers()
        {
            dataGridViewChiTietHoaDon.CellClick += dataGridViewChiTietHoaDon_CellClick;
            buttonThem.Click += buttonThem_Click;
            buttonSua.Click += buttonSua_Click;
            buttonXoa.Click += buttonXoa_Click;
            buttonThoat.Click += buttonThoat_Click;

            this.Load += FormChiTietHoaDonBan_Load;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }

        private void FormChiTietHoaDonBan_Load(object sender, EventArgs e)
        {
            LoadHangHoa();
            LoadData();
        }

        // Load dữ liệu chi tiết hóa đơn
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = @"SELECT c.ID, c.ID_HangHoa, h.TenHang, c.SoLuong, c.GiamGia
                                   FROM ChiTietHoaDonBan1 c
                                   INNER JOIN HangHoa h ON c.ID_HangHoa = h.ID
                                   ORDER BY c.ID";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtChiTietHoaDon = new DataTable();
                    da.Fill(dtChiTietHoaDon);
                    dataGridViewChiTietHoaDon.DataSource = dtChiTietHoaDon;

                    if (dataGridViewChiTietHoaDon.Columns.Count > 0)
                    {
                        dataGridViewChiTietHoaDon.Columns["ID"].HeaderText = "ID";
                        dataGridViewChiTietHoaDon.Columns["ID_HangHoa"].HeaderText = "Mã Hàng";
                        dataGridViewChiTietHoaDon.Columns["TenHang"].HeaderText = "Tên Hàng";
                        dataGridViewChiTietHoaDon.Columns["SoLuong"].HeaderText = "Số Lượng";
                        dataGridViewChiTietHoaDon.Columns["GiamGia"].HeaderText = "Giảm Giá";

                        dataGridViewChiTietHoaDon.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridViewChiTietHoaDon.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Load danh sách hàng hóa vào combobox
        private void LoadHangHoa()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = "SELECT ID, TenHang FROM HangHoa ORDER BY TenHang";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow emptyRow = dt.NewRow();
                    emptyRow["ID"] = 0;
                    emptyRow["TenHang"] = "-- Chọn hàng hóa --";
                    dt.Rows.InsertAt(emptyRow, 0);

                    comboBoxMaHangHoa.DataSource = dt;
                    comboBoxMaHangHoa.DisplayMember = "TenHang";
                    comboBoxMaHangHoa.ValueMember = "ID";
                    comboBoxMaHangHoa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hàng hóa: " + ex.Message);
            }
        }

        // Xóa input
        private void ClearInputs()
        {
            if (comboBoxMaHangHoa.Items.Count > 0)
                comboBoxMaHangHoa.SelectedIndex = 0;
            numtBoxGiamGiSoLuong.Value = 0;
            textBoxGiamGia.Text = "";
            dataGridViewChiTietHoaDon.ClearSelection();
        }

        // Thêm dữ liệu
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if ((int)comboBoxMaHangHoa.SelectedValue == 0)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = "INSERT INTO ChiTietHoaDonBan1 (ID_HangHoa, SoLuong, GiamGia) VALUES (@ID_HangHoa, @SoLuong, @GiamGia)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID_HangHoa", comboBoxMaHangHoa.SelectedValue);
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(numtBoxGiamGiSoLuong.Value));
                    cmd.Parameters.AddWithValue("@GiamGia", string.IsNullOrWhiteSpace(textBoxGiamGia.Text) ? 0 : Convert.ToDecimal(textBoxGiamGia.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message);
            }
        }

        // Sửa dữ liệu
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewChiTietHoaDon.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewChiTietHoaDon.CurrentRow.Cells["ID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = @"UPDATE ChiTietHoaDonBan1 
                                   SET ID_HangHoa = @ID_HangHoa, SoLuong = @SoLuong, GiamGia = @GiamGia 
                                   WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID_HangHoa", comboBoxMaHangHoa.SelectedValue);
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(numtBoxGiamGiSoLuong.Value));
                    cmd.Parameters.AddWithValue("@GiamGia", string.IsNullOrWhiteSpace(textBoxGiamGia.Text) ? 0 : Convert.ToDecimal(textBoxGiamGia.Text));
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa chi tiết hóa đơn thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message);
            }
        }

        // Xóa dữ liệu
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewChiTietHoaDon.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewChiTietHoaDon.CurrentRow.Cells["ID"].Value);
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    string sql = "DELETE FROM ChiTietHoaDonBan1 WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
            }
        }

        // Thoát
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hiển thị dữ liệu khi chọn row
        private void dataGridViewChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewChiTietHoaDon.Rows[e.RowIndex];
                comboBoxMaHangHoa.SelectedValue = row.Cells["ID_HangHoa"].Value;
                numtBoxGiamGiSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                textBoxGiamGia.Text = row.Cells["GiamGia"].Value?.ToString() ?? "";
            }
        }
        private void TimKiemChiTietHoaDonBan()
        {
            if (dtChiTietHoaDon == null) return;

            string tuKhoa = textBoxTimKiem.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewChiTietHoaDon.DataSource = dtChiTietHoaDon; // hiển thị lại toàn bộ
            }
            else
            {
                DataView dv = new DataView(dtChiTietHoaDon);
                dv.RowFilter = $"[TenHang] LIKE '%{tuKhoa}%' ";
                dataGridViewChiTietHoaDon.DataSource = dv;
            }
        }
        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "Chi Tiết Hóa Đơn Bán";
            worksheet.Range["A1:E1"].Merge(); // gộp ô từ A1 đến E1 (sửa E thành cột cuối cùng của bạn)
            worksheet.Range["A1"].Font.Size = 16;
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter;



            int startRow = 5; // dòng bắt đầu cho header bảng

            // ===== 3. Xuất tiêu đề cột =====
            for (int i = 0; i < dataGridViewChiTietHoaDon.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dataGridViewChiTietHoaDon.Columns[i].HeaderText;
            }

            // ===== 4. Xuất dữ liệu =====
            for (int i = 0; i < dataGridViewChiTietHoaDon.Rows.Count; i++)
            {
                if (dataGridViewChiTietHoaDon.Rows[i].IsNewRow) continue;

                for (int j = 0; j < dataGridViewChiTietHoaDon.Columns.Count; j++)
                {
                    var value = dataGridViewChiTietHoaDon.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            //// ===== 5. Xuất tổng tiền ở cuối =====
            //int lastRow = startRow + dgvThongKe.Rows.Count + 1;
            //worksheet.Cells[lastRow, 1] = lblTongTien.Text;
            //worksheet.Range[$"A{lastRow}:E{lastRow}"].Font.Bold = true;

            // ===== 6. Định dạng bảng =====
            worksheet.Columns.AutoFit();
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChiTietHoaDon.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChiTietHoaDon.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 7. Thêm border bao quanh vùng dữ liệu =====
            int lastRow = startRow + dataGridViewChiTietHoaDon.Rows.Count - 1; // tính số dòng cuối

            Excle.Range usedRange = worksheet.Range[
     worksheet.Cells[startRow, 1],
     worksheet.Cells[lastRow, dataGridViewChiTietHoaDon.Columns.Count]
 ];

            usedRange.Borders.LineStyle = Excle.XlLineStyle.xlContinuous;
            usedRange.Borders.Weight = Excle.XlBorderWeight.xlThin;

            // ===== 8. Lưu file =====
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
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
