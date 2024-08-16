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

namespace DACK
{
    public partial class FDaMuon : Form
    {
        public FDaMuon()
        {
            InitializeComponent();
        }
        private void addUS(UserControl useControls)
        {
            useControls.Dock = DockStyle.Fill;
            pnHOMEA.Controls.Clear();
            pnHOMEA.Controls.Add(useControls);
            pnHOMEA.BringToFront();

        }
        private void FDaMuon_Load(object sender, EventArgs e)
        {
            US_PHIEUMUONA uc = new US_PHIEUMUONA();
            addUS(uc);
        }
    }
}
