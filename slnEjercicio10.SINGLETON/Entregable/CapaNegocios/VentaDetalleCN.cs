using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class VentaDetalleCN
    {
        public ClienteCE getBuscarClientePorId(int idBuscar)
        {
            VentaDetalleCD ventaDetalleCD = new VentaDetalleCD();
            ClienteCE clienteCE = ventaDetalleCD.BuscarClientePorId(idBuscar);
            return clienteCE;
        }

        public ProductoCE getBuscarProductoPorId(int idBuscar)
        {
            VentaDetalleCD ventaDetalleCD = new VentaDetalleCD();
            ProductoCE productoCE = ventaDetalleCD.BuscarProductoPorId(idBuscar);
            return productoCE;
        }

        public int setInsertarDetalle(VentaDetalleCE ventaDetalleCE, int idVenta)
        {
            VentaDetalleCD ventaDetalleCD = new VentaDetalleCD();
            int nuevoId = ventaDetalleCD.setInsertarDetalle(ventaDetalleCE, idVenta);
            return nuevoId;
        }
    }
}
