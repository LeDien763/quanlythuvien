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
    public partial class QLTacGiacs : Form
    {
        public QLTacGiacs()
        {
            InitializeComponent();
        }
        DataTable dtTG = null;
        bool Them;
        string err;
        BLTacGiaA dbTP = new BLTacGiaA();
        void resetTextBox()
        {
            this.txtMaTG.ResetText();
            this.txtTenTG.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSdt.ResetText();
            this.txtEmail.ResetText();
        }

        void enableTextBox()
        {
            this.txtMaTG.Enabled = true;
            this.txtTenTG.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtSdt.Enabled = true;
            this.txtEmail.Enabled = true;
        }

        void disableTextBox()
        {
            this.txtMaTG.Enabled = false;
            this.txtTenTG.Enabled = false;
            this.txtDiaChi.Enabled = false;
            this.txtSdt.Enabled = false;
            this.txtEmail.Enabled = false;
        }
        void LoadData()
        {
            try
            {
                dtTG = new DataTable();
                dtTG.Clear();
                DataSet ds = dbTP.LayTacGia();
                dtTG = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                grvTacGia.DataSource = dtTG;
                // Thay đổi độ rộng cột
                grvTacGia.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                resetTextBox();
                disableTextBox();

                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnHienThi.Enabled = true;

                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;

                grvTacGia_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table . Lỗi rồi!!!");
            }
        }
        private void grvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = grvTacGia.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaTG.Text = grvTacGia.Rows[r].Cells[0].Value.ToString();
            this.txtTenTG.Text = grvTacGia.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = grvTacGia.Rows[r].Cells[2].Value.ToString();
            this.txtSdt.Text = grvTacGia.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text = grvTacGia.Rows[r].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            resetTextBox();
            enableTextBox();

            this.txtMaTG.Focus();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            enableTextBox();
            grvTacGia_CellClick(null, null);
            this.txtMaTG.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaTG.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = grvTacGia.CurrentCell.RowIndex;
                string strDG = grvTacGia.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLTacGiaA blTp = new BLTacGiaA();
                    string err = string.Empty;
                    blTp.XoaTacGia(strDG, ref err);
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
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

            grvTacGia_CellClick(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLTacGiaA blTp = new BLTacGiaA();
                    blTp.ThemTacGia(this.txtMaTG.Text, this.txtTenTG.Text, this.txtDiaChi.Text, this.txtSdt.Text, this.txtEmail.Text, ref err);
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
                BLTacGiaA blTp = new BLTacGiaA();
                blTp.CapNhatTacGia(this.txtMaTG.Text, this.txtTenTG.Text, this.txtDiaChi.Text, this.txtSdt.Text, this.txtEmail.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void QLTacGiacs_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
