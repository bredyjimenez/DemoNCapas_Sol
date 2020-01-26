using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEnlaceDatos; // importar
using System.Data;

namespace CapaLogicaNegocio
{
    public class clsAlumno
    {
        private clsManejador M = new clsManejador();

        // Atributos
        private String m_Dni;
        private String m_Apellidos;
        private String m_Nombre;
        private Char m_Sexo;
        private DateTime m_FechaNac;
        private String m_Direccion;

        // Propiedades
        public String Dni
        {
            get { return m_Dni; }
            set { m_Dni = value; }
        }

        public String Apellidos
        {
            get { return m_Apellidos; }
            set { m_Apellidos = value; }
        }

        public String Nombres
        {
            get { return m_Nombre; }
            set { m_Nombre = value; } 
        }

        public Char Sexo
        {
            get { return m_Sexo; }
            set { m_Sexo = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return m_FechaNac; }
            set { m_FechaNac = value; }
        }

        public string Direccion
        {
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }

        public DataTable Listado()
        {
            return M.Listado("ListarAlumnos", null);
        }

        public String RegistrarAlumnos()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                // Pasamos los parametros de entrada
                lst.Add(new clsParametro("@Dni", m_Dni));
                lst.Add(new clsParametro("@Apellidos", m_Apellidos));
                lst.Add(new clsParametro("@Nombres", m_Nombre));
                lst.Add(new clsParametro("@Sexo", m_Sexo));
                lst.Add(new clsParametro("@FechaNac", m_FechaNac));
                lst.Add(new clsParametro("@Direccion", m_Direccion));
                
                // Pasamos los parametros de salida
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("RegistrarAlumnos", ref lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return Mensaje;
        }
    }
}
