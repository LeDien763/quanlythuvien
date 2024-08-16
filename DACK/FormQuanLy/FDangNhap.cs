using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK
{
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }


        public bool checkAdmin = true;
        public static string MaDG { get; private set; } = "";
        public static string MKcu { get; private set; } = "";

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            if (checkAdmin)
            {
                if (this.txtUserName.Text == "1" && this.txtPassword.Text == "1")
                {
                    this.Hide();
                    MenuAdmin formDangNhap = new MenuAdmin();
                    formDangNhap.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nhập sai thông tin, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUserName.Focus();
                }
            }

            else
            {
                using (QLTVEntities qLTVEntities = new QLTVEntities())
                {
                    string userName1 = txtUserName.Text.Trim();
                    string password1= txtPassword.Text.Trim();

                    var result = qLTVEntities.tbMKs.FirstOrDefault(mk => mk.MaDG == userName1 && mk.MatKhau == password1);

                    if (result != null)
                    {
                        FDangNhap.MaDG = userName1;
                        FDangNhap.MKcu = password1;
                        this.Hide();
                        Menu formDangNhap = new Menu();
                        formDangNhap.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra tên đăng nhập và mật khẩu của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                this.Hide();
                FDangNhap formDangNhap = Application.OpenForms["dangnhap"] as FDangNhap;
                if (formDangNhap != null)
                {
                    formDangNhap.ShowDialog();
                }
            }
        }

        private void rdDG_CheckedChanged_1(object sender, EventArgs e)
        {
            checkAdmin = false;
        }

        private void rdAdmin_CheckedChanged_1(object sender, EventArgs e)
        {
            checkAdmin = true;

        }

        private void cbHienMK_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbHienMK.Checked == true)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
