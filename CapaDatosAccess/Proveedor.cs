using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Proveedor
    {

        private int _id_proveedor;
        private string _nombproveedor;
        private int _fonoproveedor;
        private string _rubroproveedor;

        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public string Nombproveedor { get => _nombproveedor; set => _nombproveedor = value; }
        public int Fonoproveedor { get => _fonoproveedor; set => _fonoproveedor = value; }
        public string Rubroproveedor { get => _rubroproveedor; set => _rubroproveedor = value; }

        public Proveedor()
        {

        }

    }
}
