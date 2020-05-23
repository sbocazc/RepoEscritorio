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
    public class ComunaDAO
    {
        public List<listarComuna> carga_ComboComuna()
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_LISTAR_COMBO_COMUNA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<listarComuna> listacomuna = new List<listarComuna>();
                OracleParameter output = cmd.Parameters.Add("C_COMUNA", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader lecturacomuna = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturacomuna.Read())
                {
                    listarComuna comun = new listarComuna();
                    comun.id = lecturacomuna.GetInt32(0);
                    comun.nombre = lecturacomuna.GetString(1);
                    listacomuna.Add(comun);
                }
                return listacomuna;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }

    public class listarComuna
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public listarComuna()
        {

        }


        
    }
}
