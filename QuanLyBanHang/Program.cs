using System;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chỉ mở FormTaiKhoan để lấy kết quả đăng nhập
            using (FormTaiKhoan dn = new FormTaiKhoan())
            {
                if (dn.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công thì chạy form chính
                    Application.Run(new Form11());
                }
                else
                {
                    // Nếu đăng nhập thất bại hoặc bấm thoát
                    Application.Exit();
                }
            }
        }
    }
}
