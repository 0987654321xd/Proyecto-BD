using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaCE
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdCliente { get; set; }

        public VentaCE()
        {
            this.Id = 0;
            this.FechaVenta = DateTime.Now;
            this.IdCliente = 0;
        }

        public VentaCE(int id, DateTime fechaVenta, int idCliente)
        {
            this.Id = id;
            this.FechaVenta = fechaVenta;
            this.IdCliente = idCliente;
        }
    }
}
