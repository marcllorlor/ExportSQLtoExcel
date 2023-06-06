namespace PracticaIDH.FormConnexioBD
{
    partial class frmBD
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
            this.btNo = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.tbCadena = new System.Windows.Forms.TextBox();
            this.lbCadena = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btNo
            // 
            this.btNo.BackColor = System.Drawing.Color.Red;
            this.btNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNo.ForeColor = System.Drawing.Color.White;
            this.btNo.Location = new System.Drawing.Point(402, 75);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(107, 34);
            this.btNo.TabIndex = 7;
            this.btNo.Text = "&Cancel·lar";
            this.btNo.UseVisualStyleBackColor = false;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Green;
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(212, 75);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(107, 34);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "&Acceptar";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tbCadena
            // 
            this.tbCadena.Location = new System.Drawing.Point(12, 32);
            this.tbCadena.Name = "tbCadena";
            this.tbCadena.Size = new System.Drawing.Size(737, 22);
            this.tbCadena.TabIndex = 5;
            // 
            // lbCadena
            // 
            this.lbCadena.AutoSize = true;
            this.lbCadena.Location = new System.Drawing.Point(9, 14);
            this.lbCadena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCadena.Name = "lbCadena";
            this.lbCadena.Size = new System.Drawing.Size(131, 16);
            this.lbCadena.TabIndex = 4;
            this.lbCadena.Text = "Cadena de connexió";
            // 
            // frmBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbCadena);
            this.Controls.Add(this.lbCadena);
            this.Name = "frmBD";
            this.Text = "frmBD";
            this.Load += new System.EventHandler(this.frmBD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TextBox tbCadena;
        private System.Windows.Forms.Label lbCadena;
    }
}