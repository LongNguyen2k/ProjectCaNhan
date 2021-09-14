using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EFDatabaseFirst.DAO
{
    class DAO_DonHang
    {
        NorthwindEntitiesNew db;
        public DAO_DonHang()
        {
            db = new NorthwindEntitiesNew();
        }

        public dynamic LayDSDonHang()
        {
            return db.Orders.Select(s => new
            {
                s.OrderID,
                s.OrderDate,
                s.Customer.CompanyName,
                s.Employee.LastName

            }).ToList();
        }

        public dynamic LayDSCTDonHang(int maDH)
        {
            var ds = db.OrderDetails.Where(s => s.OrderID == maDH)
                    .Select(s => new
                    {
                        s.OrderID , 
                        s.Product.ProductName , 
                        s.UnitPrice,
                        s.Quantity

                    }).ToList();
            return ds;
        }

        public dynamic LayDSKH()
        {
            var ds = db.Customers.Select(s => new {
                s.CustomerID,
                s.CompanyName }).ToList();
            return ds;
        }
        public dynamic LayDSNV()
        {
            var ds = db.Employees.Select(s => new { s.EmployeeID, s.LastName }).ToList();
            return ds;
        }
        public void ThemDH(Order d)
        {
            db.Orders.Add(d);
            db.SaveChanges();
        }

        public Boolean KiemTraDonHang(Order d)
        {
            Order o = db.Orders.Find(d.OrderID);
            if (o != null)
            {
                return true;
            }
            else
                return false;

        }

        public void SuaDH(Order donHang)
        {

            Order d = db.Orders.Find(donHang.OrderID);
            d.OrderDate = donHang.OrderDate;
            d.CustomerID = donHang.CustomerID;
            d.EmployeeID = donHang.EmployeeID;
            db.SaveChanges();

        }

        public void XoaDH(Order donHang)
        {

            Order d = db.Orders.Find(donHang.OrderID);
            db.Orders.Remove(d);
            db.SaveChanges();

        }

        public bool KiemTraSPDH(OrderDetail d)
        {
            int? sl;
            sl = db.sp_KiemTraSanPhamDonHang(d.OrderID, d.ProductID).FirstOrDefault();
            if (sl != 0)
                return false;
            return true;

        }

        public void ThemCTDH(OrderDetail d)
        {
          
            db.OrderDetails.Add(d);
            db.SaveChanges();
        }

    }

}
