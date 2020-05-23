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
    public class ProductosDAO
    {
       public List<ListaProducto> listarProductos()
        {
			try
			{
				Conexion con = new Conexion();
				OracleConnection cn = con.getConexion();
				cn.Open();
				OracleCommand cmd = new OracleCommand("FN_LISTAR_PRODUCTOS", cn);
				cmd.CommandType = CommandType.StoredProcedure;

				List<ListaProducto> listapro = new List<ListaProducto>();
				OracleParameter output = cmd.Parameters.Add("C_PRODUCTOL", OracleDbType.RefCursor);
				output.Direction = ParameterDirection.ReturnValue;

				cmd.ExecuteNonQuery();

				OracleDataReader lecturaproducto = ((OracleRefCursor)output.Value).GetDataReader();

				while (lecturaproducto.Read())
				{
                    ListaProducto pro = new ListaProducto();
                    pro.idproducto = lecturaproducto.GetString(0);
                    pro.nombproducto = lecturaproducto.GetString(1);
                    int index = lecturaproducto.GetOrdinal("FECHA_VENC_PRODUCTO");
                    if (!lecturaproducto.IsDBNull(index))
                    {

                        pro.fecha_vencproducto = Convert.ToDateTime(lecturaproducto.GetDateTime(2)).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        pro.fecha_vencproducto = "00-00-0000";
                    }
                    pro.preciounitario = lecturaproducto.GetInt32(3);
                    pro.stock_producto = lecturaproducto.GetInt32(4);
                    pro.stock_critic = lecturaproducto.GetInt32(5);
                    pro.provee = lecturaproducto.GetString(6);
                    pro.tipo = lecturaproducto.GetString(7);

                    listapro.Add(pro);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listapro;

            }
			catch (Exception e)
			{

                throw;
            }
        }


        public void insertar(Producto pro)
        {
            try
            {   

                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_PRODUCTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ID_PRODUCTO", OracleDbType.Varchar2).Value = pro.Idproducto.Trim();
                cmd.Parameters.Add("NOM_PRODUCTO", OracleDbType.Varchar2).Value = pro.Nombproducto.Trim();
                if (pro.Fecha_vencproducto != null)
                {
                    cmd.Parameters.Add("FECHA_VENC_PRODUCTO", OracleDbType.Date).Value = DateTime.Parse(pro.Fecha_vencproducto);
                }
                else 
                {
                    cmd.Parameters.Add("FECHA_VENC_PRODUCTO", OracleDbType.Date).Value = null;
                }
                cmd.Parameters.Add("PRECIO_UNI_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Preciounitario);
                cmd.Parameters.Add("STOCK_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Stock_producto);
                cmd.Parameters.Add("STOCK_CRITICO_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Stock_critico);
                cmd.Parameters.Add("PROVEEDOR_ID_PROVEEDOR", OracleDbType.Int32).Value =Convert.ToInt32( pro.Idproveedor);
                cmd.Parameters.Add("TIPO_CLASE_ID_TIPO_CLASE", OracleDbType.Int32).Value = Convert.ToInt32(pro.Idclase);
                
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


        public void modificar_producto(string modi ,Producto pro)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_PRODUCTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter para = new OracleParameter("ID_MODIFICAR", OracleDbType.Varchar2);
                para.Direction = ParameterDirection.Input;
                para.Value = modi;
                cmd.Parameters.Add(para);

                cmd.Parameters.Add("ID_PRODUCTO", OracleDbType.Varchar2).Value = pro.Idproducto.Trim();
                cmd.Parameters.Add("NOM_PRODUCTO", OracleDbType.Varchar2).Value = pro.Nombproducto.Trim();
                if (pro.Fecha_vencproducto != null)
                {
                    cmd.Parameters.Add("FECHA_VENC_PRODUCTO", OracleDbType.Date).Value = DateTime.Parse(pro.Fecha_vencproducto);
                }
                else
                {
                    cmd.Parameters.Add("FECHA_VENC_PRODUCTO", OracleDbType.Date).Value = null;
                }
                
                cmd.Parameters.Add("PRECIO_UNI_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Preciounitario);
                cmd.Parameters.Add("STOCK_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Stock_producto);
                cmd.Parameters.Add("STOCK_CRITICO_PRODUCTO", OracleDbType.Int32).Value = Convert.ToInt32(pro.Stock_critico);
                cmd.Parameters.Add("PROVEEDOR_ID_PROVEEDOR", OracleDbType.Int32).Value = Convert.ToInt32(pro.Idproveedor);
                cmd.Parameters.Add("TIPO_CLASE_ID_TIPO_CLASE", OracleDbType.Int32).Value = Convert.ToInt32(pro.Idclase);

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
        public bool ExisteProdu(string id_pro)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_EXISTE_PRODU", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter falso = cmd.Parameters.Add("EXISTE", OracleDbType.Int32);
                falso.Direction = ParameterDirection.ReturnValue;
                OracleParameter id_produ = new OracleParameter("ID_PRO", OracleDbType.Varchar2);
                id_produ.Direction = ParameterDirection.Input;
                id_produ.Value = id_pro;
                cmd.Parameters.Add(id_produ);

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

        public List<ListaProducto> buscaridProducto(string id)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_BUSCARID_PRODUCTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //     cmd.Parameters.Add("PARAMETRO_ID", OracleDbType.Int32, id_clase, ParameterDirection.Input);

                List<ListaProducto> listatipocl = new List<ListaProducto>();
                OracleParameter output = cmd.Parameters.Add("C_PRODUCTOBUS", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                OracleParameter para = new OracleParameter("PARAMETRO_ID", OracleDbType.Int32);
                para.Direction = ParameterDirection.Input;
                para.Value = id;

                cmd.Parameters.Add(para);
                cmd.ExecuteNonQuery();

                OracleDataReader lecturatipocl = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturatipocl.Read())
                {
                    ListaProducto pro = new ListaProducto();
                    pro.idproducto = lecturatipocl.GetString(0);
                    pro.nombproducto = lecturatipocl.GetString(1);
                    int index = lecturatipocl.GetOrdinal("FECHA_VENC_PRODUCTO");
                    if (!lecturatipocl.IsDBNull(index))
                    {

                        pro.fecha_vencproducto = Convert.ToDateTime(lecturatipocl.GetDateTime(2)).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        pro.fecha_vencproducto = "00-00-0000";
                    }
                    pro.preciounitario = lecturatipocl.GetInt32(3);
                    pro.stock_producto = lecturatipocl.GetInt32(4);
                    pro.stock_critic = lecturatipocl.GetInt32(5);
                    pro.provee = lecturatipocl.GetString(6);
                    pro.tipo = lecturatipocl.GetString(7);

                    listatipocl.Add(pro);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listatipocl;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public List<ListaProducto> buscarnombProducto(string nomb)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_BUSCARNOMB_PRODUCTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
               

                List<ListaProducto> listatipocl = new List<ListaProducto>();
                OracleParameter output = cmd.Parameters.Add("C_PRODUCTOBUS", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                OracleParameter para = new OracleParameter("PARAMETRO_NOMB", OracleDbType.Varchar2);
                para.Direction = ParameterDirection.Input;
                para.Value = nomb;

                cmd.Parameters.Add(para);
                cmd.ExecuteNonQuery();

                OracleDataReader lecturatipocl = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturatipocl.Read())
                {
                    ListaProducto pro = new ListaProducto();
                    pro.idproducto = lecturatipocl.GetString(0);
                    pro.nombproducto = lecturatipocl.GetString(1);
                    int index = lecturatipocl.GetOrdinal("FECHA_VENC_PRODUCTO");
                    if (!lecturatipocl.IsDBNull(index))
                    {

                        pro.fecha_vencproducto = Convert.ToDateTime(lecturatipocl.GetDateTime(2)).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        pro.fecha_vencproducto = "00-00-0000";
                    }
                    pro.preciounitario = lecturatipocl.GetInt32(3);
                    pro.stock_producto = lecturatipocl.GetInt32(4);
                    pro.stock_critic = lecturatipocl.GetInt32(5);
                    pro.provee = lecturatipocl.GetString(6);
                    pro.tipo = lecturatipocl.GetString(7);

                    listatipocl.Add(pro);
                }
                output.Dispose();
                cmd.Dispose();
                cn.Dispose();
                con = null;
                return listatipocl;
            }
            catch (Exception e)
            {

                throw;
            }
        }


    }
 public class ListaProducto{
     public string idproducto { get; set; }
    public string nombproducto { get; set; }
        public string fecha_vencproducto { get; set; }
        public int preciounitario { get; set; }
        public int stock_producto { get; set; }
        public int stock_critic { get; set; }
    public string provee { get; set; }
        public string tipo { get; set; }
    }


    public class ListarProducto
    {
        public string idproducto { get; set; }
        public string nombproducto { get; set; }
        public string fecha_vencproducto { get; set; }
        public int preciounitario { get; set; }
        public int stock_producto { get; set; }
        public int stock_critic { get; set; }
        public string provee { get; set; }
        public string tipo { get; set; }
    }
}

