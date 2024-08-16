using DACK.BSA_layer;
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
    public partial class BLPass : Form
    {
        public BLPass()
        {
            InitializeComponent();
        }
        DataTable dtPass = null;
        bool Them;
        string err;
        BLMK dbTP = new BLMK();
        void LoadData()
        {
            this.txtTK.Enabled = false;
            this.txtMK.Enabled = false;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            try
            {
                dtPass = new DataTable();
                dtPass.Clear();
                DataSet ds = dbTP.LayMadg();
                dtPass = ds.Tables[0];
                grvMK.DataSource = dtPass;
                grvMK.AutoResizeColumns();

                grvMK_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }
        private void BLPass_Load(object sender, EventArgs e)
        {
            LoadData();
            this.txtTK.Enabled = false;
        }

        private void grvMK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = grvMK.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtTK.Text = grvMK.Rows[r].Cells[0].Value.ToString();
            this.txtMK.Text = grvMK.Rows[r].Cells[1].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them == false)
            {
                BLMK blTp = new BLMK();
                blTp.CapNhatMatKhau(this.txtTK.Text, this.txtMK.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            grvMK_CellClick(null, null);
            this.txtTK.Enabled = false;
            this.txtMK.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMK.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.btnSua.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.txtTK.Enabled = false;
            this.txtMK.Enabled = false;
            grvMK_CellClick(null, null);
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLMK blDocGia = new BLMK();
            DataSet searchResult = null;

            if (txtTim.Text != "")
            {
                searchResult = blDocGia.TimKiemMaDG(readerName, ref error);

                if (searchResult != null)
                {
                    grvMK.DataSource = searchResult.Tables[0];
                }
                else
                {
                    MessageBox.Show("Error occurred during search.");
                }
            }
            else LoadData();
        }
    }
}
