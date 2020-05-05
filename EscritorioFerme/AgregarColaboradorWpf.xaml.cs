using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaDatosAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
//popups
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Messages.Core;
using ToastNotifications.Core;

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for AgregarColaboradorWpf.xaml
    /// </summary>
    public partial class AgregarColaboradorWpf : Window
    {
        OracleConnection conn = null;
        public AgregarColaboradorWpf()
        {
            Conexion();
            InitializeComponent();
            CargaComboTipo();
            CargaComboComuna();
        }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new PrimaryScreenPositionProvider(
                corner: Corner.TopRight,
                offsetX: 63,
                offsetY: 50);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(5),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
            cfg.DisplayOptions.TopMost = true; // set the option to show notifications over other windows
            cfg.DisplayOptions.Width = 500; // set the notifications width
            
        });
        MessageOptions options = new MessageOptions
        {
            FontSize = 25, // set notification font size
            ShowCloseButton = false, // set the option to show or hide notification close button
            FreezeOnMouseEnter = true, // set the option to prevent notification dissapear automatically if user move cursor on it
        };
        private void CargaComboComuna()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("FN_COMUNA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Comuna> listacom = new List<Comuna>();
                ComboBoxItem m = new ComboBoxItem();
                OracleParameter output = cmd.Parameters.Add("C_COMUNA", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Comuna com = new Comuna();

                    com.Id_comuna = reader.GetInt32(0);
                    com.Nombre_comuna = reader.GetString(1);

                    listacom.Add(com);
                }
                foreach (var item in listacom)
                {
                    ComboboxItemLlenado cbm = new ComboboxItemLlenado();
                    cbm.Id = item.Id_comuna;
                    cbm.Texto = item.Nombre_comuna;
                    cboComuna.Items.Add(cbm);
                }
                
            }
            catch (Exception)
            {
                notifier.ShowWarning("No se pudieron cargar las comunas", options);
            }
        }

        private void CargaComboTipo()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("FN_TUSARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<TipoUsuario> tipusu = new List<TipoUsuario>();
                
                OracleParameter output = cmd.Parameters.Add("C_TUSUARIO", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    TipoUsuario tip = new TipoUsuario();
                    
                        tip.id_tipo_usu = reader.GetInt32(0);
                        tip.desc_tipo_usu = reader.GetString(1);

                        tipusu.Add(tip);
                }
                foreach (var item in tipusu)
                {
                    ComboboxItemLlenado m = new ComboboxItemLlenado();
                    m.Id = item.id_tipo_usu;
                    m.Texto = item.desc_tipo_usu;
                    cboUsu.Items.Add(m);
                }
            }
            catch (Exception)
            {
                notifier.ShowWarning("No se pudo carga el tipo de usuario", options);
            }
        }

        private void Conexion()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conectionDB"].ConnectionString;
                conn = new OracleConnection(connectionString);
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error con la conexión");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error conexión");
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregarUsu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControlColaboradores colLista = new UserControlColaboradores();
                int idComuna = 0;
                int idUsu = 0;
                
                OracleCommand cmd = new OracleCommand("SP_INSERTAR_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (txtRut.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtSNombre.Text.Trim() == "" ||
                    txtPaterno.Text.Trim() == "" || txtMaterno.Text.Trim() == "" || txtDireccion.Text.Trim() == "" ||
                    txtFono.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtUsuario.Text.Trim() == "" ||
                    txtContra.Text.Trim() == "" || idUsu == 0 || idComuna == 0)
                {
                    notifier.ShowWarning("Debe ingresar todos los campos", options);
                }
                else
                {
                    idComuna = ((ComboboxItemLlenado)cboComuna.SelectedItem).Id;
                    idUsu = ((ComboboxItemLlenado)cboUsu.SelectedItem).Id;
                    cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = txtRut.Text.Trim();
                    cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = txtNombre.Text.Trim();
                    cmd.Parameters.Add("SNOMBRE", OracleDbType.Varchar2).Value = txtSNombre.Text.Trim();
                    cmd.Parameters.Add("APATERNO", OracleDbType.Varchar2).Value = txtPaterno.Text.Trim();
                    cmd.Parameters.Add("AMATERNO", OracleDbType.Varchar2).Value = txtMaterno.Text.Trim();
                    cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2).Value = txtDireccion.Text.Trim();
                    cmd.Parameters.Add("FONO", OracleDbType.Int32).Value = txtFono.Text.Trim();
                    cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("LOGIN", OracleDbType.Varchar2).Value = txtUsuario.Text.Trim();
                    cmd.Parameters.Add("LPASSWORD", OracleDbType.Varchar2).Value = txtContra.Text.Trim();
                    cmd.Parameters.Add("TIPO", OracleDbType.Int32).Value = idUsu;
                    cmd.Parameters.Add("COMUNA", OracleDbType.Int32).Value = idComuna;

                    int correct = cmd.ExecuteNonQuery();
                    if (correct > 0)
                    {
                        colLista.dataGrid.Items.Refresh();
                        notifier.ShowSuccess("Datos ingresados con éxito", options);
                        
                    }
                    else
                    {
                        notifier.ShowWarning("Los datos no se ingresaron", options);
                        
                    }
                }
            }
            catch (Exception)
            {
                notifier.ShowError("Error", options);
            }
            
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControlColaboradores colLista = new UserControlColaboradores();

                int idComuna = ((ComboboxItemLlenado)cboComuna.SelectedItem).Id;
                int idUsu = ((ComboboxItemLlenado)cboUsu.SelectedItem).Id;
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (txtRut.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtSNombre.Text.Trim() == "" ||
                    txtPaterno.Text.Trim() == "" || txtMaterno.Text.Trim() == "" || txtDireccion.Text.Trim() == "" ||
                    txtFono.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtUsuario.Text.Trim() == "" ||
                    txtContra.Text.Trim() == "" || idUsu == 0 || idComuna == 0)
                {
                    notifier.ShowWarning("Debe ingresar todos los campos", options);
                }
                else
                {
                    cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = txtRut.Text.Trim();
                    cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = txtNombre.Text.Trim();
                    cmd.Parameters.Add("SNOMBRE", OracleDbType.Varchar2).Value = txtSNombre.Text.Trim();
                    cmd.Parameters.Add("APATERNO", OracleDbType.Varchar2).Value = txtPaterno.Text.Trim();
                    cmd.Parameters.Add("AMATERNO", OracleDbType.Varchar2).Value = txtMaterno.Text.Trim();
                    cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2).Value = txtDireccion.Text.Trim();
                    cmd.Parameters.Add("FONO", OracleDbType.Int32).Value = txtFono.Text.Trim();
                    cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("LOGIN", OracleDbType.Varchar2).Value = txtUsuario.Text.Trim();
                    cmd.Parameters.Add("LPASSWORD", OracleDbType.Varchar2).Value = txtContra.Text.Trim();
                    cmd.Parameters.Add("TIPO", OracleDbType.Int32).Value = idUsu;
                    cmd.Parameters.Add("COMUNA", OracleDbType.Int32).Value = idComuna;

                    int correct = cmd.ExecuteNonQuery();
                    if (correct == 0)
                    {
                        notifier.ShowWarning("Los datos no se actualizaron", options);
                    }
                    else
                    {
                        colLista.dataGrid.Items.Refresh();
                        notifier.ShowSuccess("Datos actualizados con éxito", options);
                    }
                }
            }
            catch (Exception)
            {
                notifier.ShowError("Error", options);
            }
        }

       
    }
}
