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
    public partial class FKhoaThe : Form
    {
        DataTable dtDGA = null;
        BLPhieuPhat dbGDA = new BLPhieuPhat();
        public FKhoaThe()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtDGA = new DataTable();
                dtDGA.Clear();
                DataSet ds = dbGDA.LayPhieuPhat();
                dtDGA = ds.Tables[0];
                dgvKhoa.DataSource = dtDGA;
                dgvKhoa.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }
        private void FKhoaThe_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLPhieuPhat blPhat = new BLPhieuPhat();
            DataSet searchResult = null;
            if (txtTim.Text != "")
            {
                if (rdMaT.Checked == true)
                {
                    searchResult = blPhat.TimKiemMaThe(readerName, ref error);
                }
                else if (rdmaDG.Checked == true)
                {
                    searchResult = blPhat.TimKiemMaPhieuPhat(readerName, ref error);
                }

                if (searchResult != null)
                {
                    dgvKhoa.DataSource = searchResult.Tables[0];
                }
                else
                {
                    MessageBox.Show("Error occurred during search.");
                }
            }
            else LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private string mathes;
        private void grvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhoa.Rows.Count)
            {
                DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];
                this.mathes = row.Cells[1].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayCap = DateTime.Now;
                DateTime ngayHetHan = ngayCap.AddYears(2);

                string ngayHetHanFormatted = ngayHetHan.ToString("dd/MM/yyyy");

                int r = dgvKhoa.CurrentCell.RowIndex;
                string strDG1 = dgvKhoa.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLPhieuPhat blTp = new BLPhieuPhat();
                    BLThe blthe = new BLThe();
                    string err = string.Empty;
                    blTp.XoaPhieuPhat(strDG1, ref err);
                    blthe.CapNhatlaiHan(mathes, ngayHetHanFormatted, ref err);
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");

                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }
    }
}
