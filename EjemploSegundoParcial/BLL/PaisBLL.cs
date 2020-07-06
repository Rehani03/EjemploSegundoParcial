using EjemploSegundoParcial.DAL;
using EjemploSegundoParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.BLL
{
    public class PaisBLL
    {
        public static Pais Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pais pais = new Pais();
            try
            {
                pais = contexto.Pais.Find(id);
            }
            catch (Exception)
            {

                throw;
            }

            return pais;
        }
        public static List<Pais> GetList(Expression<Func<Pais, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Pais> lista = new List<Pais>();
            try
            {
                lista = contexto.Pais.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
