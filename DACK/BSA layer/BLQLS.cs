using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLQLS
    {
        public DataSet LaySach()
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var dss = from p in qLTVEntities.tbDauSaches
                      select p;
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Mã đầu sách");
            dt.Columns.Add("Tên sách");
            dt.Columns.Add("Mã NXB");
            dt.Columns.Add("Mã tác giả");
            dt.Columns.Add("Năm xuất bản");
            dt.Columns.Add("Chuyên ngành");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Ghi chú");
            foreach (var p in dss)
            {
                dt.Rows.Add(p.MaDauSach,p.TenSach,p.MaNXB,p.MaTG,p.NamXuatBan,p.ChuyenNganh,p.SoLuong,p.GhiChu);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            return dataSet;
        }
        public bool ThemSach(string MaDauSach, string TenSach, string MaNXB, string MaTG, string NamXuatBan, string ChuyenNganh, int SoLuong, string GhiChu, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var nxb = qLTVEntities.tbNXBs.FirstOrDefault(n => n.MaNXB == MaNXB);
                var tg = qLTVEntities.tbTGs.FirstOrDefault(t => t.MaTG == MaTG);

                if (nxb == null)
                {
                    nxb = new tbNXB { MaNXB = MaNXB, TenNXB = "", DiaChi = "", SDT = "" };
                    qLTVEntities.tbNXBs.Add(nxb);
                }

                if (tg == null)
                {
                    tg = new tbTG { MaTG = MaTG, TenTG = "", DiaChi = "", SDT = "", Email = "" };
                    qLTVEntities.tbTGs.Add(tg);
                }

                var dauSach = new tbDauSach
                {
                    MaDauSach = MaDauSach,
                    TenSach = TenSach,
                    MaNXB = MaNXB,
                    MaTG = MaTG,
                    NamXuatBan = NamXuatBan,
                    ChuyenNganh = ChuyenNganh,
                    SoLuong = SoLuong,
                    GhiChu = GhiChu
                };

                qLTVEntities.tbDauSaches.Add(dauSach);
                qLTVEntities.SaveChanges();

                return true;
            }
        }

        public bool XoaSach(string MaDauSach, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            tbDauSach ds = new tbDauSach();
            ds.MaDauSach= MaDauSach;
            qLTVEntities.tbDauSaches.Attach(ds);
            qLTVEntities.tbDauSaches.Remove(ds);
            qLTVEntities.SaveChanges();
            return true;
        }
        public bool CapNhatSach(string MaDauSach, string TenSach, string MaNXB, string MaTG, string NamXuatBan, string ChuyenNganh, int SoLuong, string GhiChu, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var nxb = qLTVEntities.tbNXBs.FirstOrDefault(n => n.MaNXB == MaNXB);
                var tg = qLTVEntities.tbTGs.FirstOrDefault(t => t.MaTG == MaTG);

                if (nxb == null)
                {
                    nxb = new tbNXB { MaNXB = MaNXB, TenNXB = "", DiaChi = "", SDT = "" };
                    qLTVEntities.tbNXBs.Add(nxb);
                }

                if (tg == null)
                {
                    tg = new tbTG { MaTG = MaTG, TenTG = "", DiaChi = "", SDT = "", Email = "" };
                    qLTVEntities.tbTGs.Add(tg);
                }

                var dauSach = qLTVEntities.tbDauSaches.FirstOrDefault(ds => ds.MaDauSach == MaDauSach);

                if (dauSach != null)
                {
                    dauSach.TenSach = TenSach;
                    dauSach.MaNXB = MaNXB;
                    dauSach.MaTG = MaTG;
                    dauSach.NamXuatBan = NamXuatBan;
                    dauSach.ChuyenNganh = ChuyenNganh;
                    dauSach.SoLuong = SoLuong;
                    dauSach.GhiChu = GhiChu;
                }

                qLTVEntities.SaveChanges();

                return true;
            }
        }

        public DataSet TimKiemSach(string readerName, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from dss in qLTVEntities.tbDauSaches
                            where dss.MaDauSach.Contains(readerName)
                            select dss;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đầu sách");
                dt.Columns.Add("Tên sách");
                dt.Columns.Add("Mã NXB");
                dt.Columns.Add("Mã tác giả");
                dt.Columns.Add("Năm xuất bản");
                dt.Columns.Add("Chuyên ngành");
                dt.Columns.Add("Số lượng");
                dt.Columns.Add("Ghi chú");

                foreach (var dss in query)
                {
                    dt.Rows.Add(dss.MaDauSach,dss.TenSach,dss.MaNXB,dss.MaTG,dss.NamXuatBan,dss.ChuyenNganh,dss.SoLuong,dss.GhiChu);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
    }
}
