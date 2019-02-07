using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Repositorio<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto contexto;

        public Repositorio()
        {
            contexto = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                contexto.Set<T>().Add(entity);
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;

            try
            {
                contexto.Entry(entity).State = EntityState.Modified;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T entity = contexto.Set<T>().Find(id);
                contexto.Set<T>().Remove(entity);
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public virtual T Buscar(int id)
        {
            T entity = null;

            try
            {
                entity = contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> list = null;

            try
            {
                list = contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public void Dispose()
        {
            contexto.Dispose();
        }



    }
}

