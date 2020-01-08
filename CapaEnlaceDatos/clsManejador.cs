using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // importar
using System.Data.SqlClient;

namespace CapaEnlaceDatos
{
    public class clsManejador
    {
        public SqlConnection conexion = new SqlConnection("Server=TEAMLAPTOP90; DataBase=DemoNCapas; Integrated Security = True; User=sa; Password=8852893");
        public void Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        public void Desconectar()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        public DataTable Listado(String NombrePS, List<clsParametro> lst) {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                Conectar();
                da = new SqlDataAdapter(NombrePS, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Verificamos si la lista no esta vacía
                if (lst != null)
                {
                    // Recorremos la lista Genérica
                    for (int i = 0; i < lst.Count; i++)
                    {
                        // Pasamos cada uno de los parámetros
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                // Llenamos nuestro DataTable
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Desconectar();
            return dt;
        }
    }
}
