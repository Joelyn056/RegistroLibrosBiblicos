using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroLibros.Entidades;


namespace RegistroLibros.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Libros> libros { get; set; }
        
        public Contexto() : base("CnStr")
        {

        }

    }
}
