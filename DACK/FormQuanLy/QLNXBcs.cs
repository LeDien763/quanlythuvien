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
    public partial class QLNXBcs : Form
    {
        DataTable dtNXB = null;
        bool Them;
        string err;
        BlNXB dbTP = new BlNXB();
        public QLNXBcs()
        {
            InitializeComponent();
        }
        void resetTextBox()
        {
            this.txtMaNXB.ResetText();
            this.txtTenNXB.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSdt.ResetText();
        }

        void enableTextBox()
        {
            this.txtMaNXB.Enabled = true;
            this.txtTenNXB.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtSdt.Enabled = true;
        }

        void disableTextBox()
        {
            this.txtMaNXB.Enabled = false;
            this.txtTenNXB.Enabled = false;
            this.txtDiaChi.Enabled = false;
            this.txtSdt.Enabled = false;
        }

        void LoadData()
        {
            try
            {
                dtNXB = new DataTable();
                dtNXB.Clear();
                DataSet ds = dbTP.LayNXB();
                dtNXB = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                grvNXB.DataSource = dtNXB;
                // Thay đổi độ rộng cột
                grvNXB.AutoResizeColumns();
                resetTextBox();
                disableTextBox();

                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnHienThi.Enabled = true;

                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;

                grvNXB_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table . Lỗi rồi!!!");
            }
        }
        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BlNXB blTp = new BlNXB();
                    blTp.ThemNXB(this.txtMaNXB.Text, this.txtTenNXB.Text, this.txtDiaChi.Text, this.txtSdt.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                BlNXB blTp = new BlNXB();
                blTp.CapNhatNXB(this.txtMaNXB.Text, this.txtTenNXB.Text, this.txtDiaChi.Text, this.txtSdt.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void grvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = grvNXB.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNXB.Text = grvNXB.Rows[r].Cells[0].Value.ToString();
            this.txtTenNXB.Text = grvNXB.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = grvNXB.Rows[r].Cells[2].Value.ToString();
            this.txtSdt.Text = grvNXB.Rows[r].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            Them = true;
            resetTextBox();
            enableTextBox();

            this.txtMaNXB.Focus();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = grvNXB.CurrentCell.RowIndex;
                string strDG = grvNXB.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BlNXB blTp = new BlNXB();
                    string err = string.Empty;
                    blTp.XoaNXB(strDG, ref err);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            enableTextBox();
            grvNXB_CellClick(null, null);
            this.txtMaNXB.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaNXB.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetTextBox();
            disableTextBox();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;

            grvNXB_CellClick(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void QLNXBcs_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
