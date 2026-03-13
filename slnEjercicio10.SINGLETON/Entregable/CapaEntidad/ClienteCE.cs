using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClienteCE
    {
        private int id;
        private string nombre;
        private string numruc;
        private string direccion;
        private string telefono;

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
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Numruc
        {
            get
            {
                return this.numruc;
            }
            set
            {
                this.numruc = value;
            }
        }
        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }
        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }
        public ClienteCE()
        {
            this.id = 0;
            this.nombre = "";
            this.numruc = "";
            this.direccion = "";
            this.telefono = "";
        }
        public ClienteCE(int id, string nombre, string numruc, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.numruc = numruc;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}
