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
        // Chuỗi kết nối đến CSDL
        // Bạn cần thay "DESKTOP-87TR50A\SQLEXPRESS" bằng tên SQL Server của máy bạn
        private readonly string Nguon = @"Data Source=DESKTOP-87TR50A\SQLEXPRESS;Initial Catalog=QLBH3;Integrated Security=True";

        public FormThongKeTheoNhanVien()
        {
            InitializeComponent();

            // Khi form khởi động thì tự động load dữ liệu
            LoadData();

            // Gán sự kiện click cho nút Export
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }

        private void LoadData()
        {
            // Gọi luôn hàm btnThongKe_Click để load dữ liệu khi mở form
            btnThongKe_Click(null, null);
        }

        // ===== Xử lý khi nhấn nút "Thống kê" =====
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên nhân viên từ TextBox
                string tenNV = textBoxTenNV.Text.Trim();

                // Câu SQL lấy thống kê theo nhân viên
                // - Đếm số hóa đơn mỗi nhân viên đã làm
                // - Tính tổng doanh thu theo nhân viên
                // - Nếu textbox trống thì lấy tất cả, nếu có thì lọc theo tên NV
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
                        // Truyền tham số vào query
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);

                        // Lấy dữ liệu ra DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Gán dữ liệu lên DataGridView
                        dgvThongKe.AutoGenerateColumns = true;
                        dgvThongKe.DataSource = dt;

                        // Định dạng DataGridView (đặt tên cột, căn chỉnh, số VNĐ,...)
                        FormatDataGridView();

                        // Hiển thị tổng kết vào Label
                        ShowSummaryInfo(dt);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Nếu có lỗi SQL (ví dụ sai tên bảng, sai kết nối)
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}\n\nVui lòng kiểm tra:\n- Tên bảng và cột trong database\n- Kết nối database",
                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Định dạng lại DataGridView cho đẹp =====
        private void FormatDataGridView()
        {
            try
            {
                // Đặt tên hiển thị cho cột Tên Nhân Viên
                if (dgvThongKe.Columns.Contains("TenNhanVien"))
                    dgvThongKe.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";

                // Đặt tên + căn giữa cho cột Số hóa đơn
                if (dgvThongKe.Columns.Contains("SoHoaDon"))
                {
                    dgvThongKe.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                    dgvThongKe.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Đặt tên + định dạng số cho cột Doanh Thu
                if (dgvThongKe.Columns.Contains("DoanhThu"))
                {
                    dgvThongKe.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                    dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; // định dạng số có dấu ,
                    dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tự động giãn cột vừa khung
                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi format DataGridView: {ex.Message}");
            }
        }

        // ===== Hiển thị tổng kết ra Label =====
        private void ShowSummaryInfo(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                decimal tongDoanhThu = 0;
                int tongSoHD = 0;

                // Duyệt từng dòng cộng dồn số HĐ và Doanh thu
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DoanhThu"] != DBNull.Value)
                        tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                    if (row["SoHoaDon"] != DBNull.Value)
                        tongSoHD += Convert.ToInt32(row["SoHoaDon"]);
                }

                // Hiển thị ra Label
                labelTongTien.Text = $"Tổng cộng: {tongSoHD} hóa đơn, {tongDoanhThu:N0} VNĐ";
            }
            else
            {
                labelTongTien.Text = "Không có dữ liệu thống kê";
            }
        }

        // ===== Xuất dữ liệu ra Excel =====
        private void ExportExcel(string path)
        {
            // Tạo ứng dụng Excel
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "Thống Kê Nhân Viên ";
            worksheet.Range["A1:E1"].Merge(); // gộp ô từ A1 đến E1
            worksheet.Range["A1"].Font.Size = 16;
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter;

            int startRow = 5; // dòng bắt đầu cho header bảng

            // ===== 2. Xuất tiêu đề cột =====
            for (int i = 0; i < dgvThongKe.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dgvThongKe.Columns[i].HeaderText;
            }

            // ===== 3. Xuất dữ liệu =====
            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
            {
                if (dgvThongKe.Rows[i].IsNewRow) continue;

                for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                {
                    var value = dgvThongKe.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            // ===== 4. Xuất dòng tổng tiền ở cuối =====
            int lastRow = startRow + dgvThongKe.Rows.Count + 1;
            worksheet.Cells[lastRow, 1] = labelTongTien.Text; // Lấy nội dung label hiển thị ra Excel
            worksheet.Range[$"A{lastRow}:E{lastRow}"].Font.Bold = true;

            // ===== 5. Định dạng bảng =====
            worksheet.Columns.AutoFit();
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 6. Thêm border cho vùng dữ liệu =====
            Excle.Range usedRange = worksheet.Range[
                worksheet.Cells[startRow, 1],
                worksheet.Cells[lastRow, dgvThongKe.Columns.Count]
            ];

            usedRange.Borders.LineStyle = Excle.XlLineStyle.xlContinuous;
            usedRange.Borders.Weight = Excle.XlBorderWeight.xlThin;

            // ===== 7. Lưu file Excel =====
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        // ===== Xử lý khi bấm nút Export Excel =====
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
