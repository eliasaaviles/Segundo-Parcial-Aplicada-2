using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Prestamo
    {
        [Key]
        public int PrestamosId { get; set; }

        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal InteresAnual { get; set; }
        public int TiempoMeses { get; set; }
        public decimal CapitaTotal { get; set; }
        public decimal InteresTotal { get; set; }
        public decimal Total { get; set; }

        public virtual List<PrestamoDetalle> Detalle { get; set; }

        public Prestamo(int prestamosId, DateTime fecha, int cuentaId, decimal capital, decimal interesAnual, int tiempoMeses, decimal capitaTotal, decimal interesTotal, decimal total, List<PrestamoDetalle> detalle)
        {
            PrestamosId = prestamosId;
            Fecha = fecha;
            CuentaId = cuentaId;
            Capital = capital;
            InteresAnual = interesAnual;
            TiempoMeses = tiempoMeses;
            CapitaTotal = capitaTotal;
            InteresTotal = interesTotal;
            Total = total;
            Detalle = detalle;
        }

        public Prestamo()
        {
            this.PrestamosId = 0;
            this.Fecha = DateTime.Now;
            this.CuentaId = 0;
            this.Capital = 0;
            this.InteresAnual = 0;
            this.TiempoMeses = 0;
            CapitaTotal = 0;
            InteresTotal = 0;
            Total = 0;
            Detalle = new List<PrestamoDetalle>();
        }
    }
}
