using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK.UseControls
{
    public partial class US_FMuon : UserControl
    {
        public US_FMuon()
        {
            InitializeComponent();
        }

        private void btnDSM_Click_1(object sender, EventArgs e)
        {
            FDaMuon f = new FDaMuon();
            f.Show();
        }

        private void btnCho_Click_1(object sender, EventArgs e)
        {
            FChoDuyet f = new FChoDuyet();
            f.Show();
        }

        private void btnKhoaThe_Click(object sender, EventArgs e)
        {
            FKhoaThe f = new FKhoaThe();
            f.Show();
        }
    }
}
