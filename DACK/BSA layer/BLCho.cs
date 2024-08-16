using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLCho
    {
        public DataSet LaySach()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var query = from the in qLTVEntities.tbThes
                        join cd in qLTVEntities.tbChoDuyets on the.MaThe equals cd.MaThe
                        select new
                        {
                            MaPhieu=cd.MaPhieu,MaThe=cd.MaThe,MaDG=the.MaDG,MaDauSach=cd.MaDauSach,
                        };

            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Phiếu");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mã đầu sách");

            foreach (var p in query)
            {
                dt.Rows.Add(p.MaPhieu, p.MaThe, p.MaDG, p.MaDauSach);
            }

            dataSet.Tables.Add(dt);

            return dataSet;
        }

        public bool ThemPhieu(string MaPhieu, string MaThe, string MaDauSach, bool TinhTrang, string Thongbao, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbChoDuyet cd =new tbChoDuyet();
            cd.MaThe = MaThe;
            cd.MaDauSach = MaDauSach;
            cd.MaPhieu = MaPhieu;
            cd.ThongBao = Thongbao;
            cd.TinhTrang = TinhTrang;
            qLTVEntities.tbChoDuyets.Add(cd);
            qLTVEntities.SaveChanges();
            return false;
        }
        public bool ThemPhieuMuonDD(string MaPhieu, string MaDauSach, string MaThe, string NgayMuon, string NgayTra, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbPhieuMuon pm = new tbPhieuMuon();
            pm.MaPhieu= MaPhieu;
            pm.MaDauSach= MaDauSach;
            pm.MaThe= MaThe;
            pm.NgayMuon= NgayMuon;
            pm.NgayTra= NgayTra;

            qLTVEntities.tbPhieuMuons.Add(pm);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool XoaPhieu(string MaPhieu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbChoDuyet cd = new tbChoDuyet();
            cd.MaPhieu = MaPhieu;
            qLTVEntities.tbChoDuyets.Attach(cd);
            qLTVEntities.tbChoDuyets.Remove(cd);
            qLTVEntities.SaveChanges();
            return true;
        }
        public DataSet TimKiemMP(string MaPhieu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var query = from the in qLTVEntities.tbThes
                        join cd in qLTVEntities.tbChoDuyets on the.MaThe equals cd.MaThe
                        where cd.MaPhieu.Contains(MaPhieu)
                        select new
                        {
                            cd.MaPhieu,
                            cd.MaThe,
                            the.MaDG,
                            cd.MaDauSach
                        };

            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mã đầu sách");

            foreach (var p in query)
            {
                dt.Rows.Add(p.MaPhieu, p.MaThe, p.MaDG, p.MaDauSach);
            }

            dataSet.Tables.Add(dt);

            return dataSet;
        }

        public DataSet TimKiemMDP(string MaThe, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var query = from the in qLTVEntities.tbThes
                        join cd in qLTVEntities.tbChoDuyets on the.MaThe equals cd.MaThe
                        where the.MaDG.Contains(MaThe)
                        select new
                        {
                            cd.MaPhieu,
                            cd.MaThe,
                            the.MaDG,
                            cd.MaDauSach
                        };

            DataTable dt = new DataTable();
            
            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mã đầu sách");

            foreach (var p in query)
            {
                dt.Rows.Add(p.MaPhieu, p.MaThe, p.MaDG, p.MaDauSach);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public DataSet TimKiemMTUse(string MaDG, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var query = from the in qLTVEntities.tbThes
                        join cd in qLTVEntities.tbChoDuyets on the.MaThe equals cd.MaThe
                        where the.MaDG==MaDG
                        select new
                        {
                            cd.MaPhieu,
                            cd.MaThe,
                            the.MaDG,
                            cd.MaDauSach
                        };

            DataTable dt = new DataTable();

            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mã đầu sách");

            foreach (var p in query)
            {
                dt.Rows.Add(p.MaPhieu, p.MaThe, p.MaDG, p.MaDauSach);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        private int soluong;
        public int LaySoLuong(string MaDauSach, ref string err)
        {
             soluong = 0;

            try
            {
                using (var qLTVEntities = new QLTVEntities())
                {
                    var dauSach = qLTVEntities.tbDauSaches.FirstOrDefault(ds => ds.MaDauSach == MaDauSach);

                    if (dauSach != null)
                    {
                        soluong = dauSach.SoLuong;
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return soluong;
        }
        public bool UpdateSoLuong(string MaDauSach, int SoLuong, ref string err)
        {
            try
            {
                using (var qLTVEntities = new QLTVEntities()) 
                {
                    var dauSach = qLTVEntities.tbDauSaches.FirstOrDefault(ds => ds.MaDauSach == MaDauSach);

                    if (dauSach != null)
                    {
                        dauSach.SoLuong = SoLuong;
                        qLTVEntities.SaveChanges();
                        return true;
                    }
                    else
                    {
                        err = "DauSach not found.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}
