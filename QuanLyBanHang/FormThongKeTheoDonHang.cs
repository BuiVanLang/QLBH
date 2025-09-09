using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormThongKeTheoDonHang : Form
    {
        private readonly string connectionString = @"Server=BuiVanLang;Database=QLBH3;Integrated Security=True;";

        public FormThongKeTheoDonHang()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                  
  SELECT
    hdb.ID AS MaHoaDon,
    nv.Ten AS TenNhanVien,
    kh.Ten AS TenKhachHang,
    ct.SoLuong AS SoLuongSanPham,
    ct.SoLuong * hh.DonGiaBan * (1 - ISNULL(ct.GiamGia,0)/100.0) AS TongTien
FROM HoaDonBan hdb
INNER JOIN NhanVien1 nv ON hdb.ID_NhanVien = nv.ID
INNER JOIN KhachHang kh ON hdb.ID_KhachHang = kh.ID
INNER JOIN ChiTietHoaDonBan1 ct ON hdb.ID_ChiTietHoaDonBan = ct.ID
INNER JOIN HangHoa hh ON ct.ID_HangHoa = hh.ID
ORDER BY hdb.ID;";


                SqlCommand cmd = new SqlCommand(query, conn);

                // Nếu để trống => xem tất cả
                if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
                {
                    cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = -1;
                }
                else
                {
                    // Lấy trực tiếp số từ TextBox
                    if (int.TryParse(txtMaHoaDon.Text.Trim(), out int maHD))
                    {
                        cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHD;
                    }
                    else
                    {
                        MessageBox.Show("Mã hóa đơn phải là số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvThongKe.DataSource = dt;
            }
        }
    }
}
