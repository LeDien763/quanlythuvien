using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.PhieuMuon' table. You can move, or remove it, as needed.
            this.phieuMuonTableAdapter.Fill(this.testDataSet.PhieuMuon);
            // TODO: This line of code loads data into the 'testDataSet.PhieuMuon' table. You can move, or remove it, as needed.
            this.phieuMuonTableAdapter.Fill(this.testDataSet.PhieuMuon);

            this.reportViewer1.RefreshReport();
        }
    }
}

