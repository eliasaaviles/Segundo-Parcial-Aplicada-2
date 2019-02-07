using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Deposito
    {
        [Key]
        public int DepositoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public string Concepto { get; set; }
        public Decimal Monto { get; set; }

        public Deposito()
        {
            DepositoId = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Concepto = string.Empty;
            Monto = 0;
        }

        public Deposito(int depositoId, DateTime fecha, int cuentaId, string concepto, decimal monto)
        {
            DepositoId = depositoId;
            Fecha = fecha;
            CuentaId = cuentaId;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
