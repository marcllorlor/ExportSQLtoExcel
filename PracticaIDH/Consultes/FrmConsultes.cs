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
using PracticaIDH.Comparacions;
using PracticaIDH.FormConnexioBD;

namespace PracticaIDH.Consultes
{
    public partial class FrmConsultes : Form
    {

        SqlConnection connSQL = null;
        String tipusConsulta { get; set; } = "";

        ClDadesEstats dades = null;

        DataSet dsetDades = new DataSet();

        //FrmComparacio frmComparacio = null;

        //ClDadesEstats estdades;


        public FrmConsultes(SqlConnection xsqlConn, String xconsulta)
        {
            connSQL = xsqlConn;
            tipusConsulta = xconsulta;
            InitializeComponent();
        }

        private void FrmConsultes_Load(object sender, EventArgs e)
        {
            dades = new ClDadesEstats(connSQL, tipusConsulta);
            //Aqui es a on farem tota la consulta de la informacio que ens han passat
            qryDades();
            
        }

        private void qryDades()
        {
            dsetDades.Clear();
            if(dades.llistaDadesEstats(ref dsetDades))
            {
                dgConsulta.DataSource = dsetDades.Tables[0];
            }
            else
            {
                dgConsulta.DataSource = null;
            }
        }

        

        private void dgConsulta_DoubleClick(object sender, EventArgs e)
        {
            //Quan entrem aqui ya tindrem el datagridview construit amb totes les dades de tots els estats
            Int32 numerofilatriada = dgConsulta.CurrentCell.RowIndex + 1;
            Int32 numerofilapais = 0;

            Int32 cantitatfilesdatagridview = dgConsulta.RowCount;

            String valorfilatriada = dgConsulta.SelectedRows[0].Cells[1].Value.ToString();
            String valorfilalocal = "";

            String nomestat = dgConsulta.SelectedRows[0].Cells["nomEstat"].Value.ToString();

            for (int i = 0; i < cantitatfilesdatagridview; i++)
            {
                if(dgConsulta.Rows[i].Cells["nomEstat"].Value.ToString() == "Spain")
                {
                    numerofilapais = i + 1;
                    valorfilalocal = dgConsulta.Rows[i].Cells[1].Value.ToString();
                }
            }


            if (dgConsulta.SelectedRows.Count > 0)
            {
                FrmComparacio frmComparacio = new FrmComparacio(connSQL, tipusConsulta, nomestat, numerofilatriada.ToString(), numerofilapais.ToString(), valorfilatriada.ToString(), valorfilalocal.ToString());
                //frmComparacio.MdiParent = this;           // --- hem fet que FRM_MAIN sigui MdiContainer i posem aquest Form com a fill seu ---
                frmComparacio.WindowState = FormWindowState.Normal;
                frmComparacio.Location = new System.Drawing.Point(0, 0);
                frmComparacio.Show();



                //FrmComparacio frmComparacio = new FrmComparacio(connSQL, tipusConsulta, dgConsulta.SelectedRows[0].Cells["nomEstat"].Value.ToString());


            }
        }
    }
}
