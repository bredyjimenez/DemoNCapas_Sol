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

        public DataTable Listado()
        {
            return M.Listado("ListarAlumnos", null);
        }
    }
}
