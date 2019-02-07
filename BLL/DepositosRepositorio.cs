using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class DepositosRepositorio : Repositorio<Deposito>
    {
        public override bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                Deposito depositos = contexto.Depositos.Find(id);
                contexto.Cuentas.Find(depositos.CuentaId).Balance -= depositos.Monto;
                contexto.Depositos.Remove(depositos);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Guardar(Deposito entity)
        {
            bool paso = false;

            try
            {
                contexto.Depositos.Add(entity);
                contexto.Cuentas.Find(entity.CuentaId).Balance += entity.Monto;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Modificar(Deposito entity)
        {
            bool paso = false;

            try
            {
                contexto.Entry(entity).State = EntityState.Modified;

                Deposito DepAnt = contexto.Depositos.Find(entity.DepositoId);
                var cuenta = contexto.Cuentas.Find(entity.CuentaId);
                var cuentaAnt = contexto.Cuentas.Find(DepAnt.CuentaId);

                if (entity.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += entity.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                {
                    decimal diferencia = entity.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
    }
}

