using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaiKhoan F= new FormTaiKhoan();
            this.IsMdiContainer = true;
            F.Show();
        }

       


        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien nh= new FormNhanVien();
            this.IsMdiContainer = true;
            nh.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang kh= new FormKhachHang();
            this.IsMdiContainer = true;
            kh.Show();
        }

        private void chấtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChatLieu cl= new FormChatLieu();
            this.IsMdiContainer = true;
            cl.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {FormHangHoa hh= new FormHangHoa();
            this.IsMdiContainer = true;
            hh.Show();

        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngKýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangKy t= new FormDangKy();
            this.IsMdiContainer = true;
            t.Show();
        }
       
        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChiTietHoaDonBan CT= new FormChiTietHoaDonBan();
            this.IsMdiContainer = true;
            CT.Show();
        }

      private   void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDonBan HD= new FormHoaDonBan();
            this.IsMdiContainer = true;
            HD.Show();
        }

        private void thốngKêTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongKeTheoNhanVien TK= new FormThongKeTheoNhanVien();  
            this.IsMdiContainer = true;
            TK.Show();
        }

        private void thốngKêTheoĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongKeTheoDonHang TKDH= new FormThongKeTheoDonHang();
            this.IsMdiContainer = true;
            TKDH.Show();
        }
        
    }
}
