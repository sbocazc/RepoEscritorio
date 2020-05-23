using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using CapaDatosAccess;

namespace Controller
{
    public class UsuariosDAO
    {
        public List<ListaUsuarios> listaUsu()
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_USUARIOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ListaUsuarios> lista = new List<ListaUsuarios>();
                OracleParameter output = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListaUsuarios usua = new ListaUsuarios();
                        usua.rut = reader.GetString(0);
                        usua.nombre = reader.GetString(1);
                        usua.apellido = reader.GetString(2);
                        usua.email = reader.GetString(3);
                        usua.cargo = reader.GetString(4);
                        usua.nomusu = reader.GetString(5);
                        usua.password = reader.GetString(6);
                        lista.Add(usua);
                       
                    }
                }
                else
                {
                    ListaUsuarios usua = new ListaUsuarios();
                    usua.rut = "--";
                    usua.nombre = "--";
                    usua.apellido = "--";
                    usua.email = "--";
                    usua.nomusu = "--";
                    usua.password = "--";
                    lista.Add(usua);
                }
                cn.Close();
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                objCone = null;
                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

public class ListaUsuarios
{
    public string rut { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string email { get; set; }
    public string cargo { get; set; }
    public string nomusu { get; set; }
    public string password { get; set; }

}