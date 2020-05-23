using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class TipoClase
    {
        private int _id_tipoclase;
        private string _descripcion_tipoclase;
        private int _clase_id_clase;

        public int Id_tipoclase { get => _id_tipoclase; set => _id_tipoclase = value; }
        public string Descripcion_tipoclase { get => _descripcion_tipoclase; set => _descripcion_tipoclase = value; }
        public int Clase_id_clase { get => _clase_id_clase; set => _clase_id_clase = value; }

        public TipoClase()
        {

        }
    }
}
