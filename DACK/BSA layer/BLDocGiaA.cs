using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.BSA_layer
{
    internal class BLDocGiaA
    {
        private string GenerateRandomMaThe()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000001);

            string maThe = randomNumber.ToString("D6");

            return maThe;
        }
        public DataTable LayDocGia()
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
                dt.Rows.Add(p.MaDG,p.TenDG,p.ChucVu,p.Lop,p.Khoa,p.NgaySinh,p.GioiTinh,p.GhiChu);
            }
            return dt;
        }
        public bool ThemDocGia(string MaDG, string TenDG, string ChucVu, string Lop, string Khoa, string NgaySinh, string GioiTinh, string GhiChu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            string maThe = GenerateRandomMaThe(); // Hàm tạo mã thẻ ngẫu nhiên

            DateTime ngayCap = DateTime.Now; // Ngày cấp là ngày hiện tại
            DateTime ngayHetHan = ngayCap.AddYears(4); // Ngày hết hạn là ngày cấp + 4 năm

            // Định dạng ngày theo chuỗi "dd/MM/yyyy"
            string ngayCapFormatted = ngayCap.ToString("dd/MM/yyyy");
            string ngayHetHanFormatted = ngayHetHan.ToString("dd/MM/yyyy");
            tbDG dg= new tbDG();
            dg.MaDG = MaDG;
            dg.TenDG = TenDG;
            dg.ChucVu = ChucVu;
            dg.Lop = Lop;
            dg.Khoa = Khoa;
            dg.NgaySinh = NgaySinh;
            dg.GioiTinh = GioiTinh;
            dg.GhiChu = GhiChu;
            qLTVEntities.tbDGs.Add(dg);
            tbMK mK = new tbMK();
            mK.MaDG = MaDG;
            mK.MatKhau = "1";
            qLTVEntities.tbMKs.Add(mK);
            tbThe the= new tbThe();
            the.MaThe = maThe;
            the.MaDG = MaDG;
            the.NgayCap = ngayCapFormatted;
            the.Han = ngayHetHanFormatted;
            qLTVEntities.tbThes.Add(the);
            qLTVEntities.SaveChanges();

            return true;
        }
        public bool XoaDocGia(string MaDG, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();

            var dg = qLTVEntities.tbDGs.SingleOrDefault(d => d.MaDG == MaDG);
            if (dg != null)
            {
                qLTVEntities.tbDGs.Remove(dg);
            }

            var mk = qLTVEntities.tbMKs.SingleOrDefault(m => m.MaDG == MaDG);
            if (mk != null)
            {
                qLTVEntities.tbMKs.Remove(mk);
            }

            var thes = qLTVEntities.tbThes.SingleOrDefault(t => t.MaDG == MaDG);
            if (thes != null)
            {
                qLTVEntities.tbThes.Remove(thes);
            }

            qLTVEntities.SaveChanges();
            return true;
        }

        public bool CapNhatDocGia(string MaDG, string TenDG, string ChucVu, string Lop, string Khoa, string NgaySinh, string GioiTinh, string GhiChu, ref string err)
        {
            QLTVEntities qLTVEntities = new QLTVEntities();
            var dgQuery=(from dg in qLTVEntities.tbDGs
                         where dg.MaDG == MaDG
                         select dg).SingleOrDefault();
            if (dgQuery != null)
            {
                dgQuery.TenDG = TenDG;
                dgQuery.ChucVu = ChucVu;
                dgQuery.Lop = Lop;
                dgQuery.Khoa = Khoa;
                dgQuery.NgaySinh = NgaySinh;
                dgQuery.GioiTinh = GioiTinh;
                dgQuery.GhiChu = GhiChu;
                qLTVEntities.SaveChanges();
            }
            return true;
        }
        public DataSet TimKiemDG(string MaDG, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from dg in qLTVEntities.tbDGs
                            where dg.MaDG.Contains(MaDG)
                            select dg;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Tên đọc giả");
                dt.Columns.Add("Chức vụ");
                dt.Columns.Add("Lớp");
                dt.Columns.Add("Khoa");
                dt.Columns.Add("Ngày sinh");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("Ghi chú");

                foreach (var dg in query)
                {
                    dt.Rows.Add(dg.MaDG, dg.TenDG, dg.ChucVu, dg.Lop, dg.Khoa, dg.NgaySinh, dg.GioiTinh, dg.GhiChu);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemDG1(string MaDG, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from the in qLTVEntities.tbThes
                            join dg in qLTVEntities.tbDGs on the.MaDG equals dg.MaDG
                            where the.MaDG==MaDG
                            select new
                            {
                                MaDG=dg.MaDG,
                                TenDG=dg.TenDG,
                                ChucVu = dg.ChucVu,
                                Lop = dg.Lop,
                                Khoa = dg.Khoa,
                                NgaySinh = dg.NgaySinh,
                                GioiTinh = dg.GioiTinh,
                                GhiChu = dg.GhiChu,
                                MaThe=the.MaThe
                            };

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Tên đọc giả");
                dt.Columns.Add("Chức vụ");
                dt.Columns.Add("Lớp");
                dt.Columns.Add("Khoa");
                dt.Columns.Add("Ngày sinh");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("Ghi chú");
                dt.Columns.Add("Mã thẻ");
                foreach (var dg in query)
                {
                    dt.Rows.Add(dg.MaDG,
                                dg.TenDG,
                                dg.ChucVu,
                                dg.Lop,
                                dg.Khoa,
                                dg.NgaySinh,
                                dg.GioiTinh,
                                dg.GhiChu,
                                dg.MaThe);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }
        public DataSet TimKiemTenDG(string readerName, ref string err)
        {
            using (var qLTVEntities = new QLTVEntities())
            {
                var query = from dg in qLTVEntities.tbDGs
                            where dg.TenDG.Contains(readerName)
                            select dg;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã đọc giả");
                dt.Columns.Add("Tên đọc giả");
                dt.Columns.Add("Chức vụ");
                dt.Columns.Add("Lớp");
                dt.Columns.Add("Khoa");
                dt.Columns.Add("Ngày sinh");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("Ghi chú");

                foreach (var dg in query)
                {
                    dt.Rows.Add(dg.MaDG, dg.TenDG, dg.ChucVu, dg.Lop, dg.Khoa, dg.NgaySinh, dg.GioiTinh, dg.GhiChu);
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                return ds;
            }
        }

    }
}
