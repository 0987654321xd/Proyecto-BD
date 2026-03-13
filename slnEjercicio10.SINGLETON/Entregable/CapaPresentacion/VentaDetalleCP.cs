using CapaEntidad;
using CapaNegocios;
using pryCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class VentaDetalleCP : Form
    {
        private static VentaDetalleCP instancia = null;
        public static VentaDetalleCP Instancia
        {
            get
            {
                if ((instancia == null) || (instancia.IsDisposed == true))
                {
                    instancia = new VentaDetalleCP();
                }
                return instancia;
            }

        }
        public VentaDetalleCP()
        {
            InitializeComponent();

            formatearDGV();
        }
        private void formatearDGV()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dgvProductos.Columns.Add("colId", "ID");
            dgvProductos.Columns.Add("colDescripcion", "PRODUCTO");
            dgvProductos.Columns.Add("colPrecio", "PRECIO S/.");
            dgvProductos.Columns.Add("colCantidad", "CANTIDAD");
            dgvProductos.Columns.Add("colTotal", "TOTAL S/");
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.AllowUserToAddRows = false;
        }
        private void calcularTotalVenta()
        {
            double totalVenta = 0;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                double precio = Convert.ToDouble(fila.Cells["colTotal"].Value);
                totalVenta = totalVenta + precio;
            }
            txtTotalPrecios.Text = totalVenta.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdProducto.Text);
            string descripcion = txtProducto.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double total = precio * cantidad;

            if ((descripcion.Length > 0) && (cantidad > 0) && (precio > 0))
            {
                dgvProductos.Rows.Add(id, descripcion, precio, cantidad, total);
            }
            calcularTotalVenta();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            int idBuscar = Convert.ToInt32(txtIdCliente.Text);
            ClienteCN clienteCN = new ClienteCN();
            ClienteCE clienteCE = clienteCN.getBuscarPorId(idBuscar);
            txtCliente.Text = clienteCE.Nombre;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            int idBuscar = Convert.ToInt32(txtIdProducto.Text);
            ProductoCN productoCN = new ProductoCN();
            ProductoCE productoCE = productoCN.getBuscarPorId(idBuscar);
            txtProducto.Text = productoCE.Descripcion;
            txtPrecio.Text = Convert.ToString(productoCE.Precio);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult rpta = MessageBox.Show("¿Está seguro que desea GUARDAR la venta?", "Advertencia!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (rpta == DialogResult.Yes)
            {
                VentaCE ventaCE = new VentaCE();
                ventaCE.FechaVenta = DateTime.Now;
                ventaCE.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                VentaCN ventaCN = new VentaCN();
                int idVenta = ventaCN.setInsertar(ventaCE);
                VentaDetalleCN ventaDetalleCN = new VentaDetalleCN();

                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.IsNewRow) 
                    { 
                    int idProducto = Convert.ToInt32(fila.Cells["colId"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["colCantidad"].Value);

                    VentaDetalleCE detalle = new VentaDetalleCE();
                    detalle.IdVenta = idVenta;
                    detalle.Producto.Id = idProducto;
                    detalle.Cantidad = cantidad;
                    detalle.FechaVenta = ventaCE.FechaVenta;

                    ventaDetalleCN.setInsertarDetalle(detalle, idVenta);
                    }
                }

                MessageBox.Show("La venta y sus detalles se han guardado correctamente.");
            }
        }

        private void dgvProductos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calcularTotalVenta();
        }
    }
}
