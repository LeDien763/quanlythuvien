namespace DACK.UseControls
{
    partial class US_Sach
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNhaXB = new System.Windows.Forms.TextBox();
            this.grvNXB = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCho = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaSauSach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMaTG = new System.Windows.Forms.TextBox();
            this.Tìm = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvTacGia = new System.Windows.Forms.DataGridView();
            this.tabSach = new System.Windows.Forms.TabPage();
            this.tabTTSach = new System.Windows.Forms.TabControl();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNXB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCho)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.Tìm.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTacGia)).BeginInit();
            this.tabSach.SuspendLayout();
            this.tabTTSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNhaXB);
            this.groupBox2.Location = new System.Drawing.Point(19, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 78);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm NXB (MaNXB)";
            this.groupBox2.UseWaitCursor = true;
            // 
            // txtNhaXB
            // 
            this.txtNhaXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaXB.Location = new System.Drawing.Point(6, 21);
            this.txtNhaXB.Name = "txtNhaXB";
            this.txtNhaXB.Size = new System.Drawing.Size(266, 45);
            this.txtNhaXB.TabIndex = 5;
            this.txtNhaXB.UseWaitCursor = true;
            this.txtNhaXB.TextChanged += new System.EventHandler(this.txtNhaXB_TextChanged);
            // 
            // grvNXB
            // 
            this.grvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvNXB.Location = new System.Drawing.Point(19, 212);
            this.grvNXB.Name = "grvNXB";
            this.grvNXB.RowHeadersWidth = 51;
            this.grvNXB.RowTemplate.Height = 24;
            this.grvNXB.Size = new System.Drawing.Size(876, 287);
            this.grvNXB.TabIndex = 26;
            this.grvNXB.UseWaitCursor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(808, 264);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 51);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.UseWaitCursor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(808, 156);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 51);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.UseWaitCursor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "Danh Sách Chờ ";
            this.label3.UseWaitCursor = true;
            // 
            // dgvCho
            // 
            this.dgvCho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCho.Location = new System.Drawing.Point(6, 429);
            this.dgvCho.Name = "dgvCho";
            this.dgvCho.RowHeadersWidth = 51;
            this.dgvCho.RowTemplate.Height = 24;
            this.dgvCho.Size = new System.Drawing.Size(769, 143);
            this.dgvCho.TabIndex = 24;
            this.dgvCho.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaSauSach);
            this.groupBox1.Location = new System.Drawing.Point(19, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 78);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm Sách(MaDauSach)";
            this.groupBox1.UseWaitCursor = true;
            // 
            // txtMaSauSach
            // 
            this.txtMaSauSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSauSach.Location = new System.Drawing.Point(6, 21);
            this.txtMaSauSach.Name = "txtMaSauSach";
            this.txtMaSauSach.Size = new System.Drawing.Size(274, 45);
            this.txtMaSauSach.TabIndex = 5;
            this.txtMaSauSach.UseWaitCursor = true;
            this.txtMaSauSach.TextChanged += new System.EventHandler(this.txtMaSauSach_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(293, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 51);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nhà Xuất Bản";
            this.label2.UseWaitCursor = true;
            // 
            // dgvSach
            // 
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(6, 156);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(769, 219);
            this.dgvSach.TabIndex = 2;
            this.dgvSach.UseWaitCursor = true;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.grvNXB);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(917, 578);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Nhà Xuất Bản";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.UseWaitCursor = true;
            // 
            // txtMaTG
            // 
            this.txtMaTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTG.Location = new System.Drawing.Point(6, 21);
            this.txtMaTG.Name = "txtMaTG";
            this.txtMaTG.Size = new System.Drawing.Size(270, 45);
            this.txtMaTG.TabIndex = 5;
            this.txtMaTG.UseWaitCursor = true;
            this.txtMaTG.TextChanged += new System.EventHandler(this.txtMaTG_TextChanged);
            // 
            // Tìm
            // 
            this.Tìm.Controls.Add(this.txtMaTG);
            this.Tìm.Location = new System.Drawing.Point(25, 88);
            this.Tìm.Name = "Tìm";
            this.Tìm.Size = new System.Drawing.Size(303, 78);
            this.Tìm.TabIndex = 24;
            this.Tìm.TabStop = false;
            this.Tìm.Text = "Tìm Kiếm Tác Giả (MaTG)";
            this.Tìm.UseWaitCursor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(378, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 51);
            this.label11.TabIndex = 1;
            this.label11.Text = "Sách";
            this.label11.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(342, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 51);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tác Giả";
            this.label1.UseWaitCursor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.gvTacGia);
            this.tabPage1.Controls.Add(this.Tìm);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 578);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tác Giả";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.UseWaitCursor = true;
            // 
            // gvTacGia
            // 
            this.gvTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTacGia.Location = new System.Drawing.Point(25, 212);
            this.gvTacGia.Name = "gvTacGia";
            this.gvTacGia.RowHeadersWidth = 51;
            this.gvTacGia.RowTemplate.Height = 24;
            this.gvTacGia.Size = new System.Drawing.Size(876, 269);
            this.gvTacGia.TabIndex = 22;
            this.gvTacGia.UseWaitCursor = true;
            // 
            // tabSach
            // 
            this.tabSach.Controls.Add(this.btnXoa);
            this.tabSach.Controls.Add(this.btnThem);
            this.tabSach.Controls.Add(this.label3);
            this.tabSach.Controls.Add(this.dgvCho);
            this.tabSach.Controls.Add(this.groupBox1);
            this.tabSach.Controls.Add(this.dgvSach);
            this.tabSach.Controls.Add(this.label11);
            this.tabSach.Location = new System.Drawing.Point(4, 25);
            this.tabSach.Name = "tabSach";
            this.tabSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabSach.Size = new System.Drawing.Size(917, 578);
            this.tabSach.TabIndex = 1;
            this.tabSach.Text = "Sách";
            this.tabSach.UseVisualStyleBackColor = true;
            this.tabSach.UseWaitCursor = true;
            // 
            // tabTTSach
            // 
            this.tabTTSach.Controls.Add(this.tabSach);
            this.tabTTSach.Controls.Add(this.tabPage1);
            this.tabTTSach.Controls.Add(this.tabPage3);
            this.tabTTSach.Location = new System.Drawing.Point(19, 13);
            this.tabTTSach.Name = "tabTTSach";
            this.tabTTSach.SelectedIndex = 0;
            this.tabTTSach.Size = new System.Drawing.Size(925, 607);
            this.tabTTSach.TabIndex = 23;
            this.tabTTSach.UseWaitCursor = true;
            // 
            // US_Sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTTSach);
            this.Name = "US_Sach";
            this.Size = new System.Drawing.Size(960, 635);
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.US_Sach_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNXB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCho)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.Tìm.ResumeLayout(false);
            this.Tìm.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTacGia)).EndInit();
            this.tabSach.ResumeLayout(false);
            this.tabSach.PerformLayout();
            this.tabTTSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNhaXB;
        private System.Windows.Forms.DataGridView grvNXB;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaSauSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtMaTG;
        private System.Windows.Forms.GroupBox Tìm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvTacGia;
        private System.Windows.Forms.TabPage tabSach;
        private System.Windows.Forms.TabControl tabTTSach;
    }
}
