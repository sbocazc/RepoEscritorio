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

using Controller;


using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Messages.Core;
using ToastNotifications.Core;
using CapaDatosAccess;

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for UserControlClientes.xaml
    /// </summary>
    public partial class UserControlClientes : UserControl
    {
        public UserControlClientes()
        {
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


        

        private void dataGrid_Cliente_loaded(object sender, RoutedEventArgs e)
        {
            CargaTabla_Cliente();
        }

        private void CargaTabla_Cliente()
        {
            try
            {
                ClienteDAO cli = new ClienteDAO();
                var listarclientes = cli.listarClientes();
                dataGrid_Cliente.ItemsSource = listarclientes;
            }
            catch (Exception e)
            {

                notifier.ShowError("Error al cargar la tabla, es posible que no hayan datos en la base de datos");
            }
        }

        private void Btn_agregar_Cliente_click(object sender, RoutedEventArgs e)
        {
            AgregarClienteWpf ac = new AgregarClienteWpf();
            ac.Show();
        }

        private void Modificar_Cliente_click(object sender, RoutedEventArgs e)
        {
            try
            {
                object selected = dataGrid_Cliente.SelectedItem;
                string rut = (dataGrid_Cliente.SelectedCells[0].Column.GetCellContent(selected) as TextBlock).Text;
                string nombre = (dataGrid_Cliente.SelectedCells[1].Column.GetCellContent(selected) as TextBlock).Text;
                string apellidos = (dataGrid_Cliente.SelectedCells[2].Column.GetCellContent(selected) as TextBlock).Text;
                string direccion = (dataGrid_Cliente.SelectedCells[3].Column.GetCellContent(selected) as TextBlock).Text;
                string fono = (dataGrid_Cliente.SelectedCells[4].Column.GetCellContent(selected) as TextBlock).Text;
                string email = (dataGrid_Cliente.SelectedCells[5].Column.GetCellContent(selected) as TextBlock).Text;
               //string comuna = (dataGrid_Cliente.SelectedCells[6].Column.GetCellContent(selected) as TextBox).Text;
                string modi = (dataGrid_Cliente.SelectedCells[0].Column.GetCellContent(selected) as TextBlock).Text;

                AgregarClienteWpf ac = new AgregarClienteWpf();
                ac.txt_rut_cliente.Text = rut;
                ac.txt_nombres_cliente.Text = nombre;
                ac.txt_apellidos_cliente.Text = apellidos;
                ac.txt_direccion_cliente.Text = direccion;
                ac.txt_fono_cliente.Text = fono;
                ac.txt_email_cliente.Text = email;
                //ac.Cbo_comuna_Cliente. = comuna;


                ac.txt_modificar_cliente.Text = modi;

                ac.Show();

            }
            catch (Exception)
            {

                notifier.ShowWarning("Debe seleccionar el cliente para  modificar");
            }
        }

        private void dataGrid_Cliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_buscarrut_cliente_keyup(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_buscarrut_cliente.Text != "")
                {
                    ClienteDAO cli = new ClienteDAO();
                    var listacli = cli.buscarRutCLiente(txt_buscarrut_cliente.Text);
                    dataGrid_Cliente.ItemsSource = listacli;



                }
                else
                {
                    notifier.ShowInformation("Debes ingresar un rut de cliente para buscar");
                    CargaTabla_Cliente();
                }

            }
            catch (Exception)
            {

                notifier.ShowError("Solo debes ingresar caracteres");
                CargaTabla_Cliente();
            }
        }
    }
}
