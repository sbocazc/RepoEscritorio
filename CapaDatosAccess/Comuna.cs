using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Comuna
    {
        private int _id_comuna;
        private string _nombre_comuna;
        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }
        public string Nombre_comuna { get => _nombre_comuna; set => _nombre_comuna = value; }

        public Comuna()
        {

        }

        
    }
}
