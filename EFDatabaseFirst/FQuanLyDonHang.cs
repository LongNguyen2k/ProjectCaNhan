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
    public partial class FQuanLyDonHang : Form
    {
        BUS_DonHang bDH;
        public FQuanLyDonHang()
        {
            bDH = new BUS_DonHang();
            InitializeComponent();
        }

        private void FQuanLyDonHang_Load(object sender, EventArgs e)
        {
            HienThiDSDonHang();
            bDH.LayDSKH(cbKhachHang);
            bDH.LayDSNV(cbNhanVien);

        }
        private void HienThiDSDonHang()
        {
            gVDH.DataSource = null;
            bDH.HienThiDSDonHang(gVDH);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.25 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.25 * gVDH.Width);
        }
        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            { 
                txtMaDH.Enabled = false;
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderId"].Value.ToString();
                dtpNgayDatHang.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order donhang = new Order();
            donhang.OrderDate = dtpNgayDatHang.Value; 
            donhang.EmployeeID = Int32.Parse(cbNhanVien.SelectedValue.ToString());
            donhang.CustomerID = cbKhachHang.SelectedValue.ToString();
            

            if(bDH.ThemDonHang(donhang))
            {
                MessageBox.Show("Thêm đơn hàng thành công");
                bDH.HienThiDSDonHang(gVDH);
            }
            else
            {
                MessageBox.Show("Thêm đơn hàng thất bại");
            }
            
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order oD = new Order();
            oD.OrderID = int.Parse(txtMaDH.Text.ToString());
            oD.OrderDate = dtpNgayDatHang.Value;
            oD.CustomerID = cbKhachHang.SelectedValue.ToString();
            oD.EmployeeID = Int32.Parse(cbNhanVien.SelectedValue.ToString());

            if (bDH.suaDonHang(oD))
            {
                MessageBox.Show("Sửa Đơn Hàng Thành Công !");
                bDH.HienThiDSDonHang(gVDH);
            }
            else
            {
                MessageBox.Show("Sửa Đơn Hàng Thất bẠI !");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Order d = new Order();
            d.OrderID = int.Parse(txtMaDH.Text);
            if (bDH.xoaDonHang(d))
            {
                MessageBox.Show("Xóa Đơn Hàng Thành Công !");
                bDH.HienThiDSDonHang(gVDH);
            }
            else
                MessageBox.Show("Xóa Đơn Hàng Thất Bại !");
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int maDonHang;
            maDonHang = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            FChiTietDonHang f = new FChiTietDonHang();
            f.maDH = maDonHang;
            f.ShowDialog();

        }
    }
}
