using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excle = Microsoft.Office.Interop.Excel;
namespace QuanLyBanHang
{
    public partial class FormThongKeTheoDonHang : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormThongKeTheoDonHang()
        {
            InitializeComponent();
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã hóa đơn!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        hh.TenHang, 
                        cthd.SoLuong, 
                        hh.DonGiaBan, 
                        cthd.GiamGia,
                        (cthd.SoLuong * hh.DonGiaBan - cthd.GiamGia) AS ThanhTien,
                        kh.Ten AS TenKhachHang,
                        nv.Ten AS TenNhanVien
                    FROM HoaDonBan hd
                    INNER JOIN KhachHang kh ON hd.ID_KhachHang = kh.ID
                    INNER JOIN NhanVien1 nv ON hd.ID_NhanVien = nv.ID
                    INNER JOIN ChiTietHoaDonBan1 cthd ON hd.ID = cthd.ID
                    INNER JOIN HangHoa hh ON cthd.ID_HangHoa = hh.ID
                    WHERE hd.ID = @MaHD";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                    dgvThongKe.DataSource = null;
                    txtKhachHang.Clear();
                    txtNhanVien.Clear();
                    lblTongTien.Text = "Tổng cộng: 0";
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dgvThongKe.DataSource = dt;

                // Đặt tên cột
                dgvThongKe.Columns["TenHang"].HeaderText = "Tên hàng";
                dgvThongKe.Columns["SoLuong"].HeaderText = "SL";
                dgvThongKe.Columns["DonGiaBan"].HeaderText = "Đơn giá";
                dgvThongKe.Columns["GiamGia"].HeaderText = "Giảm giá";
                dgvThongKe.Columns["ThanhTien"].HeaderText = "Thành tiền";

                // Hiển thị tên khách + nhân viên
                txtKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();
                txtNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();

                // Tính tổng tiền
                object tong = dt.Compute("SUM(ThanhTien)", "");
                lblTongTien.Text = "Tổng cộng: " + string.Format("{0:N0}", tong);
            }
        }
        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            // Không dùng, để trống
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Không dùng, để trống
        }

        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "BÁO CÁO HÓA ĐƠN";
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
            worksheet.Cells[lastRow, 1] = lblTongTien.Text;
            worksheet.Range[$"A{lastRow}:E{lastRow}"].Font.Bold = true;

            // ===== 6. Định dạng bảng =====
            worksheet.Columns.AutoFit();
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgvThongKe.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 7. Thêm border bao quanh vùng dữ liệu =====
            // Vùng dữ liệu: từ header (startRow) đến dòng cuối (lastRow)
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