using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio; // importar

namespace DemoNCapas
{
    public partial class Form2 : Form
    {
        private clsAlumno Alu = new clsAlumno();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Alu.Dni = txtDni.Text;
            Alu.Apellidos = txtApellidos.Text;
            Alu.Nombres = txtNombres.Text;
            Alu.Sexo = rdMasculino.Checked == true ? 'M' : 'F';
            Alu.FechaNacimiento = Convert.ToDateTime(dtpFechaNac.Value);
            Alu.Direccion = txtDireccion.Text;
            MessageBox.Show(Alu.RegistrarAlumnos(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Alu.Dni = txtDni.Text;
            Alu.Apellidos = txtApellidos.Text;
            Alu.Nombres = txtNombres.Text;
            Alu.Sexo = rdMasculino.Checked == true ? 'M' : 'F';
            Alu.FechaNacimiento = Convert.ToDateTime(dtpFechaNac.Value);
            Alu.Direccion = txtDireccion.Text;
            MessageBox.Show(Alu.ActualizarAlumnos(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }
        private void Limpiar()
        {
            txtDni.Clear();
            txtApellidos.Clear();
            txtNombres.Clear();
            rdMasculino.Checked = true;
            dtpFechaNac.Value = DateTime.Now;
            txtDireccion.Clear();
            txtDni.Focus();
        }
    }
}
