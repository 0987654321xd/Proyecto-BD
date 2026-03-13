using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCE
    {
        private int id;
        private string descripcion;
        private string categoria;
        private double precio;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
        public string Categoria
        {
            get
            {
                return this.categoria;
            }
            set
            {
                this.categoria = value;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        public ProductoCE()
        {
            this.id = 0;
            this.descripcion = "";
            this.categoria = "";
            this.precio = 0.0;
        }
        public ProductoCE(int id, string descripcion, string categoria, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
        }
    }
}
