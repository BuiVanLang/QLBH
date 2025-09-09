using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormThongKeTheoDonHang : Form
    {
        private readonly string Nguon = @"Data Source=BuiVanLang;Initial Catalog=QLBH3;Integrated Security=True";

        public FormThongKeTheoDonHang()
        {
            InitializeComponent();
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

    }
}
