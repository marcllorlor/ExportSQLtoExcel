using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace PracticaIDH
{
    public class ClDadesEstats
    {
        //Aqui declararem les variables
        Int32 idDades { get; set; } = 0;
        Int32 idEstat { get; set; } = 0;
        Int32 anny { get; set; } = 0;
        Decimal hdi { get; set; } = 0;
        Decimal life { get; set; } = 0;
        Decimal expected_school { get; set; } = 0;
        Decimal mean_schooling { get; set; } = 0;


        //Aquesta variable nomes la farem servir quan haguem de fer la consulta principal
        String nomEstat { get; set; } = "";

        String nomfinal { get; set; } = "";

        public SqlConnection connexioSql;

        String tipusConsulta { get; set; } = "";

        public ClDadesEstats(ref SqlConnection xconnexio)
        {
            //Aqui estem fent el constructor de la base de dades que li pasarem la connexio sql
            connexioSql = xconnexio;
        }

        public ClDadesEstats(SqlConnection xconnexio, String xtipusConsulta)
        {
            tipusConsulta = xtipusConsulta;
            connexioSql = xconnexio;
        }

        public void inidadesestat()
        {
            //De moment aquesta funcio no la farem servir per res
            idDades = 0;
            idEstat = 0;
            anny = 0;
            hdi = 0;
            life = 0;
            expected_school = 0;
            mean_schooling = 0;

            //Aquesta variable nomes la farem servir quan fem la consulta del principi
        }

        public void assignarvalordadesestats(Decimal[] xarrayvalors, String xnomEstat)
        {
            idEstat = Decimal.ToInt32(xarrayvalors[0]);
            idDades = Decimal.ToInt32(xarrayvalors[1]);
            anny = Decimal.ToInt32(xarrayvalors[2]);
            hdi = xarrayvalors[3];
            life = xarrayvalors[4];
            expected_school = xarrayvalors[5];
            mean_schooling = xarrayvalors[6];

            nomEstat = xnomEstat;
        }

        public void afegirvalorsBDD()
        {
            //Primer farem la funcio per detectar si el estat que estem buscant esta inserit a la base de dades
            if (consultarestatbdd())
            {
                //Aqui haurem de fer la conversio de dades de decimal c# a real SQL //Simplement haurem de canviar la coma per un punt

                String xhdi = hdi.ToString().Replace(',', '.');
                String xlife = life.ToString().Replace(',', '.');
                String xexpected_school = expected_school.ToString().Replace(',', '.');
                String xmean_schooling = mean_schooling.ToString().Replace(',', '.');



                //Cada cop que s'afegeixi un client entrara a dins daquesta funcio

                //Un sql command es un objecte de sql que serveix per fer la connexio a la base de dades amb la base de dades previament li haurem introduit, i  despres podrem posar la peticio que nosaltres volem
                SqlCommand xcommand = new SqlCommand();

                try
                {
                    //Aqui direm que la connexio que ha de fer servir es la que previament hem rebut a la classe
                    xcommand.Connection = connexioSql;
                    //I ara declarem la peticio de sql, que es un simple INSERT
                    xcommand.CommandText = "INSERT INTO TBDADES VALUES(" + idEstat + "," + anny + "," + xhdi + "," + xlife + "," + xexpected_school + "," + xmean_schooling + ")";
                    xcommand.ExecuteNonQuery(); //Aquesta comanda fa que executem la peticio que acabem de crear,""""""" si volguessim fer una consulta amb un select hauriem de fer el mateix pero donantli un valor a assignar """""""
                    
                }
                catch (Exception excp)
                {
                    MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                xcommand.Dispose(); //Per optimitzar el codi farem que lliberi els recursos que ha fet servir , en principi aquesta operacio no fara falta, pero ho estem fent per polir el codi i per que sigui mes optim el 
            }
        }

        private bool consultarestatbdd()
        {
            Boolean xb = false; //Aqui el bool que dira si la consulta sha fet correctament o no
            String xsql = ""; //Aqui declarem el text de la consulta SQL
            SqlDataAdapter xadap = new SqlDataAdapter(); //Aqui declarem el objecte que fara que adaptem les dades de la consulta a string
            DataSet xdset = new DataSet(); //Aqui no tinc ni idea de que declarem ni per que fem servir aixo
            String nomfinal = nomEstat.Replace("'", "''");
            xsql = "SELECT * FROM TBESTATS WHERE IDESTAT='" + idEstat + "' AND NOMESTAT = '" + nomfinal + "'"; //Creem la consulta SQL

            try
            {
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui es a on farem la consulta i tot el que retorni ho posarem a dins del dataadapter
                xadap.Fill(xdset); //Aqui les dades de xadap "el data set" li posarem els valors a xdset "Data set que acabem de declarar"
                if (xdset.Tables[0].Rows.Count > 0)
                {
                    //Si ha trobat una consulta aixo voldra die que haura entrat aqui
                    xb = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return xb;
        }

        public Boolean llistaDadesEstats(ref DataSet xdset)
        {
            Boolean xb = false;
            switch (tipusConsulta)
            {
                case "IDH": xb= llistaEstatsIDH(ref xdset); break;
                case "Esperança de vida": xb= llistaEstatsVida(ref xdset); break;
                case "Escolarització": xb = llistaEstatsEscolarització(ref xdset); break;
            }

            return xb;
            
        }

        private Boolean llistaEstatsEscolarització(ref DataSet xdset)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbEstats.nomEstat , tbDades.expected_school FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat ORDER BY tbDades.expected_school DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        private Boolean llistaEstatsIDH(ref DataSet xdset)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbEstats.nomEstat , tbDades.hdi FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat ORDER BY tbDades.hdi DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        private Boolean llistaEstatsVida(ref DataSet xdset)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbEstats.nomEstat , tbDades.life FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat ORDER BY tbDades.life DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public Boolean comparacioIDH(ref DataSet xdset, String nomestattriat)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbDades.idEstat, tbEstats.nomEstat , tbDades.hdi FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat WHERE tbEstats.nomEstat = 'Spain' OR tbEstats.nomEstat = '"+ nomestattriat + "' ORDER BY tbDades.hdi DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public Boolean comparacioVida(ref DataSet xdset, String nomestattriat)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbDades.idEstat, tbEstats.nomEstat , tbDades.life FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat WHERE tbEstats.nomEstat = 'Spain' OR tbEstats.nomEstat = '" + nomestattriat + "' ORDER BY tbDades.life DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public Boolean comparacioEscolarització(ref DataSet xdset, String nomestattriat)
        {
            Boolean xb = false; //Declarem el tipic boolean per fer el comprovant de la execucio de la comanda SQL
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "SELECT tbDades.idEstat, tbEstats.nomEstat , tbDades.expected_school FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat WHERE tbEstats.nomEstat = 'Spain' OR tbEstats.nomEstat = '" + nomestattriat + "' ORDER BY tbDades.expected_school DESC;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(xdset); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public Boolean ConsultaExcel(ref DataSet dsetDades)
        {
            Boolean xb = false;
            String xsql = ""; //Declarem la comanda
            SqlDataAdapter xadap = new SqlDataAdapter(); //I declarem el SQLdataadpater per despres rebre les dades de la peticio SQL

            try
            {
                xsql = "  SELECT tbDades.idDades, tbEstats.nomEstat, tbDades.hdi FROM tbDades INNER JOIN tbEstats ON tbDades.idEstat = tbEstats.idEstat;"; //Aqui declarem la consulta
                //Pero cridarem a la funcio per saber en quin ordre hem de fer al minim la comanda
                xadap = new SqlDataAdapter(xsql, connexioSql); //Aqui omplirem la consulta amb les dades que rebrem  de la consulta
                xadap.Fill(dsetDades); //Omplim les dades del sql al DataAdapter que ens pasaran
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return xb;
        }

        public void exportarExcel()
        {
            //Cursor = Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application xcl = new Microsoft.Office.Interop.Excel.Application();
            inillibre(xcl);
            DataSet dsetDades = new DataSet();
            if(ConsultaExcel(ref dsetDades))
            {
                Int32 x1 = -1;

                personalitzarexcel(xcl);
                xcl.Visible = true;
                //xcl.WindowState = WindowState

                //Primer farem un for per saber 
                //dsetDades.Tables[0].Rows[0].ItemArray
                for (int i = 0; i < dsetDades.Tables[0].Rows.Count; i++)
                {
                    x1++;
                    xcl.ActiveSheet.cells(2 + x1, 1).select(); //Aqui pillarem la C1
                    xcl.ActiveCell.Formula = dsetDades.Tables[0].Rows[i].ItemArray[0].ToString().Replace(",","."); //Aqui assignem el valor al C1
                    xcl.ActiveSheet.cells(2 + x1, 2).select(); //Aqui pillarem la C2
                    xcl.ActiveCell.Formula = dsetDades.Tables[0].Rows[i].ItemArray[1].ToString().Replace(",", ".");
                    xcl.ActiveSheet.cells(2 + x1, 3).select(); //Aqui pillarem la C3
                    xcl.ActiveCell.Formula = dsetDades.Tables[0].Rows[i].ItemArray[2].ToString().Replace(",", ".");



                    //dsetDades.Tables[0].Rows[0].ItemArray[0]; //Aqui es a on tindrem
                }
                //Aqui es a on farem la inserccio de dades
                
            }
            //iniLlibreExcel(xcl);


            //Aqui es a on farem la introduccio de dades de SQL al excel
        }

        private void personalitzarexcel(Microsoft.Office.Interop.Excel.Application xcl)
        {
            xcl.ActiveSheet.cells(1 , 1).select(); //Aqui pillarem la C1
            xcl.ActiveCell.Formula = "Id Estat";
            xcl.ActiveSheet.cells(1 , 2).select(); //Aqui pillarem la C1
            xcl.ActiveCell.Formula = "Nom Estat";
            xcl.ActiveSheet.cells(1, 3).select(); //Aqui pillarem la C1
            xcl.ActiveCell.Formula = "IDH";
        }

        private void inillibre(Microsoft.Office.Interop.Excel.Application xcl)
        {
            xcl.Workbooks.Add(); //Aquesta comanda no se que fa
            xcl.Visible = true; //Posem el excel visisble, si deixem amb false veurem que s'obre l'excel
            xcl.Application.DisplayAlerts = false; //TRUE            // si posem False no es mostrarà cap avís d'Excel ni tan sols el de tancar el llibre sense haver - lo guardat

            if (xcl.ActiveWorkbook.Worksheets.Count > 2) //Si tenim més de 2 pagines de excel, borrara la ultima
            {
                xcl.ActiveWorkbook.Worksheets[2].Delete();       // esborrem la Hoja2
            }

            if (xcl.ActiveWorkbook.Worksheets.Count > 2)
            {
                xcl.ActiveWorkbook.Worksheets[2].Delete();       // esborrem la Hoja3 
            }
            xcl.ActiveWorkbook.Worksheets[1].Activate(); //Ens posem a sobre de la worksheet numero 1
            xcl.ActiveWorkbook.Worksheets[1].Name = "Dades"; //Canviem el nom de la pagina que estem actualament
        }
    }
}
