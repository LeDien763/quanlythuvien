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
    public partial class QLThe : Form
    {
        public QLThe()
        {
            InitializeComponent();
        }
        DataTable dtDGA = null;
        bool Them;
        string err;
        BLThe dbGDA = new BLThe();

        void LoadData()
        {
            try
            {
                dtDGA = new DataTable();
                dtDGA.Clear();
                DataSet ds = dbGDA.LayThe();
                dtDGA = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvThe.DataSource = dtDGA;
                // Thay đổi độ rộng cột
                dgvThe.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel

                this.txtMaDG.ResetText();
                this.txtMaThe.ResetText();
                this.dateHan.ResetText();
                this.dateNgayCap.ResetText();
                this.txtMaDG.Enabled = false;
                this.txtMaThe.Enabled =false;
                this.dateNgayCap.Enabled = false;
                this.dateHan.Enabled = false;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                dgvThe_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DocGia. Lỗi rồi!!!");
            }
        }
        private void QLThe_Load(object sender, EventArgs e)
        {
            LoadData();
            txtMaDG.Enabled = false;
            txtMaThe.Enabled = false;
            dateHan.Enabled = false;
            dateNgayCap.Enabled = false;
            LoadData();
        }

        private void dgvThe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvThe.CurrentCell.RowIndex;

            this.txtMaThe.Text = dgvThe.Rows[r].Cells[0].Value.ToString();
            this.txtMaDG.Text = dgvThe.Rows[r].Cells[1].Value.ToString();


            object value1 = dgvThe.Rows[r].Cells[2].Value;
            if (value1 != null && value1 != DBNull.Value && DateTime.TryParse(value1.ToString(), out DateTime dateTimeValue1))
            {
                this.dateNgayCap.Value = dateTimeValue1;
            }

            object value = dgvThe.Rows[r].Cells[3].Value;
            if (value != null && value != DBNull.Value && DateTime.TryParse(value.ToString(), out DateTime dateTimeValue))
            {
                this.dateHan.Value = dateTimeValue;
            }
        }
        public string GenerateRandomMaThe()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000001);

            string maThe = randomNumber.ToString("D6");

            return maThe;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = false;
            dgvThe_CellClick(null, null);
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.dateHan.Enabled = true;
            this.dateNgayCap.Enabled = true;
            this.txtMaDG.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = dgvThe.CurrentCell.RowIndex;
                string strDG = dgvThe.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLThe blTp = new BLThe();
                    string err = string.Empty;
                    blTp.XoaThe(strDG, ref err);
                    // Cập nhật lại DataGridView
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime selectedCap = this.dateNgayCap.Value;
            string CapString = selectedCap.ToString("dd/MM/yyyy");

            DateTime selectedHan = this.dateHan.Value;
            string HanString = selectedHan.ToString("dd/MM/yyyy");

            if (Them == false)
            {
                BLThe blTp = new BLThe();
                blTp.CapNhatThe(this.txtMaThe.Text, this.txtMaDG.Text, CapString, HanString, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMaThe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLThe blDocGia = new BLThe();
            DataSet searchResult = null;
            if (txtTim.Text != "")
            {
                if (rdMaT.Checked == true)
                {
                    searchResult = blDocGia.TimKiemMaThe(readerName, ref error);
                }
                else if (rdmaDG.Checked == true)
                {
                    searchResult = blDocGia.TimKiemMaDG(readerName, ref error);
                }

                if (searchResult != null)
                {
                    dgvThe.DataSource = searchResult.Tables[0];
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
