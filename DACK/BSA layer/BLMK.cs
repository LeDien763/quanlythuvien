using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLMK
    {
        public DataSet LayMadg()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var mks = from p in qLTVEntities.tbMKs select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đọc giả");
            dt.Columns.Add("Mật khẩu");
            
            foreach (var p in mks)
            {
                dt.Rows.Add(p.MaDG,p.MatKhau);
            }

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool CapNhatMatKhau(string MaDG, string MatKhau, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var mkQuery = (from mk in qLTVEntities.tbMKs
                           where mk.MaDG == MaDG
                           select mk).SingleOrDefault();
            if (mkQuery != null)
            {
                mkQuery.MatKhau = MatKhau;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemMaDG(string readerName, ref string err)
        {
            using (var qLTVEntities= new QLTVEntities())
            {
                var query = from mk in qLTVEntities.tbMKs
                            where mk.MaDG.Contains(readerName)
                            select mk;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Mật khẩu");

                foreach (var mk in query)
                {
                    dt.Rows.Add(mk.MaDG, mk.MatKhau);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }

    }
}
