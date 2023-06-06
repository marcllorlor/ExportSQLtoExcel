using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaIDH.FormConnexioBD
{
    public partial class frmBD : Form
    {
        public frmBD()
        {
            InitializeComponent();
        }

        private void frmBD_Load(object sender, EventArgs e)
        {
            this.Size = new Size(600, 191);
            tbCadena.Text = ((frmMain)this.MdiParent).contingutarxiu;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            StreamWriter fcfg;

            ((frmMain)this.MdiParent).contingutarxiu = tbCadena.Text.Trim();

            //En aquest if haurem de fer la connexio a la base de dades, que ens retornara un true o un false depenent de si ha pogut fer la connexio
            if (((frmMain)this.MdiParent).obrirConnexio(tbCadena.Text.Trim()))
            {
                fcfg = new StreamWriter(((frmMain)this.MdiParent).nomfitxercfg, false);
                fcfg.WriteLine(tbCadena.Text.Trim());
                fcfg.Close();
                ((frmMain)this.MdiParent).opcionsMenuGestio(true);
                this.Close();
            }
            else
            {
                //Aqui entrara si esta false i no sha pogut fer la connexio
                ((frmMain)this.MdiParent).opcionsMenuGestio(false);
            }

            //Aqui haurem de crear una funcio per tornar


        }

        
    }
}
