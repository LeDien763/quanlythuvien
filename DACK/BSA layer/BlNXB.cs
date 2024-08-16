using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BlNXB
    {
        public DataSet LayNXB()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var nxbs = from p in qLTVEntities.tbNXBs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NXB");
            dt.Columns.Add("Tên NXB");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            
            foreach (var p in nxbs)
            {
                dt.Rows.Add(p.MaNXB,p.TenNXB,p.DiaChi,p.SDT);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool ThemNXB(string MaNXB, string TenNXB, string DiaChi, string SDT, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbNXB nxb = new tbNXB();
            nxb.MaNXB = MaNXB;
            nxb.TenNXB = TenNXB;
            nxb.DiaChi = DiaChi;
            nxb.SDT = SDT;
            qLTVEntities.tbNXBs.Add(nxb);
            qLTVEntities.SaveChanges();

            return true;
        }
        public bool XoaNXB(string MaNXB, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbNXB nxb = new tbNXB();
            nxb.MaNXB = MaNXB;
            qLTVEntities.tbNXBs.Attach(nxb);
            qLTVEntities.tbNXBs.Remove(nxb);
            var ds = qLTVEntities.tbDauSaches.SingleOrDefault(m => m.MaNXB == MaNXB);
            if (ds != null)
            {
                qLTVEntities.tbDauSaches.Remove(ds);
            }
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool CapNhatNXB(string MaNXB, string TenNXB, string DiaChi, string SDT, ref string err)
        {
            
            QLTVEntities qLTVEntities = new QLTVEntities();
            var nxbQuery = (from nxb in qLTVEntities.tbNXBs
                           where nxb.MaNXB == MaNXB
                           select nxb).SingleOrDefault();
            if (nxbQuery != null)
            {
                nxbQuery.TenNXB = TenNXB;
                nxbQuery.DiaChi = DiaChi;
                nxbQuery.SDT = SDT;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemNXB(string readerName, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from nxb in qLTVEntities.tbNXBs
                            where nxb.MaNXB.Contains(readerName)
                            select nxb;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NXB");
                dt.Columns.Add("Tên NXB");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("Số điện thoại");

                foreach (var nxb in query)
                {
                    dt.Rows.Add(nxb.MaNXB,nxb.TenNXB,nxb.DiaChi,nxb.SDT);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }

    }
}
