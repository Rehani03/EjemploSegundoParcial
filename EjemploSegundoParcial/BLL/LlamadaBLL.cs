using EjemploSegundoParcial.DAL;
using EjemploSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.BLL
{
    public class LlamadaBLL
    {
        public static bool Guardar(Llamada llamada)
        {
            if (!Existe(llamada.llamadaId))
                return Insertar(llamada);
            else
                return Modificar(llamada);

        }

        private static bool Insertar(Llamada llamada)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;
            try
            {
                contexto.Llamadas.Add(llamada);
                guardado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

        private static bool Modificar(Llamada llamada)
        {
            var AnteriorLlamada = Buscar(llamada.llamadaId);
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                foreach (var item in AnteriorLlamada.Detalles)
                {
                    if(!llamada.Detalles.Exists(l=>l.llamadaDetalleId == item.llamadaDetalleId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in llamada.Detalles)
                {
                    if(item.llamadaDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                }

                contexto.Entry(llamada).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static Llamada Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Llamada llamada;
            try
            {
                llamada = contexto.Llamadas.Where(l => l.llamadaId == id).Include(l=>l.Detalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return llamada;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;
            try
            {
                var aux = contexto.Llamadas.Find(id);
                if (aux != null)
                {
                    contexto.Llamadas.Remove(aux);
                }
                eliminado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Llamadas.Any(l => l.llamadaId == id);       
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static List<Llamada> GetList(Expression<Func<Llamada, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Llamada> lista = new List<Llamada>();
            try
            {
                lista = contexto.Llamadas.Where(expression).ToList();
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
