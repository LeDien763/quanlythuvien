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
    public partial class US_Home : UserControl
    {
        public US_Home()
        {
            InitializeComponent();
        }
        DataTable dtCho = null;
        BLPhieuPhat dbGDA = new BLPhieuPhat();

        public void TimDocGia()
        {
            string err = string.Empty;
            dtCho = new DataTable();
            dtCho.Clear();
            DataSet ds1 = dbGDA.TimKiem(US_TTCN.MaThe, ref err);
            dtCho = ds1.Tables[0];
            dgvTB.DataSource = dtCho;
            dgvTB.AutoResizeColumns();
        }

        private void US_Home_Load(object sender, EventArgs e)
        {
            TimDocGia();
            
            
        }
    }

}
