using DACK.BSA_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK.UseControls
{
    public partial class US_TTCN : UserControl
    {
        string curentDG;
        string curentMK;
        string err;
        public static string MaThe { get; private set; } = "";
        public static string TennDG { get; set; } = "";
        public US_TTCN()
        {
            InitializeComponent();
            this.txtMaDG.Enabled = false;
            this.txtTK.Enabled = false;

            curentDG = FDangNhap.MaDG;
            curentMK = FDangNhap.MKcu;

            this.txtMaDG.Text = FDangNhap.MaDG;
            this.txtTK.Text = FDangNhap.MaDG;
            TimDocGia();
        }
        public void TimDocGia()
        {
            BSA_layer.BLDocGiaA blDG = new BSA_layer.BLDocGiaA();
            string err = string.Empty;
            DataSet ds = blDG.TimKiemDG1(curentDG, ref err);

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    this.txtTen.Text = row[1].ToString();
                    US_TTCN.TennDG = txtTen.Text;
                    this.txtchucVu.Text = row[2].ToString();
                    this.cmbGT.Text = row[6].ToString();
                    this.txtLop.Text = row[3].ToString();
                    this.txtKhoa.Text = row[4].ToString();
                    DateTime dateTime = DateTime.ParseExact(row[5].ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.dateTimeDate.Value = dateTime;
                    this.txtGhiChu.Text = row[7].ToString();
                    US_TTCN.MaThe = row[8].ToString();

                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin độc giả.");
            }
        }



        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            BSA_layer.BLDocGiaA blDG = new BSA_layer.BLDocGiaA();
            DateTime selectedDateTime = this.dateTimeDate.Value;
            string dateString = selectedDateTime.ToString("dd/MM/yyyy");

            DialogResult traloi;

            traloi = MessageBox.Show("Chắc chắn cập nhật thông tin hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traloi == DialogResult.Yes)
            {
                string err = string.Empty;
                bool result = blDG.CapNhatDocGia(this.txtMaDG.Text, this.txtTen.Text, this.txtchucVu.Text, this.txtLop.Text,
                        this.txtKhoa.Text, dateString, this.cmbGT.SelectedItem.ToString(), txtGhiChu.Text, ref err);
                if (result)
                {
                    MessageBox.Show("Đã cập nhật thông tin độc giả thành công!");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin độc giả.\n" + err);
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện việc cập nhật.");
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (string.Equals(curentMK, this.txtMK.Text) && string.Equals(txtXNMK.Text, txtmkMoi.Text))
            {
                BLMK blTp = new BLMK();
                blTp.CapNhatMatKhau(this.txtTK.Text, txtmkMoi.Text, ref err);
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                MessageBox.Show("Không trùng khớp, vui lòng nhập lại!");
            }
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked == true)
            {
                this.txtMK.UseSystemPasswordChar = false;
                this.txtmkMoi.UseSystemPasswordChar = false;
                this.txtXNMK.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtMK.UseSystemPasswordChar = true;
                this.txtmkMoi.UseSystemPasswordChar = true;
                this.txtXNMK.UseSystemPasswordChar = true;
            }
        }

        private void US_TTCN_Load(object sender, EventArgs e)
        {
            TimDocGia();
        }
    }
}
