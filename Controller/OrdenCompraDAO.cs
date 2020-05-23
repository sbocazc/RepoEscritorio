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
    public class OrdenCompraDAO
    {
        public List<listaOrdenCompra> ordenLista()
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_ORDENCOMPRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<listaOrdenCompra> lista = new List<listaOrdenCompra>();
                OracleParameter output = cmd.Parameters.Add("C_ORDENCOMPRA", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listaOrdenCompra ord = new listaOrdenCompra();
                        ord.id_orden = reader.GetInt32(0);
                        ord.provee = reader.GetString(1);
                        ord.nombre_cola = reader.GetString(2);
                        ord.nom_produ = reader.GetString(3);
                        ord.cantidad = reader.GetInt32(4);
                        
                        lista.Add(ord);
                    }
                }
                else
                {
                    listaOrdenCompra ord = new listaOrdenCompra();
                    ord.id_orden = 0;
                    ord.provee = "";
                    ord.nombre_cola = "";
                    ord.nom_produ = "";
                    ord.cantidad = 0;

                    lista.Add(ord);
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

        public void insertar(OrdenCompra orden)
        {
            try
            {
                Conexion objCone = new Conexion();
                OracleConnection cn = objCone.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_AGREGAR_ORDEN", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ID_PROVE", OracleDbType.Varchar2).Value = orden.Id_prov;
                cmd.Parameters.Add("ID_COLA", OracleDbType.Int32).Value = orden.Id_cola;
                cmd.Parameters.Add("NOMPRO", OracleDbType.Varchar2).Value = orden.Nom_produ;
                cmd.Parameters.Add("CANTI", OracleDbType.Int32).Value = orden.Cantidad;
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



    }
    public class listaOrdenCompra
    {
        public int id_orden { get; set; }
        public string provee { get; set; }
        public string nombre_cola { get; set; }
        public string nom_produ { get; set; }
        public int cantidad { get; set; }
    }
}
