    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using OfficeOpenXml;
    using Excle = Microsoft.Office.Interop.Excel;
    using System.Windows.Forms;

    namespace QuanLyBanHang
    {
        public partial class FormHoaDonBan : Form
        {
            
            private readonly string Nguon = @"Data Source=DESKTOP-87TR50A\SQLEXPRESS;Initial Catalog=QLBH3;Integrated Security=True";
        private DataTable dtHoaDonBan;
        public FormHoaDonBan()
            {
                InitializeComponent();
                SetupDataGridView();
                SetupEventHandlers();
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
        }
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemHoaDonBan();
        }

        private void SetupDataGridView()
            {
                dataGridViewHoaDonBan.Columns.Clear();
                // Thiết lập các cột cho DataGridView
                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "Mã HĐ",
                    DataPropertyName = "ID",
                    ReadOnly = true,
                    Width = 80
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ID_ChiTietHoaDonBan",
                    HeaderText = "ID Chi Tiết",
                    DataPropertyName = "ID_ChiTietHoaDonBan",
                    Visible = false
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenHang",
                    HeaderText = "Tên Hàng",
                    DataPropertyName = "TenHang",
                    ReadOnly = true,
                    Width = 200
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ID_NhanVien",
                    HeaderText = "ID NV",
                    DataPropertyName = "ID_NhanVien",
                    Visible = false
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenNhanVien",
                    HeaderText = "Nhân Viên",
                    DataPropertyName = "TenNhanVien",
                    ReadOnly = true,
                    Width = 150
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ID_KhachHang",
                    HeaderText = "ID KH",
                    DataPropertyName = "ID_KhachHang",
                    Visible = false
                });

                dataGridViewHoaDonBan.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenKhachHang",
                    HeaderText = "Khách Hàng",
                    DataPropertyName = "TenKhachHang",
                    ReadOnly = true,
                    Width = 150
                });

                dataGridViewHoaDonBan.AutoGenerateColumns = false;
                dataGridViewHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewHoaDonBan.MultiSelect = false;
                dataGridViewHoaDonBan.ReadOnly = true;
                dataGridViewHoaDonBan.AllowUserToAddRows = false;
                dataGridViewHoaDonBan.AllowUserToDeleteRows = false;
            }

            private void SetupEventHandlers()
            {
                dataGridViewHoaDonBan.CellClick += dataGridViewHoaDonBan_CellClick;
                buttonThem.Click += buttonThem_Click;
                buttonSua.Click += buttonSua_Click;
                buttonXoa.Click += buttonXoa_Click;
                buttonThoat.Click += buttonThoat_Click;
                this.Load += FormHoaDonBan_Load;
            this.buttonExport.Click += new System.EventHandler(this.button1_Click);
        }

            private void FormHoaDonBan_Load(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Maximized;
                LoadChiTietHoaDon();
                LoadNhanVien();
                LoadKhachHang();
                LoadData();
            }

            // Load dữ liệu hóa đơn bán
            private void LoadData()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        // Đã sửa tên bảng và đảm bảo tên cột đúng
                        string sql = @"SELECT h.ID,
                                             h.ID_ChiTietHoaDonBan,
                                             hh.TenHang,
                                             h.ID_NhanVien,
                                             nv.Ten as TenNhanVien,
                                             h.ID_KhachHang,
                                             kh.Ten as TenKhachHang
                                       FROM HoaDonBan h
                                       LEFT JOIN ChiTietHoaDonBan1 ct ON h.ID_ChiTietHoaDonBan = ct.ID
                                       LEFT JOIN HangHoa hh ON ct.ID_HangHoa = hh.ID
                                       LEFT JOIN NhanVien1 nv ON h.ID_NhanVien = nv.ID
                                       LEFT JOIN KhachHang kh ON h.ID_KhachHang = kh.ID
                                       ORDER BY h.ID";

                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtHoaDonBan = new DataTable();
                    da.Fill(dtHoaDonBan);
                    dataGridViewHoaDonBan.DataSource = dtHoaDonBan;

                    UpdateStatusLabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load ComboBox Chi Tiết Hóa Đơn (sẽ hiển thị tên hàng)
            private void LoadChiTietHoaDon()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        // Tên bảng đã được sửa thành ChiTietHoaDonBan
                        string sql = @"SELECT ct.ID,
                                             CONCAT(hh.TenHang, ' (SL: ', ct.SoLuong, ')') as DisplayText
                                       FROM ChiTietHoaDonBan1 ct
                                       INNER JOIN HangHoa hh ON ct.ID_HangHoa = hh.ID
                                       ORDER BY hh.TenHang";

                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Thêm dòng trống
                        DataRow emptyRow = dt.NewRow();
                        emptyRow["ID"] = 0;
                        emptyRow["DisplayText"] = "-- Chọn chi tiết hóa đơn --";
                        dt.Rows.InsertAt(emptyRow, 0);

                        comboBoxMaChiTietHoaDon.DataSource = dt;
                        comboBoxMaChiTietHoaDon.DisplayMember = "DisplayText";
                        comboBoxMaChiTietHoaDon.ValueMember = "ID";
                        comboBoxMaChiTietHoaDon.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load ComboBox Nhân Viên
            private void LoadNhanVien()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        // Tên bảng đã được sửa thành NhanVien
                        string sql = "SELECT ID, Ten FROM NhanVien1 ORDER BY Ten";
                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Thêm dòng trống
                        DataRow emptyRow = dt.NewRow();
                        emptyRow["ID"] = 0;
                        emptyRow["Ten"] = "-- Chọn nhân viên --";
                        dt.Rows.InsertAt(emptyRow, 0);

                        comboBoxMaNhanVien.DataSource = dt;
                        comboBoxMaNhanVien.DisplayMember = "Ten";
                        comboBoxMaNhanVien.ValueMember = "ID";
                        comboBoxMaNhanVien.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load ComboBox Khách Hàng
            private void LoadKhachHang()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        // Tên bảng đã được sửa thành KhachHang
                        string sql = "SELECT ID, Ten FROM KhachHang ORDER BY Ten";
                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Thêm dòng trống
                        DataRow emptyRow = dt.NewRow();
                        emptyRow["ID"] = 0;
                        emptyRow["Ten"] = "-- Chọn khách hàng --";
                        dt.Rows.InsertAt(emptyRow, 0);

                        comboBoxMaKhachHang.DataSource = dt;
                        comboBoxMaKhachHang.DisplayMember = "Ten";
                        comboBoxMaKhachHang.ValueMember = "ID";
                        comboBoxMaKhachHang.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Làm sạch các input
            private void ClearInputs()
            {
                textBoxMaHoaDon.Text = "";

                if (comboBoxMaChiTietHoaDon.Items.Count > 0)
                    comboBoxMaChiTietHoaDon.SelectedIndex = 0;

                if (comboBoxMaNhanVien.Items.Count > 0)
                    comboBoxMaNhanVien.SelectedIndex = 0;

                if (comboBoxMaKhachHang.Items.Count > 0)
                    comboBoxMaKhachHang.SelectedIndex = 0;

                dataGridViewHoaDonBan.ClearSelection();
            }

            // Kiểm tra dữ liệu đầu vào
            private bool ValidateInputs()
            {
                if (comboBoxMaChiTietHoaDon.SelectedValue == null ||
                    Convert.ToInt32(comboBoxMaChiTietHoaDon.SelectedValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết hóa đơn!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxMaChiTietHoaDon.Focus();
                    return false;
                }

                if (comboBoxMaNhanVien.SelectedValue == null ||
                    Convert.ToInt32(comboBoxMaNhanVien.SelectedValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxMaNhanVien.Focus();
                    return false;
                }

                if (comboBoxMaKhachHang.SelectedValue == null ||
                    Convert.ToInt32(comboBoxMaKhachHang.SelectedValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxMaKhachHang.Focus();
                    return false;
                }

                return true;
            }

            // Update status label
            private void UpdateStatusLabel()
            {
                if (dataGridViewHoaDonBan.DataSource is DataTable dt)
                {
                    // Nếu có label status thì cập nhật
                    // labelStatus.Text = $"Tổng số: {dt.Rows.Count} hóa đơn";
                }
            }

            // Thêm hóa đơn mới
            private void buttonThem_Click(object sender, EventArgs e)
            {
                if (!ValidateInputs()) return;

                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        conn.Open();

                        // Sửa tên bảng và cột trong SQL
                        string sql = @"INSERT INTO HoaDonBan (ID_ChiTietHoaDonBan, ID_NhanVien, ID_KhachHang)
                                       VALUES (@ID_ChiTietHoaDonBan, @ID_NhanVien, @ID_KhachHang)";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ID_ChiTietHoaDonBan", comboBoxMaChiTietHoaDon.SelectedValue);
                        cmd.Parameters.AddWithValue("@ID_NhanVien", comboBoxMaNhanVien.SelectedValue);
                        cmd.Parameters.AddWithValue("@ID_KhachHang", comboBoxMaKhachHang.SelectedValue);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thành công!", "Thành công",
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                            comboBoxMaChiTietHoaDon.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm hóa đơn!", "Lỗi",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    string errorMessage = GetFriendlyErrorMessage(sqlEx);
                    MessageBox.Show(errorMessage, "Lỗi cơ sở dữ liệu",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Sửa hóa đơn
            private void buttonSua_Click(object sender, EventArgs e)
            {
                if (dataGridViewHoaDonBan.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để sửa!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInputs()) return;

                int id = Convert.ToInt32(dataGridViewHoaDonBan.CurrentRow.Cells["ID"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        conn.Open();

                        // Sửa tên bảng và cột trong SQL
                        string sql = @"UPDATE HoaDonBan SET
                                             ID_ChiTietHoaDonBan=@ID_ChiTietHoaDonBan,
                                             ID_NhanVien=@ID_NhanVien,
                                             ID_KhachHang=@ID_KhachHang
                                       WHERE ID=@ID";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ID_ChiTietHoaDonBan", comboBoxMaChiTietHoaDon.SelectedValue);
                        cmd.Parameters.AddWithValue("@ID_NhanVien", comboBoxMaNhanVien.SelectedValue);
                        cmd.Parameters.AddWithValue("@ID_KhachHang", comboBoxMaKhachHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@ID", id);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công",
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật hóa đơn!", "Lỗi",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    string errorMessage = GetFriendlyErrorMessage(sqlEx);
                    MessageBox.Show(errorMessage, "Lỗi cơ sở dữ liệu",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Xóa hóa đơn
            private void buttonXoa_Click(object sender, EventArgs e)
            {
                if (dataGridViewHoaDonBan.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dataGridViewHoaDonBan.CurrentRow.Cells["ID"].Value);
                string tenKhach = dataGridViewHoaDonBan.CurrentRow.Cells["TenKhachHang"].Value?.ToString() ?? "";
                string tenHang = dataGridViewHoaDonBan.CurrentRow.Cells["TenHang"].Value?.ToString() ?? "";

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa hóa đơn ID: {id}?\n" +
                    $"Khách hàng: {tenKhach}\n" +
                    $"Hàng hóa: {tenHang}\n\n" +
                    "Lưu ý: Hành động này không thể hoàn tác!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(Nguon))
                        {
                            conn.Open();

                            // Sửa tên bảng trong SQL
                            string deleteSql = "DELETE FROM HoaDonBan WHERE ID=@ID";
                            SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
                            deleteCmd.Parameters.AddWithValue("@ID", id);

                            int deleteResult = deleteCmd.ExecuteNonQuery();

                            if (deleteResult > 0)
                            {
                                MessageBox.Show("Xóa hóa đơn thành công!", "Thành công",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                ClearInputs();
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa hóa đơn!", "Lỗi",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        string errorMessage = GetFriendlyErrorMessage(sqlEx);
                        MessageBox.Show(errorMessage, "Lỗi cơ sở dữ liệu",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Thoát form
            private void buttonThoat_Click(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                                                         "Xác nhận thoát",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            // Khi click vào DataGridView
            private void dataGridViewHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewHoaDonBan.Rows.Count)
                {
                    try
                    {
                        DataGridViewRow row = dataGridViewHoaDonBan.Rows[e.RowIndex];

                        // Hiển thị ID hóa đơn
                        textBoxMaHoaDon.Text = row.Cells["ID"].Value?.ToString() ?? "";

                        // Đã sửa tên cột
                        if (row.Cells["ID_ChiTietHoaDonBan"].Value != null &&
                            row.Cells["ID_ChiTietHoaDonBan"].Value != DBNull.Value)
                        {
                            comboBoxMaChiTietHoaDon.SelectedValue = row.Cells["ID_ChiTietHoaDonBan"].Value;
                        }

                        if (row.Cells["ID_NhanVien"].Value != null &&
                            row.Cells["ID_NhanVien"].Value != DBNull.Value)
                        {
                            comboBoxMaNhanVien.SelectedValue = row.Cells["ID_NhanVien"].Value;
                        }

                        if (row.Cells["ID_KhachHang"].Value != null &&
                            row.Cells["ID_KhachHang"].Value != DBNull.Value)
                        {
                            comboBoxMaKhachHang.SelectedValue = row.Cells["ID_KhachHang"].Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Helper method cho error messages
            private string GetFriendlyErrorMessage(SqlException sqlEx)
            {
                switch (sqlEx.Number)
                {
                    case 2: // Connection timeout
                        return "Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra kết nối mạng.";
                    case 18: // Login failed
                        return "Đăng nhập cơ sở dữ liệu thất bại. Vui lòng kiểm tra thông tin đăng nhập.";
                    case 547: // Foreign key constraint
                        return "Vi phạm ràng buộc khóa ngoại. Dữ liệu liên quan có thể đã bị xóa hoặc không tồn tại.";
                    case 2627: // Unique constraint
                        return "Dữ liệu bị trùng lặp. Vui lòng kiểm tra lại thông tin.";
                    case 515: // Cannot insert null
                        return "Thiếu thông tin bắt buộc. Vui lòng điền đầy đủ thông tin.";
                    case 8152: // String truncation
                        return "Dữ liệu quá dài so với yêu cầu của cơ sở dữ liệu.";
                    default:
                        return $"Lỗi cơ sở dữ liệu: {sqlEx.Message}";
                }
            }

            // Tìm kiếm hóa đơn (optional)
            public void SearchHoaDon(string searchTerm)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Nguon))
                    {
                        // Sửa tên bảng trong SQL
                        string sql = @"SELECT h.ID,
                                         h.ID_ChiTietHoaDonBan,
                                         hh.TenHang,
                                         h.ID_NhanVien,
                                         nv.Ten as TenNhanVien,
                                         h.ID_KhachHang,
                                         kh.Ten as TenKhachHang
                                   FROM HoaDonBan h
                                   LEFT JOIN ChiTietHoaDonBan ct ON h.ID_ChiTietHoaDonBan = ct.ID
                                   LEFT JOIN HangHoa hh ON ct.ID_HangHoa = hh.ID
                                   LEFT JOIN NhanVien nv ON h.ID_NhanVien = nv.ID
                                   LEFT JOIN KhachHang kh ON h.ID_KhachHang = kh.ID
                                   WHERE h.ID LIKE @SearchTerm OR kh.Ten LIKE @SearchTerm OR nv.Ten LIKE @SearchTerm
                                   ORDER BY h.ID";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewHoaDonBan.DataSource = dt;

                        UpdateStatusLabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Refresh dữ liệu
            public void RefreshData()
            {
                LoadChiTietHoaDon();
                LoadNhanVien();
                LoadKhachHang();
                LoadData();
                ClearInputs();
            }

            private void textBoxMaHoaDon_TextChanged(object sender, EventArgs e)
            {

            }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void TimKiemHoaDonBan()
        {
            if (dtHoaDonBan == null) return;

            string tuKhoa = textBoxTimKiem.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewHoaDonBan.DataSource = dtHoaDonBan; // hiển thị lại toàn bộ
            }
            else
            {
                DataView dv = new DataView(dtHoaDonBan  );
                dv.RowFilter = $"TenNhanVien LIKE '%{tuKhoa}%' ";
                dataGridViewHoaDonBan.DataSource = dv;
            }
        }
        private void ExportExcel(string path)
        {
            Excle.Application application = new Excle.Application();
            application.Application.Workbooks.Add(Type.Missing);

            Excle._Worksheet worksheet = (Excle._Worksheet)application.ActiveSheet;

            // ===== 1. Thêm tiêu đề lớn =====
            worksheet.Cells[1, 1] = "Hóa Đơn Bán";
            worksheet.Range["A1:E1"].Merge(); // gộp ô từ A1 đến E1 (sửa E thành cột cuối cùng của bạn)
            worksheet.Range["A1"].Font.Size = 16;
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].HorizontalAlignment = Excle.XlHAlign.xlHAlignCenter;



            int startRow = 5; // dòng bắt đầu cho header bảng

            // ===== 3. Xuất tiêu đề cột =====
            for (int i = 0; i < dataGridViewHoaDonBan.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dataGridViewHoaDonBan.Columns[i].HeaderText;
            }

            // ===== 4. Xuất dữ liệu =====
            for (int i = 0; i < dataGridViewHoaDonBan.Rows.Count; i++)
            {
                if (dataGridViewHoaDonBan.Rows[i].IsNewRow) continue;

                for (int j = 0; j < dataGridViewHoaDonBan.Columns.Count; j++)
                {
                    var value = dataGridViewHoaDonBan.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + startRow + 1, j + 1] = value == null ? "" : value.ToString();
                }
            }

            //// ===== 5. Xuất tổng tiền ở cuối =====
            //int lastRow = startRow + dgvThongKe.Rows.Count + 1;
            //worksheet.Cells[lastRow, 1] = lblTongTien.Text;
            //worksheet.Range[$"A{lastRow}:E{lastRow}"].Font.Bold = true;

            // ===== 6. Định dạng bảng =====
            worksheet.Columns.AutoFit();
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewHoaDonBan.Columns.Count]].Font.Bold = true;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dataGridViewHoaDonBan.Columns.Count]].Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            // ===== 7. Thêm border bao quanh vùng dữ liệu =====
            int lastRow = startRow + dataGridViewHoaDonBan.Rows.Count - 1; // tính số dòng cuối

            Excle.Range usedRange = worksheet.Range[
     worksheet.Cells[startRow, 1],
     worksheet.Cells[lastRow, dataGridViewHoaDonBan.Columns.Count]
 ];

            usedRange.Borders.LineStyle = Excle.XlLineStyle.xlContinuous;
            usedRange.Borders.Weight = Excle.XlBorderWeight.xlThin;

            // ===== 8. Lưu file =====
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        //private void buttonExport_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Title = "Excel File";
        //    saveFileDialog.Filter = "Excel File|*.xlsx;*.xls;*.xlsm";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            ExportExcel(saveFileDialog.FileName);
        //            MessageBox.Show("Xuất file thành công");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi: " + ex.Message);
        //        }
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
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