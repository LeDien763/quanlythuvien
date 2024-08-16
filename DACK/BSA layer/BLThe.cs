using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLThe
    {
        public DataSet LayThe()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var dgs = from p in qLTVEntities.tbThes
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã thẻ");
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Ngày cấp");
            dt.Columns.Add("Hạn");

            foreach (var p in dgs)
            {
                dt.Rows.Add(p.MaThe,p.MaDG,p.NgayCap,p.Han);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool XoaThe(string MaThe, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbThe cd = new tbThe();
            cd.MaThe = MaThe;
            qLTVEntities.tbThes.Attach(cd);
            qLTVEntities.tbThes.Remove(cd);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool CapNhatThe(string MaThe, string MaDG, string NgayCap, string Han, ref string err)
        { 
            QLTVEntities qLTVEntities = new QLTVEntities();
            var Query = (from the in qLTVEntities.tbThes
                           where the.MaDG == MaDG
                           select the).SingleOrDefault();
            if (Query != null)
            {
                Query.MaThe = MaThe;
                Query.NgayCap = NgayCap;
                Query.Han = Han;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemMaThe(string MaThe, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from the in qLTVEntities.tbThes
                            where the.MaThe.Contains(MaThe)
                            select the;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Ngày cấp");
                dt.Columns.Add("Hạn");


                foreach (var the in query)
                {
                    dt.Rows.Add(the.MaThe, the.MaDG, the.NgayCap, the.Han);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemMaDG(string MaDG, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from the in qLTVEntities.tbThes
                            where the.MaDG.Contains(MaDG)
                            select the;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã thẻ");
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Ngày cấp");
                dt.Columns.Add("Hạn");


                foreach (var the in query)
                {
                    dt.Rows.Add(the.MaThe, the.MaDG, the.NgayCap, the.Han);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public bool CheckHanThe(string MaDG, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from the in qLTVEntities.tbThes
                            where the.MaDG == MaDG
                            select the.Han;

                string hanValue = query.FirstOrDefault();
                if (!string.IsNullOrEmpty(hanValue))
                {
                    DateTime han;
                    if (DateTime.TryParse(hanValue, out han))
                    {
                        if (han < DateTime.Now)
                            return false;
                    }
                }
            }
            return true;
        }
        public bool CapNhatlaiHan(string MaThe, string Han, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var the = qLTVEntities.tbThes.FirstOrDefault(t => t.MaThe == MaThe);
                if (the != null)
                {
                    the.Han = Han;
                    qLTVEntities.SaveChanges();
                }

                return true;
            }
        }



    }
}
