using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class VentaCN
    {
        public int setInsertar(VentaCE venta)
        {
            VentaCD ventaCD = new VentaCD();
            return ventaCD.setInsertar(venta);
        }
    }
}
