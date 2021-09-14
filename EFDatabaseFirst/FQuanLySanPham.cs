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
using EFDatabaseFirst.Report;
namespace EFDatabaseFirst
{
    public partial class FQuanLySanPham : Form
    {
        BUS_SanPham BusSP = new BUS_SanPham();
        public FQuanLySanPham()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void HienThiDSSanPham()
        {
            gVSanPham.DataSource = null;
            BusSP.LayDSSanPham(gVSanPham);
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.1);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.18);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[5].Width = (int)(gVSanPham.Width * 0.15);
        }
        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            
            HienThiDSSanPham();
            BusSP.LayDSLoaiSP(cbLoaiSP);
            BusSP.LayDSNCC(cbNCC);
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count - 1)
            {
                txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtSoLuong.Text = gVSanPham.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                cbLoaiSP.Text = gVSanPham.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                cbNCC.Text = gVSanPham.Rows[e.RowIndex].Cells["ComPanyName"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void taoReport_Click(object sender, EventArgs e)
        {
            cRSanPham r = new cRSanPham();
            FormReport f = new FormReport();

            r.SetDataSource( BusSP.LayDSSanPham().ToList());
            f.crystalReportViewer1.ReportSource = r;
            // lấy dữ liệu đỗ vào report
            f.Show();
        }
    }
}
