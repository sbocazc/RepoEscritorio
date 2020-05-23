using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Controller
{
    public class ClienteDAO
    {
        public List<listarCliente> listarClientes()
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_LISTAR_CLIENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<listarCliente> listacli = new List<listarCliente>();
                OracleParameter output = cmd.Parameters.Add("C_CLIENTESL", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader lecturacliente = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturacliente.Read())
                {
                    listarCliente cli = new listarCliente();
                    cli.rut = lecturacliente.GetString(0);
                    cli.nombres = lecturacliente.GetString(1);
                    cli.apellidos = lecturacliente.GetString(2);
                   
                    int index = lecturacliente.GetOrdinal("DIRECCION_CLIENTE");
                    if (!lecturacliente.IsDBNull(index))
                    {

                      cli.direccion = lecturacliente.GetString(3);
                    }
                    else
                    {
                      cli.direccion = "NO HAY REGISTRO";
                    }
                    cli.fono = lecturacliente.GetInt32(4);
                    cli.email = lecturacliente.GetString(5);
                    cli.comuna = lecturacliente.GetString(6);



                    listacli.Add(cli);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listacli;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void insertarCliente(Cliente cli)
        {
            try
            {

                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("RUT_CLIENTE", OracleDbType.Varchar2).Value = cli.Rut.Trim();
                cmd.Parameters.Add("NOMB_CLIENTE", OracleDbType.Varchar2).Value = cli.Nombres.Trim();
                cmd.Parameters.Add("APELLIDOS_CLIENTE", OracleDbType.Varchar2).Value = cli.Apellidos.Trim();

                if (cli.Direccioncli != null)
                {
                    cmd.Parameters.Add("DIRECCION_CLIENTE", OracleDbType.Varchar2).Value = cli.Direccioncli.Trim();
                }
                else
                {
                    cmd.Parameters.Add("DIRECCION_CLIENTE", OracleDbType.Varchar2).Value = null;
                }
                cmd.Parameters.Add("FONO_CLIENTE", OracleDbType.Int32).Value = Convert.ToInt32(cli.Fono_cliente);
                cmd.Parameters.Add("EMAIL_CLIENTE", OracleDbType.Varchar2).Value =cli.Email_cli;
                cmd.Parameters.Add("COMUNA_ID_COMUNA", OracleDbType.Int32).Value = Convert.ToInt32(cli.Idcomuna_cli);
                


                cmd.ExecuteNonQuery();

                cn.Close();
                cmd.Dispose();
                cn.Dispose();
                con = null;

            }
            catch (Exception e)
            {

                throw;
            }

        }


        public void modificarCliente(string modi,Cliente cli)
        {
            try
            {

                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter para = new OracleParameter("ID_MODIFICAR", OracleDbType.Varchar2);
                para.Direction = ParameterDirection.Input;
                para.Value = modi;
                cmd.Parameters.Add(para);

                cmd.Parameters.Add("RUT_CLIENTE", OracleDbType.Varchar2).Value = cli.Rut.Trim();
                cmd.Parameters.Add("NOMB_CLIENTE", OracleDbType.Varchar2).Value = cli.Nombres.Trim();
                cmd.Parameters.Add("APELLIDOS_CLIENTE", OracleDbType.Varchar2).Value = cli.Apellidos.Trim();

                if (cli.Direccioncli != null)
                {
                    cmd.Parameters.Add("DIRECCION_CLIENTE", OracleDbType.Varchar2).Value = cli.Direccioncli.Trim();
                }
                else
                {
                    cmd.Parameters.Add("DIRECCION_CLIENTE", OracleDbType.Varchar2).Value = null;
                }
                cmd.Parameters.Add("FONO_CLIENTE", OracleDbType.Int32).Value = Convert.ToInt32(cli.Fono_cliente);
                cmd.Parameters.Add("EMAIL_CLIENTE", OracleDbType.Varchar2).Value = cli.Email_cli;
                cmd.Parameters.Add("COMUNA_ID_COMUNA", OracleDbType.Int32).Value = Convert.ToInt32(cli.Idcomuna_cli);

                cmd.ExecuteNonQuery();

                cn.Close();
                cmd.Dispose();
                cn.Dispose();
                con = null;

            }
            catch (Exception e)
            {

                throw;
            }

        }

        public bool ExisteCliente(string rut_cli)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_EXISTE_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter falso = cmd.Parameters.Add("EXISTE", OracleDbType.Int32);
                falso.Direction = ParameterDirection.ReturnValue;
                OracleParameter rut = new OracleParameter("RUT", OracleDbType.Varchar2);
                rut.Direction = ParameterDirection.Input;
                rut.Value = rut_cli;
                cmd.Parameters.Add(rut);

                cmd.ExecuteNonQuery();

                var existe = cmd.Parameters["EXISTE"].Value.ToString();
                if (existe == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<listarCliente> buscarRutCLiente(string rut)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_BUSCARRUT_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<listarCliente> listacli = new List<listarCliente>();
                OracleParameter output = cmd.Parameters.Add("C_CLIENTESBR", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                OracleParameter para = new OracleParameter("PARAMETRO_RUT", OracleDbType.Int32);
                para.Direction = ParameterDirection.Input;
                para.Value = rut;

                cmd.Parameters.Add(para);

                cmd.ExecuteNonQuery();

                OracleDataReader lecturacliente = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturacliente.Read())
                {
                    listarCliente cli = new listarCliente();
                    cli.rut = lecturacliente.GetString(0);
                    cli.nombres = lecturacliente.GetString(1);
                    cli.apellidos = lecturacliente.GetString(2);

                    int index = lecturacliente.GetOrdinal("DIRECCION_CLIENTE");
                    if (!lecturacliente.IsDBNull(index))
                    {

                        cli.direccion = lecturacliente.GetString(3);
                    }
                    else
                    {
                        cli.direccion = "NO HAY REGISTRO";
                    }
                    cli.fono = lecturacliente.GetInt32(4);
                    cli.email = lecturacliente.GetString(5);
                    cli.comuna = lecturacliente.GetString(6);



                    listacli.Add(cli);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listacli;

            }
            catch (Exception e)
            {

                throw;
            }
        }

    }

    public class listarCliente
    {
        public string rut {get;set;}
        public string nombres { get; set; }
        public string apellidos { get; set; }
     
        public string direccion { get; set; }
        public int fono { get; set; }
        public string email { get; set; }
        public string comuna { get; set; }

    }
}
