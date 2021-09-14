using EFDatabaseFirst.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDatabaseFirst
{
    public partial class FChiTietDonHang : Form
    {
        public int maDH;
        BUS_DonHang bDH;
        public FChiTietDonHang()
        {
            bDH = new BUS_DonHang();
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FCTDatHang f = new FCTDatHang();
            f.maDonHang = this.maDH;
            f.ShowDialog();
        }

        private void FChiTietDonHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachCTDH();
        }

        private void HienThiDanhSachCTDH()
        {
            gVChiTietDonHang.DataSource = null;
            bDH.LayDSCTDH(gVChiTietDonHang, maDH);
            gVChiTietDonHang.Columns[0].Width = (int)(0.2 * gVChiTietDonHang.Width);
            gVChiTietDonHang.Columns[1].Width = (int)(0.2 * gVChiTietDonHang.Width);
            gVChiTietDonHang.Columns[2].Width = (int)(0.25 * gVChiTietDonHang.Width);
            gVChiTietDonHang.Columns[3].Width = (int)(0.25 * gVChiTietDonHang.Width);
        }

        private void FChiTietDonHang_Activated(object sender, EventArgs e)
        {
            HienThiDanhSachCTDH();
        }
    }
}
