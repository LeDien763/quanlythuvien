using DACK.BSA_layer;
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
    public partial class US_QLS : UserControl
    {
        public US_QLS()
        {
            InitializeComponent();
        }

        private void btnQLS_Click(object sender, EventArgs e)
        {
            QLSach f2 = new QLSach();
            f2.ShowDialog(this);
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            QLNXBcs f2 = new QLNXBcs();
            f2.ShowDialog(this);
        }

        private void btnTG_Click(object sender, EventArgs e)
        {
            QLTacGiacs f2 = new QLTacGiacs();
            f2.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLPass f2 = new BLPass();
            f2.ShowDialog(this);
        }

        private void btnQLS_Click_1(object sender, EventArgs e)
        {
            QLSach f2 = new QLSach();
            f2.ShowDialog(this);
        }

        private void btnNXB_Click_1(object sender, EventArgs e)
        {
            QLNXBcs f2 = new QLNXBcs();
            f2.ShowDialog(this);
        }

        private void btnTG_Click_1(object sender, EventArgs e)
        {
            QLTacGiacs f2 = new QLTacGiacs();
            f2.ShowDialog(this);
        }

        private void btnThe_Click(object sender, EventArgs e)
        {
            QLThe f2 = new QLThe();
            f2.ShowDialog(this);
        }
    }
}
