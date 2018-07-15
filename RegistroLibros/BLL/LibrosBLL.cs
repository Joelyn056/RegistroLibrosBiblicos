using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroLibros.DAL;
using RegistroLibros.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RegistroLibros.BLL
{
    public class LibrosBLL
    {
        public static bool Guardar(Libros libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.libros.Add(libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Libros libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(libro).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                    paso = true;

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Libros libro = contexto.libros.Find(id);
                contexto.libros.Remove(libro);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Libros Buscar(int id)
        {

            Libros libro = new Libros();
            Contexto contexto = new Contexto();

            try
            {
                libro = contexto.libros.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return libro;

        }

        public static List<Libros> GetList(Expression<Func<Libros, bool>> expression)
        {

            List<Libros> Libros = new List<Libros>();
            Contexto contexto = new Contexto();

            try
            {

                Libros = contexto.libros.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Libros;
        }
    }
}
