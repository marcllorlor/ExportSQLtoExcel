namespace PracticaIDH.Consultes
{
    partial class FrmConsultes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgConsulta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgConsulta
            // 
            this.dgConsulta.AllowUserToAddRows = false;
            this.dgConsulta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsulta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgConsulta.Location = new System.Drawing.Point(0, 0);
            this.dgConsulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgConsulta.MultiSelect = false;
            this.dgConsulta.Name = "dgConsulta";
            this.dgConsulta.ReadOnly = true;
            this.dgConsulta.RowHeadersVisible = false;
            this.dgConsulta.RowHeadersWidth = 51;
            this.dgConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsulta.Size = new System.Drawing.Size(1077, 457);
            this.dgConsulta.TabIndex = 0;
            
            this.dgConsulta.DoubleClick += new System.EventHandler(this.dgConsulta_DoubleClick);
            // 
            // FrmConsultes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 571);
            this.Controls.Add(this.dgConsulta);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmConsultes";
            this.Text = "FrmConsultes";
            this.Load += new System.EventHandler(this.FrmConsultes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgConsulta;
    }
}