using EFDatabaseFirst.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDatabaseFirst.BUS
{
    class BUS_SanPham
    {
        DAO_SanPham dSanPham;
        public BUS_SanPham()
        {
            dSanPham = new DAO_SanPham();
        }
        public void LayDSSanPham(DataGridView dg)
        {
            dg.DataSource = dSanPham.LayDSSanPham();

        }

        public   List<Product> LayDSSanPham()
        {
            return  dSanPham.LayDSSanPhamRePort();

        }

        public void HienThiDSSP(ComboBox cb)
        {
            cb.DataSource = dSanPham.LayDSSanPham();
            cb.DisplayMember = "ProductName";
            cb.ValueMember = "ProductID";
        }
        public void LayDSLoaiSP(ComboBox cb)
        {
            cb.DataSource = dSanPham.LayDSLoaiSP();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }
        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = dSanPham.LayDSNCC();
            cb.DisplayMember = "companyName";
            cb.ValueMember = "SupplierID";
        }

        public Product LayThongTinSP(int maSP)
        {
            // check if maSP is existed

            return dSanPham.LayThongTinSP(maSP);
        }
    }
}
