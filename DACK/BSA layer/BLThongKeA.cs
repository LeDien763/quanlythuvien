using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLThongKeA
    {
        public DataSet LayDocGia()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var dgs = from p in qLTVEntities.tbDGs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Tên đọc giả");
            dt.Columns.Add("Chức vụ");
            dt.Columns.Add("Lớp");
            dt.Columns.Add("Khoa");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Ghi chú");
            foreach (var p in dgs)
            {
                dt.Rows.Add(p.MaDG, p.TenDG, p.ChucVu, p.Lop, p.Khoa, p.NgaySinh, p.GioiTinh, p.GhiChu);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public int DemSoLuongSach()
        {   
            QLTVEntities qLTVEntities = new QLTVEntities();
            int count = qLTVEntities.tbDauSaches.Sum(ds => ds.SoLuong);
            return count;
        }
        public int DemSoLuongSachChuaTra()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            DateTime currentDate = DateTime.Now.Date;
            int count = qLTVEntities.tbPhieuMuons.AsEnumerable().Count(p => DateTime.Parse(p.NgayTra) > currentDate);
            return count;
        }
        public int DemSoLuongSachDaTra()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            DateTime currentDate = DateTime.Now.Date;
            int count = qLTVEntities.tbPhieuMuons.AsEnumerable()
                            .Count(p => DateTime.Parse(p.NgayTra) < currentDate);
            return count;
        }


        public int DemSoDocGia()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            int count = qLTVEntities.tbDGs.Count();
            return count;
        }
        public int DemSoNXB()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            int count = qLTVEntities.tbNXBs.Count();
            return count;
        }
        public int DemPhieuMuon()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            int count = qLTVEntities.tbPhieuMuons.Count();
            return count;
        }
        public int DemSoTacGia()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            int count = qLTVEntities.tbTGs.Count();
            return count;
        }
        public DataSet LayPhieuQuaHan()
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                DateTime currentDate = DateTime.Today;
                var query = from pm in qLTVEntities.tbPhieuMuons
                            join the in qLTVEntities.tbThes on pm.MaThe equals the.MaThe
                            
                            select new
                            {
                                the.MaDG,
                                the.MaThe,
                                pm.MaDauSach,
                                pm.NgayMuon,
                                pm.NgayTra
                            };
                var filteredQuery = query.AsEnumerable()
                         .Where(pm => DateTime.Parse(pm.NgayTra) > currentDate);
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Mã đầu sách");
                dt.Columns.Add("Ngày mượn");
                dt.Columns.Add("Ngày trả");

                foreach (var p in filteredQuery)
                {
                    dt.Rows.Add(p.MaDG, p.MaThe, p.MaDauSach, p.NgayMuon, p.NgayTra);
                }
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(dt);

                return dataSet;
            }
        }
        public DataSet LayPhieuDaTra()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            DateTime currentDate = DateTime.Today;

            var query = from pm in qLTVEntities.tbPhieuMuons
                        join the in qLTVEntities.tbThes on pm.MaThe equals the.MaThe
                        select new
                        {
                            MaDG = the.MaDG,
                            MaThe = the.MaThe,
                            MaDauSach = pm.MaDauSach,
                            NgayMuon = pm.NgayMuon,
                            NgayTra = pm.NgayTra
                        };
            var filteredQuery = query.AsEnumerable()
                         .Where(pm => DateTime.Parse(pm.NgayTra) < currentDate);


            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đầu sách");
            dt.Columns.Add("Ngày mượn");
            dt.Columns.Add("Ngày trả");

            foreach (var p in filteredQuery)
            {
                dt.Rows.Add(p.MaDG, p.MaThe, p.MaDauSach, p.NgayMuon, p.NgayTra);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            return ds;
        }

    }
}
