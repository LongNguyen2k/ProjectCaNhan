using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirst.DAO
{
    
    class DAO_SanPham
    {
        NorthwindEntitiesNew db;
        public DAO_SanPham()
        {
            db = new NorthwindEntitiesNew();
        }
        public dynamic LayDSSanPham()
        {
            var ds = db.Products.Select(s => new {
                s.ProductID,
                s.ProductName,
                s.UnitPrice,
                s.UnitsInStock,
                s.Supplier.CompanyName,
                s.Category.CategoryName
            }).ToList();
            return ds;
        }

        public List<Product> LayDSSanPhamRePort()
        {
            var ds = db.Products.Select(s => s).ToList();
            return ds;
        }
        public dynamic LayDSLoaiSP()
        {
            var ds = db.Categories.Select(s => new {
                s.CategoryID,
                s.CategoryName
            }).ToList();
            return ds;
        }
        public dynamic LayDSNCC()
        {
            var ds = db.Suppliers.Select(s => new {
                s.SupplierID,
                s.CompanyName
            }).ToList();
            return ds;
        }
        public dynamic LayThongTinSanPham(int maSP)
        {
            var ds = db.Products.FirstOrDefault(s => s.ProductID == maSP);


            return ds;

        }

        public Product LayThongTinSP(int maSP)
        {
            Product p = db.Products.Where(s => s.ProductID == maSP).FirstOrDefault();
            return p;
        }
    }
}
