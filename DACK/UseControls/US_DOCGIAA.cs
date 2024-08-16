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
    public partial class US_DOCGIAA : UserControl
    {
        public US_DOCGIAA()
        {
            InitializeComponent();
        }

       
        DataTable dtDGA = null;
        bool Them;
        string err;
        BLDocGiaA dbGDA = new BLDocGiaA();
        void resetTextBox()
        {
            this.txtMaDG.ResetText();
            this.txtTen.ResetText();
            this.txtchucVu.ResetText();
            this.txtLop.ResetText();
            this.txtKhoa.ResetText();
            this.dateTimeDate.Value = DateTime.Now;
            this.cmbGT.ResetText();
            this.txtGhiChu.ResetText();
            this.txtTim.ResetText();
        }

        void enableTextBox()
        {
            this.txtMaDG.Enabled = true;
            this.txtTen.Enabled = true;
            this.txtchucVu.Enabled = true;
            this.txtLop.Enabled = true;
            this.txtKhoa.Enabled = true;
            this.dateTimeDate.Value = DateTime.Now;
            this.dateTimeDate.Enabled = true;
            this.cmbGT.Enabled = true;
            this.txtGhiChu.Enabled = true;
        }

        void disableTextBox()
        {
            this.txtMaDG.Enabled = false;
            this.txtTen.Enabled = false;
            this.txtchucVu.Enabled = false;
            this.txtLop.Enabled = false;
            this.txtKhoa.Enabled = false;
            this.dateTimeDate.Value = DateTime.Now;
            this.dateTimeDate.Enabled = false;
            this.cmbGT.Enabled = false;
            this.txtGhiChu.Enabled = false;
        }

        void LoadData()
        {
            try
            {
                dtDGA = new DataTable();
                dtDGA.Clear();
                 
                dtDGA = dbGDA.LayDocGia();
                // Đưa dữ liệu lên DataGridView
                dgvThemDGA.DataSource = dtDGA;
                // Thay đổi độ rộng cột
                dgvThemDGA.AutoResizeColumns();
                resetTextBox();
                disableTextBox();

                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnHienThi.Enabled = true;

                this.btnLuu.Enabled = false;
                this.btnHUy.Enabled = false;


                dgvDGA_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DocGia. Lỗi rồi!!!");
            }
        }
        private void dgvDGA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvThemDGA.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaDG.Text =  dgvThemDGA.Rows[r].Cells[0].Value.ToString();
            this.txtTen.Text = dgvThemDGA.Rows[r].Cells[1].Value.ToString();
            this.txtchucVu.Text =  dgvThemDGA.Rows[r].Cells[2].Value.ToString();
            this.txtLop.Text =  dgvThemDGA.Rows[r].Cells[3].Value.ToString();
            this.txtKhoa.Text = dgvThemDGA.Rows[r].Cells[4].Value.ToString();
            //this.dateTimeDate.Text = dgvThemDGA.Rows[r].Cells[5].Value.ToString();

            object value1 = dgvThemDGA.Rows[r].Cells[5].Value;
           

            if (value1 != null && value1 != DBNull.Value && DateTime.TryParse(value1.ToString(), out DateTime dateTimeValue1))
            {
                this.dateTimeDate.Value = dateTimeValue1;
            }


            this.cmbGT.Text = dgvThemDGA.Rows[r].Cells[6].Value.ToString();
            this.txtGhiChu.Text = dgvThemDGA.Rows[r].Cells[7].Value.ToString();
        }



        private void btnThemm_Click(object sender, EventArgs e)
        {
            Them = true;
            resetTextBox();
            enableTextBox();
            this.txtMaDG.Focus();

            this.btnLuu.Enabled = true;
            this.btnHUy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void US_DOCGIAA_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grQLS_Enter(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime selectedNgayMuon = this.dateTimeDate.Value;

            string TraString = selectedNgayMuon.ToString("dd/MM/yyyy");
            if (Them)
            {
                try
                {
                    BLDocGiaA blTp = new BLDocGiaA();
                    blTp.ThemDocGia(this.txtMaDG.Text, this.txtTen.Text, this.txtchucVu.Text, this.txtLop.Text, this.txtKhoa.Text, TraString, this.cmbGT.Text, this.txtGhiChu.Text, ref err);
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
                BLDocGiaA blTp = new BLDocGiaA();
                blTp.CapNhatDocGia(this.txtMaDG.Text, this.txtTen.Text, this.txtchucVu.Text, this.txtLop.Text, this.txtKhoa.Text, TraString, this.cmbGT.Text, this.txtGhiChu.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = dgvThemDGA.CurrentCell.RowIndex;
                string strDG = dgvThemDGA.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLDocGiaA blTp = new BLDocGiaA();
                    string err = string.Empty;
                    blTp.XoaDocGia(strDG, ref err);
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
            dgvDGA_CellClick(null, null);
            enableTextBox();
            this.txtMaDG.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHUy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaDG.Focus();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            resetTextBox();
            disableTextBox();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.btnLuu.Enabled = false;
            this.btnHUy.Enabled = false;

            dgvDGA_CellClick(null, null);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLDocGiaA blDocGia = new BLDocGiaA();
            DataSet searchResult = null;
            if (txtTim.Text != "")
            {
                if (rdMaDG.Checked == true)
                {
                    searchResult = blDocGia.TimKiemDG(readerName, ref error);
                }
                else if (rdTenDG.Checked == true)
                {
                    searchResult = blDocGia.TimKiemTenDG(readerName, ref error);
                }

                if (searchResult != null)
                {
                    dgvThemDGA.DataSource = searchResult.Tables[0];
                }
                else
                {
                    MessageBox.Show("Error occurred during search.");
                }
            }
            else LoadData();

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string readerName = txtTim.Text;
            string error = string.Empty;
            BLDocGiaA blDocGia = new BLDocGiaA();
            DataSet searchResult = null;
            if (txtTim.Text != "")
            {
                if (rdMaDG.Checked == true)
                {
                    searchResult = blDocGia.TimKiemDG(readerName, ref error);
                }
                else if (rdTenDG.Checked == true)
                {
                    searchResult = blDocGia.TimKiemTenDG(readerName, ref error);
                }

                if (searchResult != null)
                {
                    dgvThemDGA.DataSource = searchResult.Tables[0];
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
