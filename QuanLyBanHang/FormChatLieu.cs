using System;                              // Thư viện cơ bản (DateTime, Exception,...)
using System.Data;                         // DataTable, DataView,...
using System.Data.SqlClient;               // SqlConnection, SqlCommand, SqlDataAdapter
using System.IO;                           // Làm việc với file/đường dẫn (không dùng trực tiếp trong file này nhưng hay cần)
using OfficeOpenXml;                       // EPPlus (đang import nhưng trong code này không dùng - có thể xóa nếu không dùng EPPlus)
using Excle = Microsoft.Office.Interop.Excel; // Alias "Excle" để dùng Excel Interop (lưu ý: Interop cần Office cài trên máy)
using System.Windows.Forms;                // WinForms: Form, Button, DataGridView, MessageBox,...

namespace QuanLyBanHang
{
    public partial class FormChatLieu : Form
    {
        // Chuỗi kết nối tới SQL Server (cấu hình máy của bạn).
        // Lưu ý: nên để chuỗi kết nối trong file cấu hình (app.config) khi deploy.
        private readonly string Nguon = @"Data Source=DESKTOP-87TR50A\SQLEXPRESS;Initial Catalog=QLBH3;Integrated Security=True";

        // DataTable dùng để lưu tạm dữ liệu ChatLieu khi nạp từ DB.
        // Biến này dùng lại để filter (tìm kiếm) mà không cần query lại DB mỗi lần.
        private DataTable dtChatLieu;

        // Constructor form: khởi tạo component và gán các event handler.
        public FormChatLieu()
        {
            InitializeComponent(); // Khởi tạo các control do Designer sinh ra

            // Gán sự kiện cho các nút (nếu bạn đã gán trong Designer thì có thể dư, nhưng gán lại an toàn)
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            buttonThoat.Click += ButtonThoat_Click;

            // Khi người dùng click 1 ô trong DataGridView sẽ gọi hàm đổ dữ liệu ra textbox
            dataGridViewChatLieu.CellClick += DataGridViewChatLieu_CellClick;

            // Sự kiện khi form load
            this.Load += FormChatLieu_Load;

            // Khi text thay đổi trong ô tìm kiếm -> gọi hàm tìm kiếm (lọc)
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;

            // Gán sự kiện cho nút export (xuất Excel)
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
        }

        // Event handler cho TextChanged của ô tìm kiếm: gọi hàm lọc
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemChatLieu();
        }

        // Sự kiện khi form load: nạp dữ liệu và reset form
        private void FormChatLieu_Load(object sender, EventArgs e)
        {
            LoadChatLieu(); // Nạp danh sách chất liệu từ DB
            ResetForm();    // Xóa sạch input (đưa về mặc định)
        }

        // Hàm nạp tất cả ChatLieu từ DB vào DataTable và bind lên DataGridView
        private void LoadChatLieu()
        {
            // Sử dụng using để tự động dispose SqlConnection khi xong
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open(); // Mở kết nối tới DB (có thể throw exception nếu không kết nối được)

                // Câu SQL lấy ID và tên chất liệu, sắp theo ID
                string sql = "SELECT ID, TenChatLieu FROM ChatLieu ORDER BY ID";

                // SqlDataAdapter dùng để điền dữ liệu vào DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    dtChatLieu = new DataTable(); // Khởi tạo DataTable mới
                    adapter.Fill(dtChatLieu);     // Fill dữ liệu từ DB vào DataTable
                    dataGridViewChatLieu.DataSource = dtChatLieu; // Bind DataTable lên DataGridView
                }
                // Kết thúc using -> adapter disposed; using conn đóng và dispose connection
            }
        }

        // Reset (xóa) nội dung các ô input trên form
        private void ResetForm()
        {
            textBoxMaChatLieu.Text = "";   // Xóa mã chất liệu (textbox chứa ID)
            textBoxTenChatLieu.Text = "";  // Xóa tên chất liệu
        }

        // Khi người dùng click 1 dòng trên DataGridView -> đổ dữ liệu dòng đó vào các textbox
        private void DataGridViewChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra index hợp lệ (e.RowIndex có thể là -1 nếu click header)
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị cột 0 (ID) và cột 1 (TenChatLieu) để hiển thị
                // Lưu ý: cần kiểm tra null trước khi ToString trong trường hợp dữ liệu rỗng
                textBoxMaChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxTenChatLieu.Text = dataGridViewChatLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        // ================== NÚT THÊM ==================
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra bắt buộc: tên chất liệu không được rỗng hoặc toàn khoảng trắng
            if (string.IsNullOrWhiteSpace(textBoxTenChatLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chất liệu!");
                return; // Dừng việc thêm nếu không hợp lệ
            }

            // Dùng using để tự động giải phóng kết nối
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();

                // Query INSERT dùng parameter để tránh SQL injection
                string sql = "INSERT INTO ChatLieu (TenChatLieu) VALUES (@TenChatLieu)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm parameter và trim() để loại khoảng trắng thừa
                    // Lưu ý: AddWithValue tự suy đoán kiểu dữ liệu; trong 1 số trường hợp nên dùng Add() với SqlDbType rõ ràng
                    cmd.Parameters.AddWithValue("@TenChatLieu", textBoxTenChatLieu.Text.Trim());

                    // Thực thi câu lệnh INSERT (không trả về số lượng bản ghi bị ảnh hưởng)
                    cmd.ExecuteNonQuery();
                }
            }

            // Sau khi thêm xong, nạp lại dữ liệu và reset form, thông báo thành công
            LoadChatLieu();
            ResetForm();
            MessageBox.Show("Thêm chất liệu thành công!");
        }

        // ================== NÚT SỬA ==================
        private void ButtonSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn 1 chất liệu để sửa chưa (textBoxMaChatLieu có giá trị ID)
            if (string.IsNullOrEmpty(textBoxMaChatLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn chất liệu cần sửa!");
                return;
            }

            // Dùng using để quản lý connection
            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();

                // Query UPDATE dùng parameter
                string sql = "UPDATE ChatLieu SET TenChatLieu=@TenChatLieu WHERE ID=@ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm parameter tên
                    cmd.Parameters.AddWithValue("@TenChatLieu", textBoxTenChatLieu.Text.Trim());

                    // Parse ID từ textbox (nếu textbox chứa giá trị không phải số => sẽ ném exception)
                    // Có thể cải thiện bằng int.TryParse để xử lý an toàn hơn
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaChatLieu.Text));

                    // Thực thi UPDATE
                    cmd.ExecuteNonQuery();
                }
            }

            // Cập nhật lại DataGridView và reset các ô nhập
            LoadChatLieu();
            ResetForm();
            MessageBox.Show("Sửa chất liệu thành công!");
        }

        // ================== NÚT XÓA ==================
        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn chất liệu để xóa hay không
            if (string.IsNullOrEmpty(textBoxMaChatLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn chất liệu cần xóa!");
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();

                    // Query DELETE dùng parameter
                    string sql = "DELETE FROM ChatLieu WHERE ID=@ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Parse ID từ textbox
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBoxMaChatLieu.Text));

                        // Thực thi câu lệnh DELETE
                        // Lưu ý: nếu có ràng buộc khóa ngoại (FK) từ bảng khác tham chiếu tới ChatLieu,
                        // câu lệnh này có thể ném SqlException (vi phạm ràng buộc FK).
                        cmd.ExecuteNonQuery();
                    }
                }

                // Load lại dữ liệu và reset form sau khi xóa
                LoadChatLieu();
                ResetForm();
                MessageBox.Show("Xóa chất liệu thành công!");
            }
        }

        // ================== NÚT THOÁT ==================
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi đóng form
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }

        // Hàm tìm kiếm/lọc ChatLieu dựa trên DataTable đã nạp vào dtChatLieu
        private void TimKiemChatLieu()
        {
            if (dtChatLieu == null) return; // Nếu chưa nạp dữ liệu thì không làm gì

            // Lấy từ khóa tìm kiếm, thay thế ' bằng '' để tránh lỗi khi dùng RowFilter
            string tuKhoa = textBoxTimKiem.Text.Trim().Replace("'", "''");

            // Nếu ô tìm kiếm trống -> hiển thị lại toàn bộ DataTable gốc
            if (string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewChatLieu.DataSource = dtChatLieu; // hiển thị lại toàn bộ
            }
            else
            {
                // Dùng DataView để lọc (RowFilter hỗ trợ syntax tương tự SQL WHERE)
                DataView dv = new DataView(dtChatLieu);
                dv.RowFilter = $"TenChatLieu LIKE '%{tuKhoa}%' "; // Lọc theo tên chất liệu chứa từ khóa
                dataGridViewChatLieu.DataSource = dv; // Bind DataView đã lọc lên DataGridView
            }
        }

        // Hàm xuất DataGridView ra file Excel bằng Microsoft.Office.Interop.Excel
        // Lưu ý: Excel Interop yêu cầu Office Excel được cài trên máy, và cần xử lý COM object cẩn thận.
        private void ExportExcel(string path)
        {
            // Tạo 1 instance Excel Application
            Excle.Application application = new Excle.Application();

            // Thêm Workbook mới (Workbooks.Add)
            application.Application.Workbooks.Add(Type.Missing);

            // Lấy Worksheet hiện tại (ActiveSheet)
            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "Thông Tin Chất Liệu"; // Ghi nội dung ô A1
            worksheet.Range["A1:E1"].Merge(); // Gộp ô A1..E1 (cần sửa nếu số cột > 5)
            worksheet.Range["A1"].Font.Size = 16; // Đặt size font cho tiêu đề
            worksheet.Range["A1"].Font.Bold = true; // In đậm tiêu đề
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter; // Căn giữa

            int startRow = 5; // Dòng bắt đầu để xuất header cột (dòng 5 trong file Excel)

            // ===== 3. Xuất tiêu đề cột =====
            // Duyệt các cột của DataGridView và ghi HeaderText vào file Excel
            for (int i = 0; i < dataGridViewChatLieu.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dataGridViewChatLieu.Columns[i].HeaderText;
            }

            // ===== 4. Xuất dữ liệu từ DataGridView =====
            for (int i = 0; i < dataGridViewChatLieu.Rows.Count; i++)
            {
                // Bỏ qua row mới (nếu DataGridView AllowUserToAddRows = true sẽ có 1 dòng trống)
                if (dataGridViewChatLieu.Rows[i].IsNewRow) continue;

                // Duyệt từng cột trong dòng và ghi giá trị vào Excel
                for (int j = 0; j < dataGridViewChatLieu.Columns.Count; j++)
                {
                    var value = dataGridViewChatLieu.Rows[i].Cells[j].Value;
                    // Nếu value null => ghi chuỗi rỗng, else ghi ToString() của value
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            //// ===== 5. (Tuỳ chọn) Xuất tổng hoặc thông tin khác xuống cuối bảng =====
            //// Ví dụ: xuất tổng tiền, bạn có thể tính và ghi xuống ô

            // ===== 6. Định dạng bảng =====
            worksheet.Columns.AutoFit(); // Autofit tất cả cột để vừa nội dung
            // In đậm hàng header (dòng startRow)
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChatLieu.Columns.Count]].Font.Bold = true;
            // Đổi màu nền của header (LightGray)
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewChatLieu.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 7. Thêm border bao quanh vùng dữ liệu =====
            // Tính lastRow (có thể có off-by-one nếu có IsNewRow hoặc nếu bạn bỏ qua 1 số dòng)
            int lastRow = startRow + dataGridViewChatLieu.Rows.Count - 1; // tính số dòng cuối (xem xét điều chỉnh nếu cần)

            Excle.Range usedRange = worksheet.Range[
                worksheet.Cells[startRow, 1],
                worksheet.Cells[lastRow, dataGridViewChatLieu.Columns.Count]
            ];

            // Thiết lập border liên tục và weight mảnh
            usedRange.Borders.LineStyle = Excle.XlLineStyle.xlContinuous;
            usedRange.Borders.Weight = Excle.XlBorderWeight.xlThin;

            // ===== 8. Lưu file =====
            // Lưu workbook thành file theo đường dẫn path
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;

            // Đóng Excel application
            application.Quit();

            // LƯU Ý QUAN TRỌNG:
            // - Sau khi dùng Interop cần gọi Marshal.ReleaseComObject(worksheet), ReleaseComObject(application), GC.Collect()...
            //   để đảm bảo process Excel không còn nằm trong background. Ở đây code đơn giản không show release COM chi tiết.
            // - Nếu muốn robust, hãy wrap các object COM bằng try/finally và gọi ReleaseComObject.
        }

        // Sự kiện click nút Export: hiện SaveFileDialog và gọi ExportExcel nếu nhấn OK
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Hộp thoại lưu file
            saveFileDialog.Title = "Excel File";
            saveFileDialog.Filter = "Excel File|*.xlsx;*.xls;*.xlsm"; // Lọc định dạng file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Gọi hàm export và thông báo thành công
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công");
                }
                catch (Exception ex)
                {
                    // Bắt lỗi và hiện message nếu có lỗi xảy ra khi ghi file hoặc khi thao tác với Excel
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
