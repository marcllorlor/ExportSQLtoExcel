using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PracticaIDH.Consultes;
using PracticaIDH.FormConnexioBD;


namespace PracticaIDH
{
    public partial class frmMain : Form
    {
        //Aqui farem les declaracion de les classes
        ClEstats est = null;
        ClDadesEstats dadesest = null;

        //Aqui farem la declaracio de la base de dades
        public SqlConnection connexioSQL = new SqlConnection();

        //Aqui farem la declaracio de tots els formularis que farem servir
        frmBD fBD;
        FrmConsultes frmConsultes;

        //Aqui farem la declaracio de tota la informacio referent al arxiu de la base de dades
        public string nomfitxercfg = "CFGBD.TXT";
        public string contingutarxiu = "";

        //Aqui tindrem la informacio que esta a dins del excel
        Workbook xwb;

        //Aqui declararem el nom de l'arxiu que acabarem d'obrir
        OpenFileDialog dlgFixter = new OpenFileDialog();

        public frmMain()
        {
            InitializeComponent();
        }

        private void sortirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dlgFixter.Title = "Selecciona un arxiu d'Excel"; //Aqui estem canviant el valor de la finestra de obrir un fitxer
            dlgFixter.Filter = "fitxers Excel 2007 (*.xlsx)|*.xlsx|fitxers Excel (*.xls)|*.xls|All files (*.*)|*.*"; //Aqui estem filtrant els fitxers que podra fer servir la persona
            dlgFixter.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            funcioobrirconnexiosql();
            //Aqui abans de tot arrancarem les classes
            funcioobrirclasses();

            //Aqui estic canviant la mida del form principal
            this.Size = new Size(900, 900);
            this.WindowState = FormWindowState.Maximized;

            //Aqui estic posant el valor del fitxer de bd a dins de una variable global
            

            

            
        }

        private void funcioobrirconnexiosql()
        {
            StreamReader fcfg;
            if (File.Exists(nomfitxercfg))
            {
                fcfg = new StreamReader(nomfitxercfg);
                contingutarxiu = fcfg.ReadToEnd().Trim();
                fcfg.Close();
                //opcionsMenuGestio(obrirConnexio(xconn));

                //Aqui hauriem de fer la comprovacio de que la connexio esta ben feta
                opcionsMenuGestio(obrirConnexio(contingutarxiu)); //Si la connexio ha sigut un succes la funcio de opcionsMenuGestio rebra un treu si no un false
            }
            else
            {
                //Aqui hauras indicat malament o no hauras indicat el nom de l'arxiu de la connexio a la base de dades

                //connexioSQL.ConnectionString = "";
                //opcionsMenuGestio(false);
            }
        }

        private void funcioobrirclasses()
        {
            //Aqui encara hem de fer una altre funcio per fer la crida a la classe de dades
            est = new ClEstats(ref connexioSQL);
            dadesest = new ClDadesEstats(ref connexioSQL);
        }

        Boolean ja_està_obert(String xnom_frm)
        {
            //Aquesta es la funcio que farem servir per saber si una pagina ja esta oberta actualment o no
            int x1 = 0;
            Boolean xb = false;

            while ((x1 < this.MdiChildren.Length) && (!(xb)))
            {
                xb = (this.MdiChildren[x1].Name == xnom_frm);
                x1++;
            }
            return (xb); //Aqui retornara el valor TRUE si esta oberta i FALSE si la pagina no esta oberta
        }

        public Boolean obrirConnexio(String xconn)
        {
            //Aquesta es la funcio que farem servir per obrir la connexio a la base de dades
            Boolean xb = false;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Aqui es a on peta el programa sense rao aparament
                connexioSQL = new SqlConnection(xconn);
                connexioSQL.Open();                     // Amb Open només validem si es té connexió amb el servidor però no si hi ha la BD dins d'aquest servidor
                xb = (connexioSQL.State == ConnectionState.Open);

            }
            catch (Exception excp)
            {
                MessageBox.Show("No s'ha pogut crear la conexio, torna a provar de fer la conexió : " + excp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(excp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            return (xb);
        }

        public void opcionsMenuGestio(Boolean xb)
        {
            //Depenent de l'estat de la connexio de la base de dades rebra un true o un false
            importarToolStripMenuItem.Enabled = xb;
            exportarToolStripMenuItem.Enabled = xb;
            consultesToolStripMenuItem.Enabled = xb;
        }

        

        private void connexioBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ja_està_obert("frmBD"))
            {
                //Recorda que sempre per obrir un nou formulari hem de tenir el mdi parent activat
                fBD = new frmBD();
                fBD.MdiParent = this;           // --- hem fet que FRM_MAIN sigui MdiContainer i posem aquest Form com a fill seu ---

                fBD.WindowState = FormWindowState.Normal;
                fBD.Location = new System.Drawing.Point(0, 0);
                fBD.Show();
            }

        }

        private void estatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (funcioobrirarxiu())
            {
                //Aqui haurem de fer fer alguna cosa per tal de pasarli el valor de dlgFitxer
                funcioimportardades("Estats");
            }
            
        }

        private void dadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (funcioobrirarxiu())
            {
                //Aqui haurem de fer fer alguna cosa per tal de pasarli el valor de dlgFitxer
                funcioimportardades("Dades");
            }
        }

        private bool funcioobrirarxiu()
        {
            Boolean xb = false;
            if (dlgFixter.ShowDialog() == DialogResult.OK)
            {
                //Aqui es a on ridem la funcio i afegirem els valors a la ataula o a la base de dades
                importarExcel(dlgFixter.FileName); //Si l'arxiu que hem triat esta a dins de la carpeta de descargar tindra aquest format
                // "C:\\Users\\llorca\\Downloads\\IDH2021 (1).xlsx"
                xb = true;
            }

            return (xb);
        }

        private void importarExcel(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application xcl = new Microsoft.Office.Interop.Excel.Application(); //Aqui fem la declaracio del fitxer de excel
            xwb = xcl.Workbooks.Open(fileName); //Declarem el workbook (A on es treballa amb el excel)  
        }

        void funcioimportardades(string v) //Suposo que aqui haure de pasar el nom de l'arxiu per despres poderlo obrir desde la classe
        {
            switch (v)
            {
                case "Estats": importardadesEstats();break;
                case "Dades": importardadesEstatsValors();break; //Aqui no podem fer res ja que encara no tenim ni idea de com es fan les coses
            }
        }

        private void importardadesEstats()
        {
            String NomEstat = ""; //Aqui declararem el nom del estat
            Int32 x1 = 8; //Començem al 8 per que es la columna o la fila que començem a haverhi les dades
            xwb.Worksheets[1].Activate(); //Activem la priemra pagina, ja que si posem 0no entra a dins del rang ja que el rang comença amb 1
            while (xwb.ActiveSheet.Cells[x1, 1].Formula != "") //Mentre el valor de la fila que esta llegint no sigui null, anira fent voltes al bucle
            {
                //xdiaSetmana = xwb.ActiveSheet.Cells[x1, 1].Formula; //Aqui pillare el valor del dia de la setmana, aixo sera CELLS[3,1]
                NomEstat = xwb.ActiveSheet.Cells[x1, 2].Formula;
                //dgDades.Rows.Add(xdiaSetmana, xdata, xvalor); //Aqui cirdem a la funcio i li afegirem el valors que ha llegit del excel i les posare a dins del a taula que  teni posada a dins del exercici
                est.afegirestat(NomEstat);
                x1++;
            }
            xwb.Close();
        }

        private void importardadesEstatsValors()
        {
            //Aqui farem la inserccio de les dades pero abans

            //Aqui farem la declaracio de les dades que rebrem del excel
            Int32 idDades = 0;
            Int32 idEstat = 0;
            Int32 anny = 0;
            Decimal hdi = 0;
            Decimal life = 0;
            Decimal expected_school = 0;
            Decimal mean_schooling = 0;

            String nomEstat = "";

            Int32 x2 = 0;


            Int32 x1 = 8; //Començem al 8 per que es la columna o la fila que començem a haverhi les dades
            
            xwb.Worksheets[1].Activate(); //Activem la priemra pagina, ja que si posem 0no entra a dins del rang ja que el rang comença amb 1
            while (xwb.ActiveSheet.Cells[x1, 1].Formula != "") //Mentre el valor de la fila que esta llegint no sigui null, anira fent voltes al bucle
            {
                //xdiaSetmana = xwb.ActiveSheet.Cells[x1, 1].Formula; //Aqui pillare el valor del dia de la setmana, aixo sera CELLS[3,1]
                x2++;

                //Aqui farem tota la recolecta de dades que li pasarem a la funcio
                idEstat = x2;

                idDades = x2;
                nomEstat = xwb.ActiveSheet.Cells[x1, 2].Formula;
                anny = 2021;

                if(xwb.ActiveSheet.Cells[x1, 3].Formula != "..")
                {
                    hdi = Decimal.Parse(xwb.ActiveSheet.Cells[x1, 3].Formula.Replace('.',','));
                }
                else
                {
                    hdi = 0;
                }
                
                life = Decimal.Parse(xwb.ActiveSheet.Cells[x1, 5].Formula.Replace('.', ','));


                if (xwb.ActiveSheet.Cells[x1, 7].Formula != "..")
                {
                    expected_school = Decimal.Parse(xwb.ActiveSheet.Cells[x1, 7].Formula.Replace('.', ','));
                }
                else
                {
                    expected_school = 0;
                }

                if (xwb.ActiveSheet.Cells[x1, 9].Formula != "..")
                {
                    mean_schooling = Decimal.Parse(xwb.ActiveSheet.Cells[x1, 9].Formula.Replace('.', ','));
                }
                else
                {
                    mean_schooling = 0;
                }


                Decimal[] arraydades = new decimal[7];

                arraydades[0] = Convert.ToDecimal(idEstat);
                arraydades[1] = Convert.ToDecimal(idDades);
                arraydades[2] = Convert.ToDecimal(anny);
                arraydades[3] = hdi;
                arraydades[4] = life;
                arraydades[5] = expected_school;
                arraydades[6] = mean_schooling;

                //dgDades.Rows.Add(xdiaSetmana, xdata, xvalor); //Aqui cirdem a la funcio i li afegirem el valors que ha llegit del excel i les posare a dins del a taula que  teni posada a dins del exercici
                dadesest.assignarvalordadesestats(arraydades,nomEstat);
                dadesest.afegirvalorsBDD();
                x1++;
            }
            xwb.Close();

        }

        private void ConsultesMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ja_està_obert("FrmConsultes")))
            {
                frmConsultes = new FrmConsultes(connexioSQL, ((ToolStripMenuItem)sender).Text);    // hem modificat el constructor genèric del Form FrmClients per a passar-hi la connexió a la BD
                frmConsultes.MdiParent = this;                  // hem fet que FRM_MAIN sigui MdiContainer i posem aquest Form com a fill seu ---
            }
            frmConsultes.WindowState = FormWindowState.Normal;
            frmConsultes.Show();
        }



        private void iDHToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Aqui farem la importació de les dades del SQL al excel
            dadesest.exportarExcel();
        }

        
    }
}


