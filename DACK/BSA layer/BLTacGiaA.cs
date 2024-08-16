using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLTacGiaA
    {
        public DataSet LayTacGia()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var tg = from p in qLTVEntities.tbTGs
                      select p;
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã tác giả");
            dt.Columns.Add("Tên tác giả");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            foreach (var p in tg)
            {
                dt.Rows.Add(p.MaTG,p.TenTG,p.DiaChi,p.SDT,p.Email);
            }

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool ThemTacGia(string MaTG, string TenTG, string DiaChi, string SDT, string Email, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbTG tg = new tbTG();
            tg.MaTG=MaTG;
            tg.TenTG=TenTG;
            tg.DiaChi=DiaChi;
            tg.SDT=SDT;
            tg.Email=Email;
            qLTVEntities.tbTGs.Add(tg);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool XoaTacGia(string MaTG, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbTG tg = new tbTG();
            tg.MaTG= MaTG;
            qLTVEntities.tbTGs.Attach(tg);
            qLTVEntities.tbTGs.Remove(tg);
            var ds = qLTVEntities.tbDauSaches.SingleOrDefault(m => m.MaTG == MaTG);
            if (ds != null)
            {
                qLTVEntities.tbDauSaches.Remove(ds);
            }
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool CapNhatTacGia(string MaTG, string TenTG, string DiaChi, string SDT, string Email, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var tgQuery = (from tg in qLTVEntities.tbTGs
                           where tg.MaTG == MaTG
                           select tg).SingleOrDefault();
            if (tgQuery != null)
            {
                tgQuery.TenTG = TenTG;
                tgQuery.DiaChi = DiaChi;
                tgQuery.SDT = SDT;
                tgQuery.Email = Email;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemTG(string readerName, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from tg in qLTVEntities.tbTGs
                            where tg.MaTG.Contains(readerName)
                            select tg;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã tác giả");
                dt.Columns.Add("Tên tác giả");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("Email");

                foreach (var tg in query)
                {
                    dt.Rows.Add(tg.MaTG,tg.TenTG,tg.DiaChi,tg.SDT,tg.Email);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
    }
}
