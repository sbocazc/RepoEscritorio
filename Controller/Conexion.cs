using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
namespace Controller
{
    public class Conexion
    {
        private OracleConnection cn { get; set; }

        public OracleConnection getConexion()
        {
            try
            {
                if (cn == null)
                {
                    string conexion = ConfigurationManager.ConnectionStrings["conectionDB"].ConnectionString;
                    cn = new OracleConnection(conexion);
                }
                return cn;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
