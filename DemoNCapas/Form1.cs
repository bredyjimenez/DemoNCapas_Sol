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
    public partial class Form1 : Form
    {
        private clsAlumno Alu = new clsAlumno();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarAlumnos();
        }

        private void ListarAlumnos()
        {
            DataTable dt = new DataTable();
            dt = Alu.Listado();
            // recorremos el DataTable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = Convert.ToDateTime(dt.Rows[i][5].ToString()).ToShortDateString(); // Para mostrar la fecha sin la hora
                dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
            }
        }
    }
}
