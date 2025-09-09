using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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

        private void danhMucToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form frm = null;

            switch (e.ClickedItem.Name)
            {
                case "MenuNhanVien":
                    frm = new FormNhanVien();
                    break;
                case "MenuKhachHang":
                    frm = new FormKhachHang();
                    break;
                case "MenuChatLieu":
                    frm = new FormChatLieu();
                    break;
                case "MenuHangHoa":
                    frm = new FormHangHoa();
                    break;
            }

            if (frm != null)
            {
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void hóaĐơnToolStripMenuItem_DropDownItemClicked(object sender, EventArgs e)
        {
            Form frm = null;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;
            if (args == null) return;
            switch (args.ClickedItem.Name)
            {
                case "MenuChiTietHoaDonBanHang":
                    frm = new FormChiTietHoaDonBan();
                    break;
                case "MenuHoaDonBanHang":
                    frm = new FormHoaDonBan();
                    break;
            }

            if (frm != null)
            {
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.BringToFront();
            }

        }
        private void báoCáoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form frm = null;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;
            if (args == null) return;
            switch (e.ClickedItem.Name)
            {
                case "MenuThongKeTheoNhanVien":
                    frm = new FormThongKeTheoNhanVien();
                    break;
                case "MenuThongKeTheoDonHang":
                    frm = new FormThongKeTheoDonHang();
                    break;
            }

            if (frm != null)
            {
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }
    }
    }
    

