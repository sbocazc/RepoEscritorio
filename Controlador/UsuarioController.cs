using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosAccess;
namespace Controlador
{
    public class UsuarioController
    {
        private List<Usuario> usuarios;
        
        public UsuarioController()
        {
            usuarios = new List<Usuario>();
        }
        public List<Usuario> Listar()
        {
            return usuarios;
        }
    }
}
