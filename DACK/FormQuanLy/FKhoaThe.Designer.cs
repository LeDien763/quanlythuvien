namespace DACK
{
    partial class FKhoaThe
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.rdmaDG = new System.Windows.Forms.RadioButton();
            this.rdMaT = new System.Windows.Forms.RadioButton();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTim);
            this.groupBox2.Controls.Add(this.rdmaDG);
            this.groupBox2.Controls.Add(this.rdMaT);
            this.groupBox2.Location = new System.Drawing.Point(34, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 146);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm Thẻ";
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(39, 80);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(372, 38);
            this.txtTim.TabIndex = 30;
            this.txtTim.WordWrap = false;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // rdmaDG
            // 
            this.rdmaDG.AutoSize = true;
            this.rdmaDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdmaDG.Location = new System.Drawing.Point(294, 30);
            this.rdmaDG.Name = "rdmaDG";
            this.rdmaDG.Size = new System.Drawing.Size(209, 24);
            this.rdmaDG.TabIndex = 31;
            this.rdmaDG.Text = "Tìm Kiếm Theo Phiếu";
            this.rdmaDG.UseVisualStyleBackColor = true;
            // 
            // rdMaT
            // 
            this.rdMaT.AutoSize = true;
            this.rdMaT.Checked = true;
            this.rdMaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMaT.Location = new System.Drawing.Point(21, 30);
            this.rdMaT.Name = "rdMaT";
            this.rdMaT.Size = new System.Drawing.Size(218, 24);
            this.rdMaT.TabIndex = 30;
            this.rdMaT.TabStop = true;
            this.rdMaT.Text = "Tìm Kiếm Theo MaThẻ";
            this.rdMaT.UseVisualStyleBackColor = true;
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Location = new System.Drawing.Point(34, 270);
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.RowHeadersWidth = 51;
            this.dgvKhoa.RowTemplate.Height = 24;
            this.dgvKhoa.Size = new System.Drawing.Size(727, 308);
            this.dgvKhoa.TabIndex = 41;
            this.dgvKhoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvPhieuMuon_CellClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(634, 166);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(127, 45);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label32.Location = new System.Drawing.Point(268, 17);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(211, 42);
            this.label32.TabIndex = 39;
            this.label32.Text = "Phiếu Phạt";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(634, 99);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(127, 45);
            this.btnXoa.TabIndex = 43;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FKhoaThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvKhoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.btnXoa);
            this.Name = "FKhoaThe";
            this.Text = "FKhoaThe";
            this.Load += new System.EventHandler(this.FKhoaThe_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.RadioButton rdmaDG;
        private System.Windows.Forms.RadioButton rdMaT;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnXoa;
    }
}