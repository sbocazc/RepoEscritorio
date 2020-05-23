using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Producto
    {
        private string _idproducto;
        private string _nombproducto;
        private string _fecha_vencproducto;
        private int _preciounitario;
        private int _stock_producto;
        private int _stock_critico;
        private int _idproveedor;
        private int _idclase;

        public string Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Nombproducto { get => _nombproducto; set => _nombproducto = value; }
        public string Fecha_vencproducto { get => _fecha_vencproducto; set => _fecha_vencproducto = value; }
        public int Preciounitario { get => _preciounitario; set => _preciounitario = value; }
        public int Stock_producto { get => _stock_producto; set => _stock_producto = value; }
        public int Stock_critico { get => _stock_critico; set => _stock_critico = value; }
        public int Idproveedor { get => _idproveedor; set => _idproveedor = value; }
        public int Idclase { get => _idclase; set => _idclase = value; }

        // private int _idtipoclase;
        // private int _idprove_producto;
        public Producto()
        {

        }


        // public int Idtipoclase { get => _idtipoclase; set => _idtipoclase = value; }
        // public int Idprove_producto { get => _idprove_producto; set => _idprove_producto = value; }

    }
}
