namespace DACK.UseControls
{
    partial class US_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_Home));
            this.dgvTB = new System.Windows.Forms.DataGridView();
            this.tableAdapterManager1 = new DACK.TestDataSetTableAdapters.TableAdapterManager();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTB
            // 
            this.dgvTB.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTB.Location = new System.Drawing.Point(115, 375);
            this.dgvTB.Name = "dgvTB";
            this.dgvTB.RowHeadersWidth = 51;
            this.dgvTB.RowTemplate.Height = 24;
            this.dgvTB.Size = new System.Drawing.Size(733, 151);
            this.dgvTB.TabIndex = 34;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.tbChoDuyetTableAdapter = null;
            this.tableAdapterManager1.tbDauSachTableAdapter = null;
            this.tableAdapterManager1.tbDGTableAdapter = null;
            this.tableAdapterManager1.tbMKTableAdapter = null;
            this.tableAdapterManager1.tbNXBTableAdapter = null;
            this.tableAdapterManager1.tbPhieuMuonTableAdapter = null;
            this.tableAdapterManager1.tbTGTableAdapter = null;
            this.tableAdapterManager1.tbTheTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = DACK.TestDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(337, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 279);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // lbTB
            // 
            this.lbTB.AutoSize = true;
            this.lbTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTB.Location = new System.Drawing.Point(123, 330);
            this.lbTB.Name = "lbTB";
            this.lbTB.Size = new System.Drawing.Size(171, 36);
            this.lbTB.TabIndex = 35;
            this.lbTB.Text = "Thông Báo";
            // 
            // US_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "US_Home";
            this.Size = new System.Drawing.Size(962, 584);
            this.Load += new System.EventHandler(this.US_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTB;
        private TestDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTB;
    }
}
