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
    public partial class QLSach : Form
    {
        public QLSach()
        {
            InitializeComponent();
        }
        DataTable dtSach = null;
        string err;
        bool Them;
        BLQLS bdSach = new BLQLS();
        void enableTextBox()
        {
            this.txtMaDauSach.Enabled = true;
            this.txtTenSach.Enabled = true;
            this.txtNBX.Enabled = true;
            this.txtChuyenganh.Enabled = true;
            this.txtMaTG.Enabled = true;
            this.txtNamSx.Enabled = true;
            this.txtsoluong.Enabled = true;
            this.txtGhichu.Enabled = true;
        }

        void disableTextBox()
        {
            this.txtMaDauSach.Enabled = false;
            this.txtTenSach.Enabled = false;
            this.txtNBX.Enabled = false;
            this.txtChuyenganh.Enabled = false;
            this.txtMaTG.Enabled = false;
            this.txtNamSx.Enabled = false;
            this.txtsoluong.Enabled = false;
            this.txtGhichu.Enabled = false;
        }
        void resetTextBox()
        {
            this.txtMaDauSach.ResetText();
            this.txtTenSach.ResetText();
            this.txtNBX.ResetText();
            this.txtMaTG.ResetText();
            this.txtNamSx.ResetText();
            this.txtChuyenganh.ResetText();
            this.txtsoluong.ResetText();
            this.txtGhichu.ResetText();
        }
        void LoadData()
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
                resetTextBox();
                disableTextBox();

                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnHienThi.Enabled = true;

                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                //
                dgvSach_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!");
            }
        }
        private void txtMaDauSach_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    BLQLS blTp = new BLQLS();
                    int soluong;
                    if (int.TryParse(this.txtsoluong.Text, out soluong))
                    {
                        blTp.ThemSach(this.txtMaDauSach.Text, this.txtTenSach.Text, this.txtNBX.Text, this.txtMaTG.Text, this.txtNamSx.Text, this.txtChuyenganh.Text, soluong, this.txtGhichu.Text, ref err);
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên.");
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                // Thực hiện lệnh
                BLQLS blTp = new BLQLS();
                int soluong;
                if (int.TryParse(this.txtsoluong.Text, out soluong))
                {
                    blTp.CapNhatSach(this.txtMaDauSach.Text, this.txtTenSach.Text, this.txtNBX.Text, this.txtMaTG.Text, this.txtNamSx.Text, this.txtChuyenganh.Text, soluong, this.txtGhichu.Text, ref err);
                    // Thông báo
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên.");
                }
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSach.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaDauSach.Text = dgvSach.Rows[r].Cells[0].Value.ToString();
            this.txtTenSach.Text = dgvSach.Rows[r].Cells[1].Value.ToString();
            this.txtNBX.Text = dgvSach.Rows[r].Cells[2].Value.ToString();
            this.txtMaTG.Text = dgvSach.Rows[r].Cells[3].Value.ToString();
            this.txtNamSx.Text = dgvSach.Rows[r].Cells[4].Value.ToString();
            this.txtChuyenganh.Text = dgvSach.Rows[r].Cells[5].Value.ToString();
            this.txtsoluong.Text = dgvSach.Rows[r].Cells[6].Value.ToString();
            this.txtGhichu.Text = dgvSach.Rows[r].Cells[7].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            resetTextBox();
            enableTextBox();

            this.txtMaDauSach.Focus();

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

                int r = dgvSach.CurrentCell.RowIndex;
                string strDG = dgvSach.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLQLS blTp = new BLQLS();
                    string err = string.Empty;
                    blTp.XoaSach(strDG, ref err);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetTextBox();
            disableTextBox();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;

            dgvSach_CellClick(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            enableTextBox();
            dgvSach_CellClick(null, null);
            this.txtMaDauSach.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaDauSach.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void QLSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
