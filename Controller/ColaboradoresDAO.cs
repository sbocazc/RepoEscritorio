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
   
    public class ColaboradoresDAO
    {
        
        public List<Usuario> listarUsuarios()
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_USUARIOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Usuario> lista = new List<Usuario>();
                OracleParameter output = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Rut = reader.GetString(0);
                    usu.Nombre = reader.GetString(1);
                    usu.Snombre = reader.GetString(2);
                    usu.Apellido = reader.GetString(3);
                    usu.Apematerno = reader.GetString(4);
                    usu.Direccion = reader.GetString(5);
                    usu.Fono = reader.GetInt32(6);
                    usu.Email = reader.GetString(7);
                    usu.Nomusuario = reader.GetString(8);
                    usu.Password = reader.GetString(9);
                    usu.TipoUsu = reader.GetString(10);
                    usu.Comuna = reader.GetString(11);
                    usu.Idtipo = reader.GetInt32(12);
                    usu.Idcomu = reader.GetInt32(13);

                    lista.Add(usu);
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

        public bool insertar(Usuario usu)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_USUARIO", cn);
                Usuario usuadd = new Usuario();


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = usuadd.Rut;
                cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = usuadd.Nombre;
                cmd.Parameters.Add("SNOMBRE", OracleDbType.Varchar2).Value = usuadd.Snombre;
                cmd.Parameters.Add("APATERNO", OracleDbType.Varchar2).Value = usuadd.Apellido;
                cmd.Parameters.Add("AMATERNO", OracleDbType.Varchar2).Value = usuadd.Apematerno;
                cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2).Value = usuadd.Direccion;
                cmd.Parameters.Add("FONO", OracleDbType.Int32).Value = usuadd.Fono;
                cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = usuadd.Email;
                cmd.Parameters.Add("LOGIN", OracleDbType.Varchar2).Value = usuadd.Nomusuario;
                cmd.Parameters.Add("LPASSWORD", OracleDbType.Varchar2).Value = usuadd.Password;
                cmd.Parameters.Add("TIPO", OracleDbType.Int32).Value = usuadd.Idtipo;
                cmd.Parameters.Add("COMUNA", OracleDbType.Int32).Value = usuadd.Idcomu;

                int correct = cmd.ExecuteNonQuery();
                if (correct == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public bool modificar(Usuario usu)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_USUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                Usuario usumod = new Usuario();
                cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = usumod.Rut;
                cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = usumod.Nombre;
                cmd.Parameters.Add("SNOMBRE", OracleDbType.Varchar2).Value = usumod.Snombre;
                cmd.Parameters.Add("APATERNO", OracleDbType.Varchar2).Value = usumod.Apellido;
                cmd.Parameters.Add("AMATERNO", OracleDbType.Varchar2).Value = usumod.Apematerno;
                cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2).Value = usumod.Direccion;
                cmd.Parameters.Add("FONO", OracleDbType.Int32).Value = usumod.Fono;
                cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = usu.Email;
                cmd.Parameters.Add("LOGIN", OracleDbType.Varchar2).Value = usu.Nomusuario;
                cmd.Parameters.Add("LPASSWORD", OracleDbType.Varchar2).Value = usumod.Password;
                cmd.Parameters.Add("TIPO", OracleDbType.Int32).Value = usumod.Idtipo;
                cmd.Parameters.Add("COMUNA", OracleDbType.Int32).Value = usumod.Idcomu;

                int correct = cmd.ExecuteNonQuery();
                if (correct == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }
        public bool eliminar(string rut)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                OracleCommand cmd = new OracleCommand("SP_ELIMINAR_USUARIO", cn);
                Usuario eliusu = new Usuario();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = eliusu.Rut;
                int correct = cmd.ExecuteNonQuery();
                if (correct == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
