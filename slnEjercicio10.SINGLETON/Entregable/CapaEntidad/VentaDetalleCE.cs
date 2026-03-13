using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CapaEntidad
{
    public class VentaDetalleCE
    {
        public ClienteCE Cliente { get; set; }
        public ProductoCE Producto { get; set; }

        public int IdVenta { get; set; }          
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaVenta { get; set; }

        public VentaDetalleCE()
        {
            this.Cliente = new ClienteCE();
            this.Producto = new ProductoCE();
            this.Cantidad = 0;
            this.FechaVenta = DateTime.Now;
        }
        public VentaDetalleCE(ClienteCE cliente, ProductoCE producto, int cantidad, DateTime fechaVenta)
        {
            this.Cliente = cliente;
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.FechaVenta = fechaVenta;
        }
    }
}
