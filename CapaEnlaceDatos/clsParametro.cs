using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEnlaceDatos
{
    public class clsParametro
    {
        // Atritubos
        private String m_Nombre;
        private Object m_Valor;

        // Propiedades
        public String Nombre { get => m_Nombre; set => m_Nombre = value; }
        public Object Valor { get => m_Valor; set => m_Valor = value; }

        // Contrusctor
        public clsParametro(String ObjNombre, Object objValor) {
            m_Nombre = ObjNombre;
            m_Valor = objValor;
        }
    }
}
