using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLPhieuPhat
    {
        private string GenerateRandomMaThe()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000001);

            string maThe = randomNumber.ToString("D6");

            return maThe;
        }
        public DataSet LayPhieuPhat()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var query = from phieuphat in qLTVEntities.phieuphats
                        select phieuphat;

            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Phiếu Phạt");
            dt.Columns.Add("Mã Thẻ");
            dt.Columns.Add("tiền trả");
            dt.Columns.Add("Thông báo");

            foreach (var p in query)
            {
                dt.Rows.Add(p.MaPhieuPhat, p.MaThe, p.TienTra, p.ThongBao);
            }

            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool ThemPhieuPhat(string MaThe, string TienTra, string ThongBao, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var count = qLTVEntities.phieuphats.Count(pp => pp.MaThe == MaThe && pp.TienTra == "0d");
                if (count == 0)
                {
                    string s = GenerateRandomMaThe();
                    var newPhieuPhat = new phieuphat
                    {
                        MaPhieuPhat = s,
                        MaThe = MaThe,
                        TienTra = TienTra,
                        ThongBao = ThongBao
                    };
                    qLTVEntities.phieuphats.Add(newPhieuPhat);
                    qLTVEntities.SaveChanges();
                }

                return true;
            }
        }
        public bool SuaPhieuPhat(string MaPhieu, string TienTra, string ThongBao)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();

            var ppQuery = (from pp in qLTVEntities.phieuphats
                           where pp.MaPhieuPhat == MaPhieu
                           select pp).FirstOrDefault();

            if (ppQuery != null)
            {
                ppQuery.TienTra = TienTra;
                ppQuery.ThongBao = ThongBao;
                qLTVEntities.SaveChanges(); 
            }
            return true;
        }
        public bool XoaPhieuPhat(string MaPhieu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            phieuphat pp = new phieuphat();
            pp.MaPhieuPhat = MaPhieu;
            qLTVEntities.phieuphats.Attach(pp);
            qLTVEntities.phieuphats.Remove(pp);
            qLTVEntities.SaveChanges();
            return true;
        }
        public DataSet TimKiemMaPhieuPhat(string MaPhieuPhat, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from pp in qLTVEntities.phieuphats
                            where pp.MaPhieuPhat.Contains(MaPhieuPhat)
                            select pp;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Phiếu Phạt");
                dt.Columns.Add("Mã Thẻ");
                dt.Columns.Add("tiền trả");
                dt.Columns.Add("Thông báo");

                foreach (var nxb in query)
                {
                    dt.Rows.Add(nxb.MaPhieuPhat, nxb.MaThe, nxb.TienTra, nxb.ThongBao);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemMaThe(string MaThe, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from pp in qLTVEntities.phieuphats
                            where pp.MaThe.Contains(MaThe)
                            select pp;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Phiếu Phạt");
                dt.Columns.Add("Mã Thẻ");
                dt.Columns.Add("tiền trả");
                dt.Columns.Add("Thông báo");

                foreach (var nxb in query)
                {
                    dt.Rows.Add(nxb.MaPhieuPhat, nxb.MaThe, nxb.TienTra, nxb.ThongBao);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiem(string mathe, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from pp in qLTVEntities.phieuphats
                            where pp.MaThe==mathe
                            select pp;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Phiếu Phạt");
                dt.Columns.Add("Mã Thẻ");
                dt.Columns.Add("tiền trả");
                dt.Columns.Add("Thông báo");

                foreach (var nxb in query)
                {
                    dt.Rows.Add(nxb.MaPhieuPhat, nxb.MaThe, nxb.TienTra, nxb.ThongBao);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
    }
}
