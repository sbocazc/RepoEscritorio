using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Usuario
    {
        private string _rut;
        private string _nombre;
        private string _snombre;
        private string _apellido;
        private string _apematerno;
        private string _direccion;
        private int _fono;
        private string _email;
        private string _nomusuario;
        private string _password;
        private string _tipoUsu;
        private string _comuna;

        

        public string Rut { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Snombre { get => _snombre; set => _snombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Apematerno { get => _apematerno; set => _apematerno = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int Fono { get => _fono; set => _fono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Nomusuario { get => _nomusuario; set => _nomusuario = value; }
        public string Password { get => _password; set => _password = value; }
        public string TipoUsu { get => _tipoUsu; set => _tipoUsu = value; }
        public string Comuna { get => _comuna; set => _comuna = value; }


        public Usuario()
        {

        }

    }
}
