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
        UserControlColaboradores colLista = new UserControlColaboradores();
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
                
               
                int idComuna = ((ComboboxItemLlenado)cboComuna.SelectedItem).Id;
                int idUsu = ((ComboboxItemLlenado)cboUsu.SelectedItem).Id;
                if (txtRut.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtSNombre.Text.Trim() == "" ||
                    txtPaterno.Text.Trim() == "" || txtMaterno.Text.Trim() == "" || txtDireccion.Text.Trim() == "" ||
                    txtFono.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtUsuario.Text.Trim() == "" ||
                    txtContra.Text.Trim() == "" || idUsu == 0 || idComuna == 0)
                {
                    notifier.ShowWarning("Debe ingresar todos los campos", options);
                }
                else
                {
                    
                    
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

                int idComuna = ((ComboboxItemLlenado)cboComuna.SelectedItem).Id;
                int idUsu = ((ComboboxItemLlenado)cboUsu.SelectedItem).Id;
                
                if (txtRut.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtSNombre.Text.Trim() == "" ||
                    txtPaterno.Text.Trim() == "" || txtMaterno.Text.Trim() == "" || txtDireccion.Text.Trim() == "" ||
                    txtFono.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtUsuario.Text.Trim() == "" ||
                    txtContra.Text.Trim() == "" || idUsu == 0 || idComuna == 0)
                {
                    notifier.ShowWarning("Debe ingresar todos los campos", options);
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {
                notifier.ShowError("Error", options);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            colLista.Cargatabla();
        }
    }
}
