using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // importar
using System.Data.SqlClient;

namespace CapaEnlaceDatos
{
    public class clsParametro
    {
        // Atritubos
        private String m_Nombre;
        private Object m_Valor;
        private SqlDbType m_TipoDato;
        private ParameterDirection m_Direccion;
        private int m_Tamano;

        // Propiedades
        public String Nombre { get => m_Nombre; set => m_Nombre = value; }
        public Object Valor { get => m_Valor; set => m_Valor = value; }
        public SqlDbType TipoDato { get => m_TipoDato; set => m_TipoDato = value; }
        public ParameterDirection Direccion { get => m_Direccion; set => m_Direccion = value; }
        public int Tamano { get => m_Tamano; set => m_Tamano = value; }

        // Contrusctor
        public clsParametro(String ObjNombre, Object objValor) {
            m_Nombre = ObjNombre;
            m_Valor = objValor;
            m_Direccion = ParameterDirection.Input;
        }
        public clsParametro(String objNombre, Object objValor, SqlDbType objTipoDato, ParameterDirection objDireccion, int objTamano)
        {
            m_Nombre = objNombre;
            m_Valor = objValor;
            m_TipoDato = objTipoDato;
            m_Direccion = objDireccion;
            m_Tamano = objTamano;
        }
    }
}
