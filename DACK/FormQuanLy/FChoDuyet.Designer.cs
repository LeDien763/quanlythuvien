namespace DACK
{
    partial class FChoDuyet
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
            this.rdMaDG = new System.Windows.Forms.RadioButton();
            this.rdMaPhieu = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvCho = new System.Windows.Forms.DataGridView();
            this.btnduyetAll = new System.Windows.Forms.Button();
            this.Reload = new System.Windows.Forms.Button();
            this.btnXoaDon = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTim);
            this.groupBox2.Controls.Add(this.rdMaDG);
            this.groupBox2.Controls.Add(this.rdMaPhieu);
            this.groupBox2.Location = new System.Drawing.Point(38, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 146);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm Thông Tin";
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(21, 83);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(229, 30);
            this.txtTim.TabIndex = 30;
            this.txtTim.WordWrap = false;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // rdMaDG
            // 
            this.rdMaDG.AutoSize = true;
            this.rdMaDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMaDG.Location = new System.Drawing.Point(275, 30);
            this.rdMaDG.Name = "rdMaDG";
            this.rdMaDG.Size = new System.Drawing.Size(215, 24);
            this.rdMaDG.TabIndex = 31;
            this.rdMaDG.Text = "Tìm Kiếm Theo MaDG";
            this.rdMaDG.UseVisualStyleBackColor = true;
            // 
            // rdMaPhieu
            // 
            this.rdMaPhieu.AutoSize = true;
            this.rdMaPhieu.Checked = true;
            this.rdMaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMaPhieu.Location = new System.Drawing.Point(21, 30);
            this.rdMaPhieu.Name = "rdMaPhieu";
            this.rdMaPhieu.Size = new System.Drawing.Size(234, 24);
            this.rdMaPhieu.TabIndex = 30;
            this.rdMaPhieu.TabStop = true;
            this.rdMaPhieu.Text = "Tìm Kiếm Theo MaPhieu";
            this.rdMaPhieu.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(251, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(396, 42);
            this.label14.TabIndex = 37;
            this.label14.Text = "Đơn Chờ Mượn Duyệt";
            // 
            // dgvCho
            // 
            this.dgvCho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCho.Location = new System.Drawing.Point(38, 328);
            this.dgvCho.Name = "dgvCho";
            this.dgvCho.RowHeadersWidth = 51;
            this.dgvCho.RowTemplate.Height = 24;
            this.dgvCho.Size = new System.Drawing.Size(886, 231);
            this.dgvCho.TabIndex = 36;
            this.dgvCho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCho_CellClick);
            // 
            // btnduyetAll
            // 
            this.btnduyetAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.btnduyetAll.FlatAppearance.BorderSize = 0;
            this.btnduyetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnduyetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnduyetAll.ForeColor = System.Drawing.Color.White;
            this.btnduyetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnduyetAll.Location = new System.Drawing.Point(667, 176);
            this.btnduyetAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnduyetAll.Name = "btnduyetAll";
            this.btnduyetAll.Size = new System.Drawing.Size(104, 49);
            this.btnduyetAll.TabIndex = 42;
            this.btnduyetAll.Text = "Duyệt All";
            this.btnduyetAll.UseVisualStyleBackColor = false;
            this.btnduyetAll.Click += new System.EventHandler(this.btnduyetAll_Click);
            // 
            // Reload
            // 
            this.Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.Reload.FlatAppearance.BorderSize = 0;
            this.Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reload.ForeColor = System.Drawing.Color.White;
            this.Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Reload.Location = new System.Drawing.Point(802, 176);
            this.Reload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(104, 49);
            this.Reload.TabIndex = 41;
            this.Reload.Text = "Load lại";
            this.Reload.UseVisualStyleBackColor = false;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // btnXoaDon
            // 
            this.btnXoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.btnXoaDon.FlatAppearance.BorderSize = 0;
            this.btnXoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDon.Location = new System.Drawing.Point(802, 93);
            this.btnXoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaDon.Name = "btnXoaDon";
            this.btnXoaDon.Size = new System.Drawing.Size(104, 47);
            this.btnXoaDon.TabIndex = 40;
            this.btnXoaDon.Text = "Xóa Đơn";
            this.btnXoaDon.UseVisualStyleBackColor = false;
            this.btnXoaDon.Click += new System.EventHandler(this.btnXoaDon_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.btnDuyet.FlatAppearance.BorderSize = 0;
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDuyet.Location = new System.Drawing.Point(667, 93);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(104, 47);
            this.btnDuyet.TabIndex = 39;
            this.btnDuyet.Text = "Duyệt Đơn";
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // FChoDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 572);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvCho);
            this.Controls.Add(this.btnduyetAll);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.btnXoaDon);
            this.Controls.Add(this.btnDuyet);
            this.Name = "FChoDuyet";
            this.Text = "FChoDuyet";
            this.Load += new System.EventHandler(this.FChoDuyet_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.RadioButton rdMaDG;
        private System.Windows.Forms.RadioButton rdMaPhieu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCho;
        private System.Windows.Forms.Button btnduyetAll;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.Button btnXoaDon;
        private System.Windows.Forms.Button btnDuyet;
    }
}