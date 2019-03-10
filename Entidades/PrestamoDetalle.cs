using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PrestamoDetalle
    {
        [Key]
        public int PrestamoDetalleId { get; set; }
        public int PrestamoId { get; set; }

        public int numCuota { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Valor { get; set; }
        public decimal Balance { get; set; }

        public PrestamoDetalle()
        {
            PrestamoDetalleId = 0;
            numCuota = 0;
            PrestamoId = 0;
            Valor = 0;
            Capital = 0;
            Interes = 0;
            Balance = 0;
        }

        public PrestamoDetalle(int prestamoDetalleId, int numCuota, int PrestamoId, decimal Pago, decimal Capital, decimal Interes, decimal SaldoDeuda)
        {
            this.PrestamoDetalleId = prestamoDetalleId;
            this.numCuota = numCuota;
            this.PrestamoId = PrestamoId;
            this.Valor = Pago;
            this.Capital = Capital;
            this.Interes = Interes;
            this.Balance = SaldoDeuda;
        }

    }
}
