namespace PracticaIDH.Comparacions
{
    partial class FrmComparacio
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
            this.lbpaistriat = new System.Windows.Forms.Label();
            this.lbpaislocal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbpaistriat
            // 
            this.lbpaistriat.AutoSize = true;
            this.lbpaistriat.Location = new System.Drawing.Point(66, 93);
            this.lbpaistriat.Name = "lbpaistriat";
            this.lbpaistriat.Size = new System.Drawing.Size(35, 13);
            this.lbpaistriat.TabIndex = 0;
            this.lbpaistriat.Text = "label1";
            
            // 
            // lbpaislocal
            // 
            this.lbpaislocal.AutoSize = true;
            this.lbpaislocal.Location = new System.Drawing.Point(66, 125);
            this.lbpaislocal.Name = "lbpaislocal";
            this.lbpaislocal.Size = new System.Drawing.Size(35, 13);
            this.lbpaislocal.TabIndex = 1;
            this.lbpaislocal.Text = "label2";
            
            // 
            // FrmComparacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbpaislocal);
            this.Controls.Add(this.lbpaistriat);
            this.Name = "FrmComparacio";
            this.Text = "FrmComparacio";
            this.Load += new System.EventHandler(this.FrmComparacio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbpaistriat;
        private System.Windows.Forms.Label lbpaislocal;
    }
}