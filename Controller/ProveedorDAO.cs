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
namespace Controller
{
    public class ProveedorDAO
    {
        public List<ListaCombo> cargaComboProve()
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_LISTAR_COMBO_PROVEEDORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ListaCombo> listaprove = new List<ListaCombo>();
                OracleParameter output = cmd.Parameters.Add("C_CBO_PROVEEDOR", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader lecturad = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturad.Read())
                {
                    ListaCombo li = new ListaCombo();
                    li.id = lecturad.GetInt32(0);
                    li.nombre = lecturad.GetString(1);
                    listaprove.Add(li);
                }

                return listaprove;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public List<ListarProveedor>  listarProvedores()
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_LISTAR_PROVEEDORES",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ListarProveedor> listpro = new List<ListarProveedor>();
                OracleParameter output = cmd.Parameters.Add("C_PROVEEDORL", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                OracleDataReader lecturaproveedor = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturaproveedor.Read())
                {
                    ListarProveedor prove = new ListarProveedor();
                    prove.idproveedor = lecturaproveedor.GetInt32(0);
                    prove.nombreprove = lecturaproveedor.GetString(1);
                    prove.fonoprove = lecturaproveedor.GetInt32(2);
                    prove.rubroprove = lecturaproveedor.GetString(3);
                    listpro.Add(prove);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listpro;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void insertar_proveedor (Proveedor pro)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_PROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ID_PROVEEDOR", OracleDbType.Int32).Value = pro.Id_proveedor;
                cmd.Parameters.Add("NOMB_PROVEEDOR", OracleDbType.Varchar2).Value = pro.Nombproveedor;
                cmd.Parameters.Add("FONO_PROVEEDOR", OracleDbType.Int32).Value = pro.Fonoproveedor;
                cmd.Parameters.Add("RUBRO_PROVEEDOR", OracleDbType.Varchar2).Value = pro.Rubroproveedor;
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

        public bool ExisteProveedor(int id_prove)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_EXISTE_PROVEE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter falso = cmd.Parameters.Add("EXISTE", OracleDbType.Int32);
                falso.Direction = ParameterDirection.ReturnValue;
                OracleParameter id_proveedor = new OracleParameter("ID_PROVEE", OracleDbType.Int32);
                id_proveedor.Direction = ParameterDirection.Input;
                id_proveedor.Value = id_prove;
                cmd.Parameters.Add(id_proveedor);

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


        public void modificar_proveedor(int modi, Proveedor pro)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_PROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter para = new OracleParameter("ID_MODIFICAR", OracleDbType.Int32);
                para.Direction = ParameterDirection.Input;
                para.Value = modi;
                cmd.Parameters.Add(para);

                cmd.Parameters.Add("ID_PROVEEDOR", OracleDbType.Int32).Value = pro.Id_proveedor;
                cmd.Parameters.Add("NOMB_PROVEEDOR", OracleDbType.Varchar2).Value = pro.Nombproveedor;
                cmd.Parameters.Add("FONO_PROVEEDOR", OracleDbType.Int32).Value = pro.Fonoproveedor;
                cmd.Parameters.Add("RUBRO_PROVEEDOR", OracleDbType.Varchar2).Value = pro.Rubroproveedor;
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

            public List<ListarProveedor> buscarnombProveedor(string nomb)
            {
                try
                {
                    Conexion con = new Conexion();
                    OracleConnection cn = con.getConexion();
                    cn.Open();
                    OracleCommand cmd = new OracleCommand("FN_BUSCARNOMB_PROVEEDOR", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<ListarProveedor> listpro = new List<ListarProveedor>();
                    OracleParameter output = cmd.Parameters.Add("C_PROVEEBUS", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;

                    OracleParameter para = new OracleParameter("PARAMETRO_NOMB", OracleDbType.Varchar2);
                    para.Direction = ParameterDirection.Input;
                    para.Value = nomb;

                    cmd.Parameters.Add(para);
                    cmd.ExecuteNonQuery();

                OracleDataReader lecturaproveedor = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturaproveedor.Read())
                {
                    ListarProveedor prove = new ListarProveedor();
                    prove.idproveedor = lecturaproveedor.GetInt32(0);
                    prove.nombreprove = lecturaproveedor.GetString(1);
                    prove.fonoprove = lecturaproveedor.GetInt32(2);
                    prove.rubroprove = lecturaproveedor.GetString(3);
                    listpro.Add(prove);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listpro;
            }
                catch (Exception e)
                {

                    throw;
                }
            }


        public List<ListarProveedor> buscarRubProveedor(string rub)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_BUSCARRUBRO_PROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ListarProveedor> listpro = new List<ListarProveedor>();
                OracleParameter output = cmd.Parameters.Add("C_PROVEEBUSc", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                OracleParameter para = new OracleParameter("PARAMETRO_RUBRO", OracleDbType.Varchar2);
                para.Direction = ParameterDirection.Input;
                para.Value = rub;

                cmd.Parameters.Add(para);
                cmd.ExecuteNonQuery();

                OracleDataReader lecturaproveedor = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturaproveedor.Read())
                {
                    ListarProveedor prove = new ListarProveedor();
                    prove.idproveedor = lecturaproveedor.GetInt32(0);
                    prove.nombreprove = lecturaproveedor.GetString(1);
                    prove.fonoprove = lecturaproveedor.GetInt32(2);
                    prove.rubroprove = lecturaproveedor.GetString(3);
                    listpro.Add(prove);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listpro;
            }
            catch (Exception e)
            {

                throw;
            }
        }




    }
    public class ListaCombo{
        public int id { get; set; }
        public string nombre { get; set; }

        public ListaCombo()
        {

        }
    }
    public class ListarProveedor
    {
        public int idproveedor { get; set; }
        public string nombreprove { get; set; }
        public int fonoprove { get; set; }
        public string rubroprove { get; set; }
    }
}

