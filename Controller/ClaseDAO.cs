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
using System.Runtime.Remoting.Messaging;

namespace Controller
{
    public class ClaseDAO
    {
        public List<ListarClase> cargaComboClase()
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_LISTAR_COMBO_CLASE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ListarClase> listaclase = new List<ListarClase>();
                OracleParameter output = cmd.Parameters.Add("C_CBO_CLASE", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader lecturaclase = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturaclase.Read())
                {
                    ListarClase lc = new ListarClase();
                    lc.id = lecturaclase.GetInt32(0);
                    lc.nombre = lecturaclase.GetString(1);
                    listaclase.Add(lc);
                }
                return listaclase;
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }   


    public class ListarClase
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public ListarClase()
        {
                
        }
    }

}
