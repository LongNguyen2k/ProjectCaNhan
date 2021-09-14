using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFDatabaseFirst.BUS;
namespace EFDatabaseFirst
{
    public partial class FCTDatHang : Form
    {
        #region Biến 
        public int maDonHang;
        BUS_SanPham busSanPham;
        bool flag = false;
        DataTable dtDonHang;
        BUS_DonHang busDonHang;
        #endregion
        public FCTDatHang()
        {
            InitializeComponent();
            busSanPham = new BUS_SanPham();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DataRow dataRow;
            bool checkSP = true; 
            // Kiem tra SP co trong dataTable hay chua 
            foreach (DataRow item in dtDonHang.Rows)
            {
                if (cbSP.SelectedValue.ToString() == item[0].ToString())
                {
                    // Cap nhat so luong 
                    item[2] = int.Parse(item[2].ToString()) + numSoLuong.Value;
                    checkSP = false;
                    break;
                }
               
            }
            if (checkSP == true)
            {
                dataRow = dtDonHang.NewRow();
                dataRow[0] = Int32.Parse(cbSP.SelectedValue.ToString());
                dataRow[1] = Int32.Parse(txtDonGia.Text.Replace(".", ""));
                dataRow[2] = Convert.ToInt32(numSoLuong.Value);
                dataRow[3] = float.Parse(txtGiamGia.Text);
                dtDonHang.Rows.Add(dataRow);
            }
           
        }

        private void FCTDatHang_Load(object sender, EventArgs e)
        {
            // Hiển thị danh sách sản phẩm ra cb
            busSanPham.HienThiDSSP(cbSP);
            flag = true;
            // hien thi ma don hang 
            txtMaDH.Text = maDonHang.ToString();
            // hien thi tren datagridview productid , unitprice , quantity ,discount
            dtDonHang = new DataTable();
            dtDonHang.Columns.Add("ProductID");
            dtDonHang.Columns.Add("UnitPrice");
            dtDonHang.Columns.Add("Quantity");
            dtDonHang.Columns.Add("Discount");
            dGSP.DataSource = dtDonHang;
            // Dinh Dang 4 cot cho view 
            dGSP.Columns[0].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[1].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[2].Width = (int)(0.25 * dGSP.Width);
            dGSP.Columns[3].Width = (int)(0.25 * dGSP.Width);
        }
        // chon 1 san pham se hien thi thong tin san pham 
        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dựa vào mã láy thông tin sản phẩm 
            Product p;
            if (flag)
            {
                int maSP = int.Parse(cbSP.SelectedValue.ToString());
                p = busSanPham.LayThongTinSP(maSP);
                // hien thi 
                txtLoaiSP.Text = p.Category.CategoryName.ToString();
                txtNhaCC.Text = p.Supplier.CompanyName.ToString();
                txtDonGia.Text = p.UnitPrice.ToString(); 
            }

        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            busDonHang = new BUS_DonHang();
            if (busDonHang.ThemChiTietDonHang(maDonHang, dtDonHang))
            { 
                MessageBox.Show("Đặt Hàng Thành Công !");
                Close();
            }
            else
                MessageBox.Show("Đặt Hàng thất bại !");
        }
    }
}
