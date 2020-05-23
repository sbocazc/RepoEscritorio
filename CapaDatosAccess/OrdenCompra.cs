using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class OrdenCompra
    {
        private int id_orden;
        private int id_prov;
        private int id_cola;
        private string nom_produ;
        private int cantidad;

        public int Id_orden { get => id_orden; set => id_orden = value; }
        public int Id_prov { get => id_prov; set => id_prov = value; }
        public int Id_cola { get => id_cola; set => id_cola = value; }
        public string Nom_produ { get => nom_produ; set => nom_produ = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public OrdenCompra()
        {

        }
    }
}
