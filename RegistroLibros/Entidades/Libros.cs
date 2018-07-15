using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroLibros.Entidades
{
    public class Libros
    {
        [Key]

        public int LibrosId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descipcion { get; set; }
        public string Siglas { get; set; }
        public string Tipo { get; set; }

        public Libros()
        {
            LibrosId = 0;
            Fecha = DateTime.Now;
            Descipcion = string.Empty;
            Siglas = string.Empty;
            Tipo = string.Empty;

        }
    }
}
