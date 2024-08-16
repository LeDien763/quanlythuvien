using DACK.BSA_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK.UseControls
{
    public partial class US_THONGKEA : UserControl
    {
        public US_THONGKEA()
        {
            InitializeComponent();
        }
        DataTable dtSach = null;
        string err;
        bool Them;
        BLThongKeA bdSach = new BLThongKeA();

        private void lbTongSach_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhSachChuTra_Click(object sender, EventArgs e)
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet ds = bdSach.LayPhieuQuaHan();
            dtSach = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            grvPhieuMuon.DataSource = dtSach;
            // Thay đổi độ rộng cột
            grvPhieuMuon.AutoResizeColumns();

            BLThongKeA blThongKe = new BLThongKeA();
            int soLuongSach = blThongKe.DemSoLuongSachChuaTra();
            lbSumTong.Text = "Số Sách Chưa Trả: " + soLuongSach;
        }

        private void US_THONGKEA_Load(object sender, EventArgs e)
        {
            BLThongKeA blThongKe = new BLThongKeA();
            int soLuongSach = blThongKe.DemSoLuongSach();
            lbTongSach.Text = "Tổng Sách: " + soLuongSach;


            BLThongKeA blThongKe1 = new BLThongKeA();
            int slDG = blThongKe1.DemSoDocGia();
            lbDoGia.Text = "Độc Giả: " + slDG;

            BLThongKeA blThongKe2 = new BLThongKeA();
            int slPhieuMuon = blThongKe2.DemPhieuMuon();
            lbphieumuon.Text = "Phiếu Mượn: " + slPhieuMuon;

            BLThongKeA blThongKe4 = new BLThongKeA();
            int slTG = blThongKe4.DemSoTacGia();
            lbTacGia.Text = "Tác Giả: " + slTG;

            BLThongKeA blThongKe5 = new BLThongKeA();
            int slnxb = blThongKe5.DemSoNXB();
            lbNXB.Text = "NXB: " + slnxb;

        }

        private void btnDSdatra_Click(object sender, EventArgs e)
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet ds = bdSach.LayPhieuDaTra();
            dtSach = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            grvPhieuMuon.DataSource = dtSach;
            // Thay đổi độ rộng cột
            grvPhieuMuon.AutoResizeColumns();


            BLThongKeA blThongKe = new BLThongKeA();
            int soLuongSach = blThongKe.DemSoLuongSachDaTra();
            lbSumTong.Text = "Số Sách Đã Trả: " + soLuongSach;
        }
    }
}
