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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Alu.Dni = txtDni.Text;
            MessageBox.Show(Alu.EliminarAlumnos(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow row;
            Alu.Dni = txtDni.Text;
            dt = Alu.BuscarAlumnos(Alu.Dni);
            if(dt.Rows.Count == 1)
            {
                row = dt.Rows[0];
                txtApellidos.Text = row[2].ToString();
                txtNombres.Text = row[3].ToString();
                if (row[4].ToString() == "M")
                    rdMasculino.Checked = true;
                else
                    rdFemenino.Checked = true;
                dtpFechaNac.Value = Convert.ToDateTime(row[5].ToString());
                txtDireccion.Text = row[6].ToString();
                MessageBox.Show("Registro Encontrado OK...!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro de Alumno no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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