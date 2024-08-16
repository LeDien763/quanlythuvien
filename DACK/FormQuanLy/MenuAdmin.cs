using DACK.UseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DACK
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
            US_HOMEA uc = new US_HOMEA();
            addUS(uc);
        }
        private void addUS(UserControl useControls)
        {
            useControls.Dock = DockStyle.Fill;
            pnHOMEA.Controls.Clear();
            pnHOMEA.Controls.Add(useControls);
            pnHOMEA.BringToFront();

        }





        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            US_HOMEA uc = new US_HOMEA();
            addUS(uc);
        }

        private void btnDG_Click_1(object sender, EventArgs e)
        {
            US_DOCGIAA uc = new US_DOCGIAA();
            addUS(uc);
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            US_QLS uc = new US_QLS();
            addUS(uc);
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {
            US_FMuon uc = new US_FMuon();
            addUS(uc);
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            US_THONGKEA uc = new US_THONGKEA();
            addUS(uc);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                FDangNhap me_ad = new FDangNhap();
                me_ad.ShowDialog();
                this.Close();
            }
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
