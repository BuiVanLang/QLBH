using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
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

                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = dt;

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
                if (dataGridView1.Columns.Contains("TenNhanVien"))
                    dataGridView1.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";

                if (dataGridView1.Columns.Contains("SoHoaDon"))
                {
                    dataGridView1.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                    dataGridView1.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dataGridView1.Columns.Contains("DoanhThu"))
                {
                    dataGridView1.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                    dataGridView1.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo dialog lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu báo cáo thống kê",
                FileName = $"BaoCaoNhanVien_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            // Hiển thị cursor loading
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ExportDataToExcel(saveFileDialog.FileName);

                // Thông báo thành công và hỏi có muốn mở file
                DialogResult result = MessageBox.Show(
                    $"Xuất Excel thành công!\n\nĐường dẫn: {saveFileDialog.FileName}\n\nBạn có muốn mở file không?",
                    "Thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportDataToExcel(string filePath)
        {
           /* Excel.Application excelApp = null;
            Excel._Workbook workbook = null;
            Excel._Worksheet worksheet = null;

            try
            {
                // Khởi tạo Excel Application
                excelApp = new Excel.Application
                {
                    Visible = false,
                    ScreenUpdating = false,
                    DisplayAlerts = false
                };

                // Tạo workbook và worksheet
                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thống Kê Nhân Viên";

                // Tạo tiêu đề báo cáo
                CreateReportHeader(worksheet);

                // Tạo header cho bảng dữ liệu
                CreateTableHeader(worksheet);

                // Xuất dữ liệu
                ExportTableData(worksheet);

                // Định dạng bảng
                FormatTable(worksheet);

                // Tự động điều chỉnh độ rộng cột
                worksheet.Columns.AutoFit();

                // Lưu file
                workbook.SaveAs(filePath);
            }
            finally
            {
                // Đóng và giải phóng tài nguyên
                CleanupExcelObjects(worksheet, workbook, excelApp);
            }
        }

        private void CreateReportHeader(Excel._Worksheet worksheet)
        {
            // Tiêu đề chính
            worksheet.Cells[1, 1] = "BÁO CÁO THỐNG KÊ DOANH THU THEO NHÂN VIÊN";
            Excel.Range titleRange = worksheet.Range["A1", $"{GetColumnLetter(dataGridView1.Columns.Count)}1"];
            titleRange.Merge();
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 14;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);

            // Thông tin thời gian
            worksheet.Cells[2, 1] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";
            worksheet.Cells[3, 1] = $"Tìm kiếm theo: {(string.IsNullOrEmpty(textBoxTenNV.Text) ? "Tất cả nhân viên" : textBoxTenNV.Text)}";

            // Dòng trống
            worksheet.Cells[4, 1] = "";*/
        }

       /* private void CreateTableHeader(Excel._Worksheet worksheet)
        {
            const int headerRow = 5;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Excel.Range cell = worksheet.Cells[headerRow, i + 1];
                cell.Value = dataGridView1.Columns[i].HeaderText;
                cell.Font.Bold = true;
                cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
        }

        private void ExportTableData(Excel._Worksheet worksheet)
        {
            const int dataStartRow = 6;
            int doanhThuColumnIndex = FindColumnIndex("DoanhThu");
            int soHoaDonColumnIndex = FindColumnIndex("SoHoaDon");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                    Excel.Range cell = worksheet.Cells[dataStartRow + i, j + 1];

                    if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                    {
                        if (j == doanhThuColumnIndex)
                        {
                            // Định dạng cột doanh thu
                            if (decimal.TryParse(cellValue.ToString(), out decimal money))
                            {
                                cell.Value = money;
                                cell.NumberFormat = "#,##0\" VNĐ\"";
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                        }
                        else if (j == soHoaDonColumnIndex)
                        {
                            // Định dạng cột số hóa đơn
                            if (int.TryParse(cellValue.ToString(), out int count))
                            {
                                cell.Value = count;
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                        }
                        else
                        {
                            // Các cột khác
                            cell.Value = cellValue.ToString();
                            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        }
                    }

                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }
        }

        private void FormatTable(Excel._Worksheet worksheet)
        {
            int lastRow = 5 + dataGridView1.Rows.Count;
            int lastColumn = dataGridView1.Columns.Count;

            // Tạo viền cho toàn bộ bảng
            Excel.Range tableRange = worksheet.Range[
                worksheet.Cells[5, 1],
                worksheet.Cells[lastRow, lastColumn]
            ];
            tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            tableRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            // Tạo dòng tổng kết nếu có nhiều hơn 1 dòng dữ liệu
            if (dataGridView1.Rows.Count > 1)
            {
                CreateSummaryRow(worksheet, lastRow + 1, lastColumn);
            }

           
        }

        private void CreateSummaryRow(Excel._Worksheet worksheet, int summaryRow, int lastColumn)
        {
            // Tính tổng
            decimal totalRevenue = 0;
            int totalInvoices = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["DoanhThu"].Value != null &&
                    decimal.TryParse(row.Cells["DoanhThu"].Value.ToString(), out decimal revenue))
                {
                    totalRevenue += revenue;
                }

                if (row.Cells["SoHoaDon"].Value != null &&
                    int.TryParse(row.Cells["SoHoaDon"].Value.ToString(), out int invoices))
                {
                    totalInvoices += invoices;
                }
            }

            // Tạo dòng tổng kết
            Excel.Range summaryCell1 = worksheet.Cells[summaryRow, 1];
            summaryCell1.Value = "TỔNG CỘNG";
            summaryCell1.Font.Bold = true;
            summaryCell1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

            int soHoaDonCol = FindColumnIndex("SoHoaDon");
            int doanhThuCol = FindColumnIndex("DoanhThu");

            if (soHoaDonCol >= 0)
            {
                Excel.Range totalInvoiceCell = worksheet.Cells[summaryRow, soHoaDonCol + 1];
                totalInvoiceCell.Value = totalInvoices;
                totalInvoiceCell.Font.Bold = true;
                totalInvoiceCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                totalInvoiceCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            }

            if (doanhThuCol >= 0)
            {
                Excel.Range totalRevenueCell = worksheet.Cells[summaryRow, doanhThuCol + 1];
                totalRevenueCell.Value = totalRevenue;
                totalRevenueCell.Font.Bold = true;
                totalRevenueCell.NumberFormat = "#,##0\" VNĐ\"";
                totalRevenueCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                totalRevenueCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            }

            // Tạo viền cho dòng tổng kết
            Excel.Range summaryRange = worksheet.Range[
                worksheet.Cells[summaryRow, 1],
                worksheet.Cells[summaryRow, lastColumn]
            ];
            summaryRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            summaryRange.Borders.Weight = Excel.XlBorderWeight.xlThick;
        }

        private int FindColumnIndex(string columnName)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        private string GetColumnLetter(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }
            return columnName;
        }

        private void CleanupExcelObjects(Excel._Worksheet worksheet, Excel._Workbook workbook, Excel.Application excelApp)
        {
            try
            {
                // Đóng worksheet
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                }

                // Đóng workbook
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }

                // Đóng Excel application
                if (excelApp != null)
                {
                    excelApp.ScreenUpdating = true;
                    excelApp.DisplayAlerts = true;
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi giải phóng tài nguyên Excel: {ex.Message}");
            }
            finally
            {
                // Buộc garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }*/
    }
}