using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroLibros.BLL;
using RegistroLibros.Entidades;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace RegistroLibros.UI.Consulta
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click_1(object sender, EventArgs e)
        {           
            
            Expression<Func<Libros, bool>> filtro = x => true;

            int id;
            switch (FiltrarComboBox.SelectedIndex)
            {
                case 0: // LibrosId
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => (x.LibrosId == id) && (x.Fecha >= Desde_dateTimePicker.Value.Date && x.Fecha <= Hasta_dateTimePicker.Value.Date);
                    break;

                case 1: //Descripcion
                    filtro = x => (x.Descipcion.Contains(CriteriotextBox.Text)) && (x.Fecha >= Desde_dateTimePicker.Value.Date && x.Fecha <= Hasta_dateTimePicker.Value.Date);
                    break;

                case 2: //Siglas
                    filtro = x => (x.Siglas.Contains(CriteriotextBox.Text)) && (x.Fecha >= Desde_dateTimePicker.Value.Date && x.Fecha <= Hasta_dateTimePicker.Value.Date);
                    break;

                case 3: //tipos
                    filtro = x => (x.Tipo.Contains(CriteriotextBox.Text)) && (x.Fecha >= Desde_dateTimePicker.Value.Date && x.Fecha <= Hasta_dateTimePicker.Value.Date);
                    break;

            }

            ConsultarDataGridView.DataSource = LibrosBLL.GetList(filtro);
        }
        
    }

}