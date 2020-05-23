using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Clase
    {
        private int _id_clase;
        private string _desc_clase;

        public int Id_clase { get => _id_clase; set => _id_clase = value; }
        public string Desc_clase { get => _desc_clase; set => _desc_clase = value; }


        public Clase()
        {

        }

    }
}
