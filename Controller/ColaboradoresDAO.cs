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

        public List<Colaborador> listarUsuarios()
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_COLABORADOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Colaborador> lista = new List<Colaborador>();
                OracleParameter output = cmd.Parameters.Add("C_COLABORA", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Colaborador cola = new Colaborador();
                        cola.Rut_cola = reader.GetString(0);
                        cola.Nombre = reader.GetString(1);
                        cola.Apellido = reader.GetString(2);
                        cola.TipoUsu = reader.GetString(3);
                        cola.Nomusuario = reader.GetString(4);
                        cola.Password = reader.GetString(5);
                        cola.Activo = reader.GetInt32(6);
                        lista.Add(cola);
                    }
                }
                else
                {
                    Colaborador cola = new Colaborador();
                    cola.Rut_cola = "";
                    cola.Nombre = "";
                    cola.Apellido = "";
                    cola.TipoUsu = "";
                    cola.Nomusuario = "";
                    cola.Password = "";
                    cola.Activo = 0;
                    lista.Add(cola);
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

        public bool ExisteCola(string rut)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_EXISTE_COLABORA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter falso = cmd.Parameters.Add("EXISTE", OracleDbType.Int32);
                falso.Direction = ParameterDirection.ReturnValue;
                OracleParameter rutemp = new OracleParameter("RUT", OracleDbType.Varchar2);
                rutemp.Direction = ParameterDirection.Input;
                rutemp.Value = rut;
                cmd.Parameters.Add(rutemp);

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

        //public List<Colaborador> Lista()
        //{

        //}

        //public List<Colaborador> ListaInactivos()
        //{

        //}


        public void insertar(Colaborador cola)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_COLA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = cola.Rut_cola;
                cmd.Parameters.Add("ACTIVO_VAL", OracleDbType.Int32).Value = cola.Activo;
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();
                cn.Dispose();
                objCone = null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool eliminar(Colaborador cola)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_ELIMINAR_COLA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = cola.Rut_cola;
                int x = cmd.ExecuteNonQuery();
                if (x == 0)
                {
                    cn.Close();
                    cmd.Dispose();
                    cn.Dispose();
                    objCone = null;
                    return false;

                }
                else
                {
                    cn.Close();
                    cmd.Dispose();
                    cn.Dispose();
                    objCone = null;
                    return true;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<llenarCombo> llenar()
        {
            Conexion objCone = new Conexion();
            OracleConnection cn = objCone.getConexion();
            cn.Open();
            OracleCommand cmd = new OracleCommand("FN_COLABORADOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            List<llenarCombo> lista = new List<llenarCombo>();
            OracleParameter output = cmd.Parameters.Add("C_COLABORA", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    llenarCombo llena = new llenarCombo();
                    llena.rut = reader.GetString(0);
                    llena.nombre = reader.GetString(1);

                    lista.Add(llena);
                }
            }
            else
            {
                llenarCombo llena = new llenarCombo();
                llena.rut = "";
                llena.nombre = "";

                lista.Add(llena);
            }
            return lista;
        }
    }
    public class llenarCombo
    {
        public string rut;
        public string nombre;
    }
}
