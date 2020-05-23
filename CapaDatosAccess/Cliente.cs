using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAccess
{
    public class Cliente
    {
        private string _rut;
        private string _nombres;
       
        private string _apellidos;
        
        private string _direccioncli;
        private int _fono_cliente;
        private string _email_cli;
        private int _idcomuna_cli;


        public string Rut { get => _rut; set => _rut = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Direccioncli { get => _direccioncli; set => _direccioncli = value; }
        public int Fono_cliente { get => _fono_cliente; set => _fono_cliente = value; }
        public string Email_cli { get => _email_cli; set => _email_cli = value; }
        public int Idcomuna_cli { get => _idcomuna_cli; set => _idcomuna_cli = value; }


        public Cliente()
        {

        }

       
    }


}
