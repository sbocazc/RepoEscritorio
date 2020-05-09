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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Controller;
using CapaDatosAccess;
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
                ColaboradoresDAO col = new ColaboradoresDAO();
                var lista = col.listarUsuarios();
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

        

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        AgregarColaboradorWpf cola = new AgregarColaboradorWpf();

            object selectUser = dataGrid.SelectedItem;
            Usuario usu = (Usuario)dataGrid.SelectedItem;
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

        private void dataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            int columnsCount = dataGrid.Columns.Count;
            dataGrid.Columns[12].Visibility = Visibility.Hidden;
            dataGrid.Columns[13].Visibility = Visibility.Hidden;
        }
    }
}