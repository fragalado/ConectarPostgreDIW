using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConectarPostgreCSharp
{
    class ConectarPostgreSQL
    {
        NpgsqlConnection conec = new NpgsqlConnection();

        // Variables que tendran los valores de la base de datos
        String servidor = "localhost";
        String bd = "gestorBibliotecaPersonal";
        String usuario = "postgres";
        String pswd = "zepxuH-nyzfa5";
        String puerto = "5432";

        public NpgsqlConnection conectarBD()
        {
            String cadenaConexion = "Server=" + servidor + ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + pswd + ";Database=" + bd + ";";

            try
            {
                conec.ConnectionString = cadenaConexion;
                conec.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("No se ha podido conectar a la BD");
            }

            return conec;
        }

        public DataTable consultarBD(string query)
        {
            NpgsqlCommand comm = new NpgsqlCommand(query, conec);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(comm);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void desconectarBD()
        {
            try
            {
                conec.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("No se ha podido cerrar la base de datos");
            }
        }
        
    }
}
