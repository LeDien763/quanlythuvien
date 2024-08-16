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

namespace DACK.UseControls
{
    public partial class US_Sach : UserControl
    {
        public US_Sach()
        {
            InitializeComponent();
        }
        DataTable dtSach = null;
        string err;
        bool Them;
        BLQLS bdSach = new BLQLS();
        BLTacGiaA bdTG = new BLTacGiaA();
        BlNXB bdNXB = new BlNXB();
        US_PhieuMuon mp = new US_PhieuMuon();
        private string selectMadauSach;
        private int sl;
        void LoadData1()
        {
            try
            {
                dtSach = new DataTable();
                dtSach.Clear();

                DataSet ds = bdSach.LaySach();
                dtSach = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvSach.DataSource = dtSach;
                // Thay đổi độ rộng cột
                dgvSach.AutoResizeColumns();

                DataSet ds1 = bdTG.LayTacGia();
                dtSach = ds1.Tables[0];
                // Đưa dữ liệu lên DataGridView
                gvTacGia.DataSource = dtSach;
                // Thay đổi độ rộng cột
                gvTacGia.AutoResizeColumns();

                DataSet ds2 = bdNXB.LayNXB();
                dtSach = ds2.Tables[0];
                // Đưa dữ liệu lên DataGridView
                grvNXB.DataSource = dtSach;
                // Thay đổi độ rộng cột
                grvNXB.AutoResizeColumns();
                TimPhieuMuon();
                BLThe t = new BLThe();
                if (t.CheckHanThe(FDangNhap.MaDG, ref err) == false)
                {
                    MessageBox.Show("Thẻ của bạn đã hết hạn, không thể mượn sách\n Hãy gặp thủ thư để gia hạn thẻ");
                    this.btnThem.Enabled = false;
                    this.btnXoa.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table . Lỗi rồi!!!");
            }
        }
        private string GenerateRandomMaThe()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000001);

            string maThe = randomNumber.ToString("D6");

            return maThe;
        }
        DataTable dtCho = null;

        BLCho dbGDA = new BLCho();
        BSA_layer.BLCho blDG = new BSA_layer.BLCho();
        public void TimPhieuMuon()
        {

            string err = string.Empty;

            dtCho = new DataTable();
            dtCho.Clear();
            DataSet ds1 = dbGDA.TimKiemMTUse(FDangNhap.MaDG, ref err);
            dtCho = ds1.Tables[0];
            dgvCho.DataSource = dtCho;
            dgvCho.AutoResizeColumns();

        }
        private void btnTimSach_Click(object sender, EventArgs e)
        {
            string readerName = txtMaTG.Text;
            string error = string.Empty;
            BLTacGiaA blSach = new BLTacGiaA();
            DataSet searchResult = null;

            searchResult = blSach.TimKiemTG(readerName, ref error);
            gvTacGia.DataSource = searchResult.Tables[0];
        }

        private void US_Sach_Load(object sender, EventArgs e)
        {
            LoadData1();
        }

        private void btnTimNXB_Click(object sender, EventArgs e)
        {
            string readerName = txtNhaXB.Text;
            string error = string.Empty;
            BlNXB blSach = new BlNXB();
            DataSet searchResult = null;

            searchResult = blSach.TimKiemNXB(readerName, ref error);
            grvNXB.DataSource = searchResult.Tables[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectMadauSach) && sl > 0)
            {
                

                BLCho blTp = new BLCho();
                blTp.ThemPhieu(GenerateRandomMaThe(), US_TTCN.MaThe, selectMadauSach, false, "", ref err);
                TimPhieuMuon();
                MessageBox.Show("Đã thêm xong!");
            }
            else
            {
                MessageBox.Show("Sách đã hết, vui lòng chọn sách khác....!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvCho.CurrentCell.RowIndex;
                string strDG1 = dgvCho.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLCho blTp = new BLCho();
                    string err = string.Empty;
                    blTp.XoaPhieu(strDG1, ref err);
                    // Cập nhật lại DataGridView
                    TimPhieuMuon();
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

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];
                selectMadauSach = row.Cells[0].Value.ToString();
                sl = int.Parse(row.Cells[6].Value.ToString());
            }
        }

        private void txtMaTG_TextChanged(object sender, EventArgs e)
        {
            BLTacGiaA blSach = new BLTacGiaA();
            DataSet searchResult = null;
            if (txtMaTG.Text != "")
            {
                searchResult = blSach.TimKiemTG(txtMaTG.Text, ref err);
                gvTacGia.DataSource = searchResult.Tables[0];
            }
            else LoadData1();
        }

        private void txtNhaXB_TextChanged(object sender, EventArgs e)
        {
            BlNXB blSach = new BlNXB();
            DataSet searchResult = null;
            if (txtNhaXB.Text != "")
            {
                searchResult = blSach.TimKiemNXB(txtNhaXB.Text, ref err);
                grvNXB.DataSource = searchResult.Tables[0];
            }
            else LoadData1();
        }

        private void txtMaSauSach_TextChanged(object sender, EventArgs e)
        {
            BLQLS blSach = new BLQLS();
            DataSet searchResult = null;
            if (txtMaSauSach.Text != "")
            {
                searchResult = blSach.TimKiemSach(this.txtMaSauSach.Text, ref err);
                dgvSach.DataSource = searchResult.Tables[0];
            }
            else LoadData1();
        }
    }
}
