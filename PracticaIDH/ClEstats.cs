using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace PracticaIDH
{
    public class ClEstats
    {
        //Aqui farem la declaracio de variables que farem servir per la la taula de Estats, en aquest cas nomes sera el nom del estat ja que el numero no fara falta ja que es un autoincrement
        public Int32 IdEstat { get; set; } = 0; //Aixo l'hem posat per seguir la estructura pero no se si el farem servir
        public String NomEstat { get; set; } = ""; //Declarem el nom del estat 

        public SqlConnection connexioSql;

        public ClEstats(ref SqlConnection xconnexio)
        {
            connexioSql = xconnexio;
        }

        public void iniEstat()
        {
            IdEstat = 0;
            NomEstat = "";
        }

        public void afegirestat(string nomestat)
        {
            
            //Un sql command es un objecte de sql que serveix per fer la connexio a la base de dades amb la base de dades previament li haurem introduit, i  despres podrem posar la peticio que nosaltres volem
            SqlCommand xcommand = new SqlCommand();
            String nomfinal;
            try
            {
                nomfinal = nomestat.Replace("'", " "); //Aqui treurem les cometes per que si hi han cometes el sql command text falla
                //nomfinal = nomestat.Trim('\'');
                //Aqui direm que la connexio que ha de fer servir es la que previament hem rebut a la classe
                xcommand.Connection = connexioSql;
                //I ara declarem la peticio de sql, que es un simple INSERT
                xcommand.CommandText = "INSERT INTO tbEstats (nomestat) VALUES (\'" + nomfinal + "\')"; //Fer alguna cosa aqui per que els 
                xcommand.ExecuteNonQuery(); //Aquesta comanda fa que executem la peticio que acabem de crear,""""""" si volguessim fer una consulta amb un select hauriem de fer el mateix pero donantli un valor a assignar """""""
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "EXCEPCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            xcommand.Dispose(); //Per optimitzar el codi farem que lliberi els recursos que ha fet servir , en principi aquesta operacio no fara falta, pero ho estem fent per polir el codi i per que sigui mes optim el codi

        }
    }

    
    

}
