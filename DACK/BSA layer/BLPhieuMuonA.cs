using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLPhieuMuonA
    {
        public DataSet LayPhieuMuon()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var pms = from p in qLTVEntities.tbPhieuMuons
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Mã đầu sách");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Ngày mượn");
            dt.Columns.Add("Ngày trả");
            
            foreach (var p in pms)
            {
                dt.Rows.Add(p.MaPhieu,p.MaDauSach,p.MaThe,p.NgayMuon,p.NgayTra);
            }

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool ThemPhieuMuon(string MaPhieu, string MaDauSach, string MaThe, string NgayMuon, string NgayTra, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbPhieuMuon pm = new tbPhieuMuon();
            pm.MaPhieu = MaPhieu;
            pm.MaDauSach = MaDauSach;
            pm.MaThe = MaThe;
            pm.NgayMuon = NgayMuon;
            pm.NgayTra = NgayTra;   
            qLTVEntities.tbPhieuMuons.Add(pm);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool XoaPhieuMuon(string MaPhieu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbPhieuMuon pm = new tbPhieuMuon();
            pm.MaPhieu= MaPhieu;
            qLTVEntities.tbPhieuMuons.Attach(pm);
            qLTVEntities.tbPhieuMuons.Remove(pm);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool CapNhatPhieuMuon(string MaPhieu, string MaDauSach, string MaThe, string NgayMuon, string NgayTra, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var pmQuery = (from pm in qLTVEntities.tbPhieuMuons
                           where pm.MaPhieu == MaPhieu
                           select pm).FirstOrDefault();
            if (pmQuery != null)
            {
                pmQuery.MaDauSach= MaDauSach;
                pmQuery.MaThe = MaThe; 
                pmQuery.NgayMuon= NgayMuon;
                pmQuery.NgayTra= NgayTra;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemMS(string MaDauSach, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from pm in qLTVEntities.tbPhieuMuons
                            where pm.MaDauSach.Contains(MaDauSach)
                            select pm;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phiếu");
                dt.Columns.Add("Mã sách");
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Ngày mượn");
                dt.Columns.Add("Ngày trả");

                foreach (var pm in query)
                {
                    dt.Rows.Add(pm.MaPhieu, pm.MaDauSach, pm.MaThe, pm.NgayMuon, pm.NgayTra);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemMT(string MaThe, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from pm in qLTVEntities.tbPhieuMuons
                            where pm.MaThe.Contains(MaThe)
                            select pm;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phiếu");
                dt.Columns.Add("Mã đầu sách");
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Ngày mượn");
                dt.Columns.Add("Ngày trả");

                foreach (var pm in query)
                {
                    dt.Rows.Add(pm.MaPhieu, pm.MaDauSach, pm.MaThe, pm.NgayMuon, pm.NgayTra);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemMTUse(string MaThe, ref string err)
        {
            using (var context = new QLTVEntities())
            {
                var query = from the in context.tbThes
                            join pm in context.tbPhieuMuons on the.MaThe equals pm.MaThe
                            where the.MaDG == MaThe
                            select new
                            {
                                MaPhieu=pm.MaPhieu,
                                MaDG = the.MaDG,
                                MaThe = the.MaThe,
                                MaSach = pm.MaDauSach,
                                NgayMuon = pm.NgayMuon,
                                NgayTra = pm.NgayTra
                            };

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phiếu");
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Mã sách");
                dt.Columns.Add("Ngày mượn");
                dt.Columns.Add("Ngày trả");

                foreach (var result in query)
                {
                    dt.Rows.Add(result.MaPhieu,result.MaDG, result.MaThe, result.MaSach, result.NgayMuon, result.NgayTra);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }


    }
}
