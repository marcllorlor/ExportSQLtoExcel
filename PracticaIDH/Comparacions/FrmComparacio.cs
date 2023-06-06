using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaIDH.Comparacions
{
    public partial class FrmComparacio : Form
    {

        SqlConnection connSQL;
        String tipusconsulta { get; set; } = "";
        String nomEstat { get; set; } = "";

        ClDadesEstats dadesest = null;

        DataSet dsetDades = new DataSet();

        String numerofilatraida = "";
        String numerofilapais = "";

        String valorfilatriada = "";
        String valorfilalocal = "";

        public FrmComparacio(SqlConnection xconnSQL, String xtipusconsulta, String xnomEstat, String xnumerofilatraida, String xnumerofilapais, String xvalorfilatriada, String xvalorfilalocal)
        {
            connSQL = xconnSQL;
            tipusconsulta = xtipusconsulta;
            nomEstat = xnomEstat;
            dadesest = new ClDadesEstats(ref xconnSQL);
            numerofilatraida = xnumerofilatraida;
            numerofilapais = xnumerofilapais;

            valorfilalocal = xvalorfilalocal;
            valorfilatriada = xvalorfilatriada;

            InitializeComponent();
        }

        private void FrmComparacio_Load(object sender, EventArgs e)
        {
            //qrycomparacio();
            qrycomparacio2();
        }

        private void qrycomparacio()
        {
            /*dsetDades.Clear();
            Boolean xl = false;
            switch (tipusconsulta)
            {
                case "IDH": this.Text = "Comparació de IDH"  ; xl = dadesest.comparacioIDH(ref dsetDades, nomEstat); break;
                case "Esperança de vida": this.Text = "Comparació de Vida"; xl = dadesest.comparacioVida(ref dsetDades, nomEstat); break;
                case "Escolarització": this.Text = "Comparació de Escolaritzacio"; xl = dadesest.comparacioEscolarització(ref dsetDades, nomEstat); break;
            }
            if (xl)
            {
                dgComparacio.DataSource = dsetDades.Tables[0];
            }
            else
            {
                dgComparacio.DataSource = null;
            }*/
        }

        private void qrycomparacio2()
        {
            lbpaistriat.Text = "Pais escollit: " + nomEstat + " amb un valor " + tipusconsulta + " : " + valorfilatriada + " (" + numerofilatraida + ")";
            lbpaislocal.Text = "Pais Local: " + "Espanya" + " amb un valor " + tipusconsulta + " : " + valorfilalocal + " (" + numerofilapais + ")";
        }

        

        
    }
}
