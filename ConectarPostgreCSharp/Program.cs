using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarPostgreCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicializamos un objeto de tipo ConectarPostgreSQL
            ConectarPostgreSQL conec = new ConectarPostgreSQL();

            // Conectamos
            conec.conectarBD();

            // Consula de datos
            DataTable tabla;
            try
            {
                // Guardamos en tabla la DataTable que devuelve el metodo
                tabla = conec.consultarBD("SELECT * FROM gbp_almacen.gbp_alm_cat_libros");

                // Recorremos la DataTable para mostrar las columnas de cada fila
                foreach (DataRow row in tabla.Rows)
                {
                    foreach (DataColumn columns in tabla.Columns)
                    {
                        Console.Write("{0}: {1}; ", columns.ColumnName, row[columns]);
                    }
                    Console.WriteLine(); // Para dejar un espacio
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: No se ha podido hacer la consulta");
            }

            // Desconectamos
            conec.desconectarBD();

            // Para salir
            Console.WriteLine("\n\n\tPulse una tecla para salir");
            Console.ReadKey();
        }
    }
}
