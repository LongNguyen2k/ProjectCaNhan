using EFDatabaseFirst.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace EFDatabaseFirst.BUS
{
    class BUS_DonHang
    {
        DAO_DonHang da;
        public BUS_DonHang()
        { 
            // goi doi tuong dao 
            da = new DAO_DonHang();
        }
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = da.LayDSDonHang();
        }
        public void LayDSCTDH(DataGridView dg , int maDH)
        {
            dg.DataSource = da.LayDSCTDonHang(maDH);    
        }
        public void HienThiDSDonHang(DataGridView dg)
        {
            dg.DataSource = da.LayDSDonHang();
        }
        public void LayDSKH(ComboBox cb)
        {
            cb.DataSource = da.LayDSKH();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "CustomerID";
        }
        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = da.LayDSNV();
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
        }
        public bool ThemDonHang(Order d)
        {
            try
            {
                da.ThemDH(d);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public bool suaDonHang(Order d)
        {
            try
            {
                da.SuaDH(d);
                return true;
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool xoaDonHang(Order d)
        {
            try
            {
                da.XoaDH(d);
                return true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ThemChiTietDonHang(int maDH, DataTable dtDonHang)
        {
            bool result = false;

            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (DataRow item in dtDonHang.Rows)
                    {
                        OrderDetail d = new OrderDetail();
                        d.OrderID = maDH;
                        d.ProductID = int.Parse(item[0].ToString());
                        d.UnitPrice = int.Parse(item[1].ToString());
                        d.Quantity = short.Parse(item[2].ToString());
                        d.Discount = float.Parse(item[3].ToString());
                        if (da.KiemTraSPDH(d) == true)
                        {
                            da.ThemCTDH(d);
                        }
                        else
                        {
                            throw new Exception("Sản Phẩm Đã tồn tại " + d.ProductID);
                        }
                       
                    }
                    tran.Complete();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false; // chưa xử lý giao tác 
                    MessageBox.Show(ex.Message);
                    throw;
                } 
            }
            return result;
        }
    }
    
}
