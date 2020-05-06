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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Siempre
using CapaDatosAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;

using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Core;

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for UserControlColaboradores.xaml
    /// </summary>
    public partial class UserControlColaboradores : UserControl
    {
        OracleConnection conn = null;
        public UserControlColaboradores()
        {
            Conexion();
            InitializeComponent();

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
        public void Cargatabla()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("FN_USUARIOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Usuario> lista = new List<Usuario>();
                OracleParameter output = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                
                while (reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Rut = reader.GetString(0);
                    usu.Nombre = reader.GetString(1);
                    usu.Snombre = reader.GetString(2);
                    usu.Apellido = reader.GetString(3);
                    usu.Apematerno = reader.GetString(4);
                    usu.Direccion = reader.GetString(5);
                    usu.Fono = reader.GetInt32(6);
                    usu.Email = reader.GetString(7);
                    usu.Nomusuario = reader.GetString(8);
                    usu.Password = reader.GetString(9);
                    usu.TipoUsu = reader.GetString(10);
                    usu.Comuna = reader.GetString(11);

                    lista.Add(usu);
                }
                dataGrid.ItemsSource = lista;
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AgregarColaboradorWpf cola = new AgregarColaboradorWpf();
            cola.btnModificar.Visibility = Visibility.Collapsed;
            cola.Show();

        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Cargatabla();
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectUser = dataGrid.SelectedItem;

            AgregarColaboradorWpf cola = new AgregarColaboradorWpf();
            //Aqui se puede mandar datos de la data grid a la ventana 
            cola.btnAgregarUsu.Visibility = Visibility.Collapsed;
            string Rut = (dataGrid.SelectedCells[0].Column.GetCellContent(selectUser) as TextBlock).Text;
            string nombre = (dataGrid.SelectedCells[1].Column.GetCellContent(selectUser) as TextBlock).Text;
            string snombre = (dataGrid.SelectedCells[2].Column.GetCellContent(selectUser) as TextBlock).Text;
            string apaterno = (dataGrid.SelectedCells[3].Column.GetCellContent(selectUser) as TextBlock).Text;
            string amaterno = (dataGrid.SelectedCells[4].Column.GetCellContent(selectUser) as TextBlock).Text;
            string direccion = (dataGrid.SelectedCells[5].Column.GetCellContent(selectUser) as TextBlock).Text;
            string fono = (dataGrid.SelectedCells[6].Column.GetCellContent(selectUser) as TextBlock).Text;
            string email = (dataGrid.SelectedCells[7].Column.GetCellContent(selectUser) as TextBlock).Text;
            string login = (dataGrid.SelectedCells[8].Column.GetCellContent(selectUser) as TextBlock).Text;
            string lpass = (dataGrid.SelectedCells[9].Column.GetCellContent(selectUser) as TextBlock).Text;
            string tipo = (dataGrid.SelectedCells[10].Column.GetCellContent(selectUser) as TextBlock).Text;
            string comuna = (dataGrid.SelectedCells[11].Column.GetCellContent(selectUser) as TextBlock).Text;

            cola.txtRut.Text = Rut;
            cola.txtNombre.Text = nombre;
            cola.txtSNombre.Text = snombre;
            cola.txtPaterno.Text = apaterno;
            cola.txtMaterno.Text = amaterno;
            cola.txtDireccion.Text = direccion;
            cola.txtFono.Text = fono;
            cola.txtEmail.Text = email;
            cola.txtUsuario.Text = login;
            cola.txtContra.Text = lpass;
           
            cola.Show();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtEliminar.Text != "")
                {
                    var Result = MessageBox.Show("Está seguro(a) de eliminar este usuario?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (Result == MessageBoxResult.Yes)
                    {
                        OracleCommand cmd = new OracleCommand("SP_ELIMINAR_USUARIO", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = txtEliminar.Text.Trim();
                        int correct = cmd.ExecuteNonQuery();
                        if (correct == 0)
                        {
                            notifier.ShowWarning("No se pudo eliminar el usuario", options);
                        }
                        else
                        {
                            Cargatabla();
                            notifier.ShowSuccess("Eliminado con exito", options);
                        }
                    }
                    else if (Result == MessageBoxResult.No)
                    {
                        notifier.ShowInformation("Eliminación cancelada", options);
                    }
                }
                else
                {
                    notifier.ShowInformation("Debe llenar el campo de texto", options);
                }
                
                

            }
            catch (Exception ex)
            {
                notifier.ShowError("Error");
            }
        }
    }
}