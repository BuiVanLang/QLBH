using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excle = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyBanHang
{
    public partial class FormThongKeTheoNhanVien : Form
    {
        // Chuỗi kết nối đến CSDL.
        // Cần kiểm tra lại tên server "BuiVanLang" có chính xác hay không.
        // Nếu tên server là "BuiVanLang\SQLEXPRESS", hãy đổi lại.
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormThongKeTheoNhanVien()
        {
            InitializeComponent();
            LoadData();
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }

        private void LoadData()
        {
            btnThongKe_Click(null, null);
        }

        // ===== Nút Thống kê =====
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNV = textBoxTenNV.Text.Trim();

                // Câu truy vấn SQL đã được sửa lại để sử dụng tên bảng và cột đúng
                string query = @"
                    SELECT nv.Ten AS TenNhanVien, 
                           COUNT(hd.ID) AS SoHoaDon,
                           ISNULL(SUM(ct.SoLuong * hh.DonGiaBan), 0) AS DoanhThu
                    FROM NhanVien1 nv 
                    LEFT JOIN HoaDonBan hd ON nv.ID = hd.ID_NhanVien
                    LEFT JOIN ChiTietHoaDonBan1 ct ON hd.ID = ct.ID
                    LEFT JOIN HangHoa hh ON ct.ID_HangHoa = hh.ID
                    WHERE (@TenNV = '' OR nv.Ten LIKE '%' + @TenNV + '%')
                    GROUP BY nv.ID, nv.Ten
                    ORDER BY DoanhThu DESC";

                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvThongKe.AutoGenerateColumns = true;
                        dgvThongKe.DataSource = dt;

                        // Định dạng DataGridView
                        FormatDataGridView();

                        // Hiển thị thông tin tổng kết
                        ShowSummaryInfo(dt);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}\n\nVui lòng kiểm tra:\n- Tên bảng và cột trong database\n- Kết nối database",
                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            try
            {
                if (dgvThongKe.Columns.Contains("TenNhanVien"))
                    dgvThongKe.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";

                if (dgvThongKe.Columns.Contains("SoHoaDon"))
                {
                    dgvThongKe.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                    dgvThongKe.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvThongKe.Columns.Contains("DoanhThu"))
                {
                    dgvThongKe.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                    dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi format DataGridView: {ex.Message}");
            }
        }

        private void ShowSummaryInfo(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                decimal tongDoanhThu = 0;
                int tongSoHD = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["DoanhThu"] != DBNull.Value)
                        tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                    if (row["SoHoaDon"] != DBNull.Value)
                        tongSoHD += Convert.ToInt32(row["SoHoaDon"]);
                }

                this.Text = $"Thống kê theo nhân viên - Tổng: {tongSoHD} HĐ, {tongDoanhThu:N0} VNĐ";
            }
            else
            {
                this.Text = "Thống kê theo nhân viên - Không có dữ liệu";
            }
        }

        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "Thống Kê Nhân Viên ";
            worksheet.Range["A1:E1"].Merge(); // gộp ô từ A1 đến E1 (sửa E thành cột cuối cùng của bạn)
            worksheet.Range["A1"].Font.Size = 16;
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter;



            int startRow = 5; // dòng bắt đầu cho header bảng

            // ===== 3. Xuất tiêu đề cột =====
            for (int i = 0; i < dgvThongKe.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dgvThongKe.Columns[i].HeaderText;
            }

            // ===== 4. Xuất dữ liệu =====
            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
            {
                if (dgvThongKe.Rows[i].IsNewRow) continue;

                for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                {
                    var value = dgvThongKe.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            // ===== 5. Xuất tổng tiền ở cuối =====
            int lastRow = startRow + dgvThongKe.Rows.Count + 1;
            worksheet.Cells[lastRow, 1] = labelTongTien.Text;
            worksheet.Range[$"A{lastRow}:E{lastRow}"].Font.Bold = true;

            // ===== 6. Định dạng bảng =====
            worksheet.Columns.AutoFit();
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 7. Thêm border bao quanh vùng dữ liệu =====
            int lRange = startRow + dgvThongKe.Rows.Count - 1; // tính số dòng cuối

            Excle.Range usedRange = worksheet.Range[
     worksheet.Cells[startRow, 1],
     worksheet.Cells[lastRow, dgvThongKe.Columns.Count]
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