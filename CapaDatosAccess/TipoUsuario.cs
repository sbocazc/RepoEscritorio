using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class TipoUsuario
    {
        private int _id_tipo_usu;
        private string _desc_tipo_usu;
        public int id_tipo_usu { get => _id_tipo_usu; set => _id_tipo_usu = value; }
        public string desc_tipo_usu { get => _desc_tipo_usu; set => _desc_tipo_usu = value; }
      
        public TipoUsuario()
        {

        }
    }
}
