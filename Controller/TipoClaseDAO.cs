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
    public class TipoClaseDAO
    {
        public List<ListarCombo> cargaComboTipoClase(int id_clase)
        {
            try
            {
                Conexion con = new Conexion();
                OracleConnection cn = con.getConexion();
                cn.Open();
                OracleCommand cmd = new OracleCommand("FN_TIPO_CLASE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //     cmd.Parameters.Add("PARAMETRO_ID", OracleDbType.Int32, id_clase, ParameterDirection.Input);
                
                List<ListarCombo> listatipocl = new List<ListarCombo>();
                OracleParameter output = cmd.Parameters.Add("C_TCLASE", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                OracleParameter para = new OracleParameter("PARAMETRO_ID", OracleDbType.Int32);
                para.Direction = ParameterDirection.Input;
                para.Value = id_clase;

                cmd.Parameters.Add(para);
                cmd.ExecuteNonQuery();

                OracleDataReader lecturatipocl = ((OracleRefCursor)output.Value).GetDataReader();

                while (lecturatipocl.Read())
                {
                    ListarCombo litc = new ListarCombo();
                    litc.id = lecturatipocl.GetInt32(0);
                    litc.nombre = lecturatipocl.GetString(1);
                    listatipocl.Add(litc);
                }
                return listatipocl;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }

    public class ListarCombo
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public ListarCombo()
        {
                
        }

    }
}
