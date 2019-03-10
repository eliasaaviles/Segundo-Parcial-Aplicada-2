using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class RepositorioPrestamo : Repositorio<Prestamo>
    {
        public override Prestamo Buscar(int id)
        {
            Prestamo prestamos = contexto.Prestamos.Include(x=> x.Detalle ).Where(z => z.PrestamosId == id)                          .FirstOrDefault();
            return prestamos;
        }

        public override bool Eliminar(int id)
        {
            Prestamo prestamos = Buscar(id);
            Cuenta cuentas = contexto.Cuentas.Find(prestamos.CuentaId);
            cuentas.Balance -= prestamos.Total;
            contexto.Entry(cuentas).State = EntityState.Modified;
            return base.Eliminar(id);
        }

        public override bool Guardar(Prestamo prestamo)
        {
            Cuenta cuentas = contexto.Cuentas.Find(prestamo.CuentaId);
            cuentas.Balance += prestamo.Total;
            contexto.Entry(cuentas).State = EntityState.Modified;

            return base.Guardar(prestamo);
        }

        public override bool Modificar(Prestamo entity)
        {
            Prestamo prestamos = contexto.Prestamos.Include(x => x.Detalle).Where(z => z.PrestamosId == entity.PrestamosId)                  .AsNoTracking()
                                 .FirstOrDefault();

            var prestamoAnt = prestamos;
            var cuenta = contexto.Cuentas.Find(entity.CuentaId);
            cuenta.Balance -= prestamoAnt.Total;
            contexto.Entry(cuenta).State = EntityState.Modified;

            foreach (var item in prestamoAnt.Detalle)
                contexto.Entry(item).State = EntityState.Deleted;


            foreach (var item in entity.Detalle)
                contexto.Entry(item).State = (item.PrestamoDetalleId == 0) ? EntityState.Added : EntityState.Modified;

            cuenta.Balance += entity.Total;
            contexto.Entry(cuenta).State = EntityState.Modified;

            return base.Modificar(entity);
        }

        public override List<Prestamo> GetList(Expression<Func<Prestamo, bool>> expression)
        {
            var lista = contexto.Prestamos.Include(x => x.Detalle).Where(expression).ToList();
            return lista;
        }
    }
}
