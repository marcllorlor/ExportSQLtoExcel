namespace PracticaIDH
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStripForm = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connexioBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esperançaDeVidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolaritzacióToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDHToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripForm
            // 
            this.MenuStripForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.importarToolStripMenuItem,
            this.consultesToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.MenuStripForm.Location = new System.Drawing.Point(0, 0);
            this.MenuStripForm.Name = "MenuStripForm";
            this.MenuStripForm.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStripForm.Size = new System.Drawing.Size(600, 24);
            this.MenuStripForm.TabIndex = 0;
            this.MenuStripForm.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexioBDToolStripMenuItem,
            this.sortirToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = ".";
            // 
            // connexioBDToolStripMenuItem
            // 
            this.connexioBDToolStripMenuItem.Name = "connexioBDToolStripMenuItem";
            this.connexioBDToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.connexioBDToolStripMenuItem.Text = "ConnexioBD";
            this.connexioBDToolStripMenuItem.Click += new System.EventHandler(this.connexioBDToolStripMenuItem_Click);
            // 
            // sortirToolStripMenuItem
            // 
            this.sortirToolStripMenuItem.Name = "sortirToolStripMenuItem";
            this.sortirToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.sortirToolStripMenuItem.Text = "Sortir";
            this.sortirToolStripMenuItem.Click += new System.EventHandler(this.sortirToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estatsToolStripMenuItem,
            this.dadesToolStripMenuItem});
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // estatsToolStripMenuItem
            // 
            this.estatsToolStripMenuItem.Name = "estatsToolStripMenuItem";
            this.estatsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.estatsToolStripMenuItem.Text = "Estats";
            this.estatsToolStripMenuItem.Click += new System.EventHandler(this.estatsToolStripMenuItem_Click);
            // 
            // dadesToolStripMenuItem
            // 
            this.dadesToolStripMenuItem.Name = "dadesToolStripMenuItem";
            this.dadesToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.dadesToolStripMenuItem.Text = "Dades";
            this.dadesToolStripMenuItem.Click += new System.EventHandler(this.dadesToolStripMenuItem_Click);
            // 
            // consultesToolStripMenuItem
            // 
            this.consultesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDHToolStripMenuItem,
            this.esperançaDeVidaToolStripMenuItem,
            this.escolaritzacióToolStripMenuItem});
            this.consultesToolStripMenuItem.Name = "consultesToolStripMenuItem";
            this.consultesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultesToolStripMenuItem.Text = "Consultes";
            
            // 
            // iDHToolStripMenuItem
            // 
            this.iDHToolStripMenuItem.Name = "iDHToolStripMenuItem";
            this.iDHToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iDHToolStripMenuItem.Text = "IDH";
            this.iDHToolStripMenuItem.Click += new System.EventHandler(this.ConsultesMenuItem_Click);
            // 
            // esperançaDeVidaToolStripMenuItem
            // 
            this.esperançaDeVidaToolStripMenuItem.Name = "esperançaDeVidaToolStripMenuItem";
            this.esperançaDeVidaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.esperançaDeVidaToolStripMenuItem.Text = "Esperança de vida";
            this.esperançaDeVidaToolStripMenuItem.Click += new System.EventHandler(this.ConsultesMenuItem_Click);
            // 
            // escolaritzacióToolStripMenuItem
            // 
            this.escolaritzacióToolStripMenuItem.Name = "escolaritzacióToolStripMenuItem";
            this.escolaritzacióToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.escolaritzacióToolStripMenuItem.Text = "Escolarització";
            this.escolaritzacióToolStripMenuItem.Click += new System.EventHandler(this.ConsultesMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDHToolStripMenuItem1});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // iDHToolStripMenuItem1
            // 
            this.iDHToolStripMenuItem1.Name = "iDHToolStripMenuItem1";
            this.iDHToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.iDHToolStripMenuItem1.Text = "IDH";
            this.iDHToolStripMenuItem1.Click += new System.EventHandler(this.iDHToolStripMenuItem1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.MenuStripForm);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStripForm;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuStripForm.ResumeLayout(false);
            this.MenuStripForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStripForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connexioBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esperançaDeVidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolaritzacióToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDHToolStripMenuItem1;
    }
}

