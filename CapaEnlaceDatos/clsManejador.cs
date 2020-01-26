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

        // El NombreSP es el nombre de nuestro procedimiento almacenado.    // ref nos permite realizar un conjunto de instrucciones
        public void EjecutarSP(String NombreSP, ref List<clsParametro> lst) {
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                // Verifivar si la Genérica no está vacía
                if (lst != null) {
                    // Recorremos la lista
                    for (int i = 0; i < lst.Count; i++)
                    {
                        // Verificamos si los parámetros son de entrada
                        if (lst[i].Direccion == ParameterDirection.Input)
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);

                        // Verificamos si los parámetros son de salida
                        if (lst[i].Direccion == ParameterDirection.Output)
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamano).Direction = ParameterDirection.Output;
                    }
                    cmd.ExecuteNonQuery();
                    // Recuperamos los datos de salida
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].Valor = cmd.Parameters[i].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
