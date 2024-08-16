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
    public partial class FChoDuyet : Form
    {
        public FChoDuyet()
        {
            InitializeComponent();
        }
        DataTable dtCho = null;
        BLCho dbGDA = new BLCho();
        string err;
        private string selectMaPhieu;
        private string selectMaThe;
        private string selectMaDauSach;
        public void TimPhieuMuon()
        {

            dtCho = new DataTable();
            dtCho.Clear();
            DataSet ds = dbGDA.LaySach();
            dtCho = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgvCho.DataSource = dtCho;
            // Thay đổi độ rộng cột
            dgvCho.AutoResizeColumns();
            // Xóa trống các đối tượng trong Panel

        }
        private void FChoDuyet_Load(object sender, EventArgs e)
        {
            TimPhieuMuon();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            DateTime ngayCap = DateTime.Now; // Ngày cấp là ngày hiện tại
            DateTime ngayHetHan = ngayCap.AddYears(4); // Ngày hết hạn là ngày cấp + 4 năm
            // Định dạng ngày theo chuỗi "dd/MM/yyyy"
            string ngaymuonFormatted = ngayCap.ToString("dd/MM/yyyy");
            string ngayHetHanFormatted = ngayHetHan.ToString("dd/MM/yyyy");
            BLCho blTp = new BLCho();
            if (!string.IsNullOrEmpty(selectMaPhieu) && blTp.LaySoLuong(selectMaDauSach, ref err) > 0)
            {
                blTp.ThemPhieuMuonDD(selectMaPhieu, selectMaDauSach, selectMaThe, ngaymuonFormatted, ngayHetHanFormatted, ref err);
                blTp.UpdateSoLuong(selectMaDauSach, blTp.LaySoLuong(selectMaDauSach, ref err) - 1, ref err);
                blTp.XoaPhieu(selectMaPhieu, ref err);
                TimPhieuMuon();
                MessageBox.Show("Đã thêm xong!");
            }
            else
            {
                MessageBox.Show("Sach Da Het....!");
            }
        }

        private void btnXoaDon_Click(object sender, EventArgs e)
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

        private void btnduyetAll_Click(object sender, EventArgs e)
        {
            BLCho blTp = new BLCho();
            foreach (DataGridViewRow row in dgvCho.Rows)
            {
                if (row.Index != dgvCho.Rows.Count - 1)
                {
                    // Lấy thông tin từ các ô trong hàng
                    string selectMaPhieu = row.Cells[0].Value.ToString();
                    string selectMaDauSach = row.Cells[3].Value.ToString();
                    string selectMaThe = row.Cells[1].Value.ToString();

                    DateTime ngayCap = DateTime.Now;
                    DateTime ngayHetHan = ngayCap.AddYears(4);
                    string ngaymuonFormatted = ngayCap.ToString("dd/MM/yyyy");
                    string ngayHetHanFormatted = ngayHetHan.ToString("dd/MM/yyyy");

                    if (!string.IsNullOrEmpty(selectMaPhieu) && blTp.LaySoLuong(selectMaDauSach, ref err) > 0)
                    {
                        blTp.ThemPhieuMuonDD(selectMaPhieu, selectMaDauSach, selectMaThe, ngaymuonFormatted, ngayHetHanFormatted, ref err);
                        blTp.UpdateSoLuong(selectMaDauSach, blTp.LaySoLuong(selectMaDauSach, ref err) - 1, ref err);
                        blTp.XoaPhieu(selectMaPhieu, ref err);
                    }
                    else
                    {
                        MessageBox.Show("Sach Da Het....!");
                    }
                }
            }

            TimPhieuMuon();
            MessageBox.Show("Đã thêm xong!");
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            TimPhieuMuon();
        }

        private void dgvCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCho.Rows[e.RowIndex];
                selectMaPhieu = row.Cells[0].Value.ToString();
                selectMaThe = row.Cells[1].Value.ToString();
                selectMaDauSach = row.Cells[3].Value.ToString();

                BLCho blTp = new BLCho();
                
                selectMaThe = row.Cells[1].Value.ToString();
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLCho blcho = new BLCho();

            DataSet searchResult = null;
            if (txtTim.Text != "")
            {
                if (rdMaPhieu.Checked == true)
                {
                    searchResult = blcho.TimKiemMP(readerName, ref error);
                }
                else if (rdMaDG.Checked == true)
                {
                    searchResult = blcho.TimKiemMDP(readerName, ref error);
                }

                if (searchResult != null)
                {
                    dgvCho.DataSource = searchResult.Tables[0];
                }
                else
                {
                    MessageBox.Show("Error occurred during search.");
                }
            }
            else TimPhieuMuon();
        }
    }
}
