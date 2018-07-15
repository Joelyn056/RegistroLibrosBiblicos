using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroLibros.Entidades;

namespace RegistroLibros.UI.Registros
{
    public partial class rLibros : Form
    {
        public rLibros()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LibroId_numericUpDown.Value = 0;
            Descripcion_textBox.Clear();
            Siglas_textBox.Clear();
            Tipo_comboBox.Text = "";
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Libros libro = LlenaClase();
            bool paso = false;

            if (Validar() != paso)
            {


                if (LibroId_numericUpDown.Value == 0)
                    paso = BLL.LibrosBLL.Guardar(libro);
                else
                    paso = BLL.LibrosBLL.Modificar(LlenaClase());

                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se Puso!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public bool Validar()
        {
            bool paso = true;
            if (Descripcion_textBox.Text == string.Empty)
            {
                ErrorProvider.SetError(Descripcion_textBox, "Debe Introducir La Descripcion");
                paso = false;
            }
            else
            if (Siglas_textBox.Text == string.Empty)
            {
                ErrorProvider.SetError(Siglas_textBox, "Debe Introducir Las Siglas");
                paso = false;
            }
            else
            if (Tipo_comboBox.Text == "")
            {
                ErrorProvider.SetError(Tipo_comboBox, "Debe Seleccionar El Tipo De Id");
                paso = false;
            }

            return paso;
        }

        private Libros LlenaClase()
        {
            Libros libro = new Libros();

            libro.LibrosId = Convert.ToInt32(LibroId_numericUpDown.Value);
            libro.Descipcion = Descripcion_textBox.Text;
            libro.Siglas = Siglas_textBox.Text;
            libro.Tipo = Tipo_comboBox.Text;

            return libro;

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibroId_numericUpDown.Value);

            if (BLL.LibrosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibroId_numericUpDown.Value);

            Libros libros = BLL.LibrosBLL.Buscar(id);

            if(libros !=null)
            {
                LibroId_numericUpDown.Value = libros.LibrosId;
                FechaDateTimePicker.Value = libros.Fecha;
                Descripcion_textBox.Text = libros.Descipcion;
                Siglas_textBox.Text = libros.Siglas;
                Tipo_comboBox.Text = libros.Tipo;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
