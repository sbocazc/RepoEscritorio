using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Colaborador
    {
        private string rut_cola;
        private string _nombre;
        private string _apellido;
        private string _tipoUsu;
        private string _nomusuario;
        private string _password;
        private int activo;

        public string Rut_cola { get => rut_cola; set => rut_cola = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string TipoUsu { get => _tipoUsu; set => _tipoUsu = value; }
        public string Nomusuario { get => _nomusuario; set => _nomusuario = value; }
        public string Password { get => _password; set => _password = value; }
        public int Activo { get => activo; set => activo = value; }

        public Colaborador()
        {
                
        }
    }
}
