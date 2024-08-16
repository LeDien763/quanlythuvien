namespace DACK
{
    partial class FDaMuon
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
            this.pnHOMEA = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnHOMEA
            // 
            this.pnHOMEA.Location = new System.Drawing.Point(12, 11);
            this.pnHOMEA.Name = "pnHOMEA";
            this.pnHOMEA.Size = new System.Drawing.Size(959, 661);
            this.pnHOMEA.TabIndex = 13;
            // 
            // FDaMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 683);
            this.Controls.Add(this.pnHOMEA);
            this.Name = "FDaMuon";
            this.Text = "FDaMuon";
            this.Load += new System.EventHandler(this.FDaMuon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHOMEA;
    }
}