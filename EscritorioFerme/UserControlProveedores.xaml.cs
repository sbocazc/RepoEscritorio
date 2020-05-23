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

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;

using Controller;
using CapaDatosAccess;
using System.Data.SqlClient;

using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Messages.Core;
using ToastNotifications.Core;

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for UserControlProveedores.xaml
    /// </summary>
    public partial class UserControlProveedores : UserControl
    {
        public UserControlProveedores()
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

        

        private void dataGrid_Proveedor_loaded(object sender, RoutedEventArgs e)
        {
            CargaTabla_Proveedor();
        }
        private void dataGrid_Proveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CargaTabla_Proveedor()
        {
            try
            {
                ProveedorDAO prove = new ProveedorDAO();
                var listaproveedor = prove.listarProvedores();
                dataGrid_Proveedor.ItemsSource = listaproveedor;
            }
            catch (Exception e)
            {

                notifier.ShowError("Error al cargar la tabla, es posible que no hayan datos en la base de datos");
            }
        }

        private void Btn_agregar_proveedor_Click(object sender, RoutedEventArgs e)
        {
            AgregarProveedoresWpf prove = new AgregarProveedoresWpf();
            prove.Show();
        }

       

        private void Modificar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object selected = dataGrid_Proveedor.SelectedItem;

                string id = (dataGrid_Proveedor.SelectedCells[0].Column.GetCellContent(selected) as TextBlock).Text;
                string nombre = (dataGrid_Proveedor.SelectedCells[1].Column.GetCellContent(selected) as TextBlock).Text;
                string fono = (dataGrid_Proveedor.SelectedCells[2].Column.GetCellContent(selected) as TextBlock).Text;
                string rubro = (dataGrid_Proveedor.SelectedCells[3].Column.GetCellContent(selected) as TextBlock).Text;
                string modi = (dataGrid_Proveedor.SelectedCells[0].Column.GetCellContent(selected) as TextBlock).Text;

                AgregarProveedoresWpf mpr = new AgregarProveedoresWpf();
                mpr.txt_numero_proveedor.Text = id;
                mpr.txt_nombre_proveedor.Text = nombre;
                mpr.txt_fono_proveedor.Text = fono;
                mpr.txt_rubro_proveedor.Text = rubro;
                mpr.txt_modificar_Proveedor.Text = modi;

                mpr.Show();

            }
            catch (Exception)
            {

                notifier.ShowWarning("Debe seleccionar el producto para  modificar");
            }

        }

        private void txt_buscarrubro_proveedor_keyup(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_buscarrubro_proveedor.Text != "")
                {
                    ProveedorDAO prove = new ProveedorDAO();
                    var listaprove = prove.buscarRubProveedor(txt_buscarrubro_proveedor.Text);
                    dataGrid_Proveedor.ItemsSource = listaprove;



                }
                else
                {
                    notifier.ShowInformation("Debes ingresar un rubro de proveedor para buscar");
                    CargaTabla_Proveedor();
                }

            }
            catch (Exception)
            {

                notifier.ShowError("Solo debes ingresar caracteres");
                CargaTabla_Proveedor();
            }
        }

        private void txt_buscarnom_proveedor_keyup(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_buscarnom_proveedor.Text != "")
                {
                    ProveedorDAO prove = new ProveedorDAO();
                    var listaprove = prove.buscarnombProveedor(txt_buscarnom_proveedor.Text);
                    dataGrid_Proveedor.ItemsSource = listaprove;



                }
                else
                {
                    notifier.ShowInformation("Debes ingresar un nombre de proveedor para buscar");
                    CargaTabla_Proveedor();
                }

            }
            catch (Exception)
            {

                notifier.ShowError("Solo debes ingresar caracteres");
                CargaTabla_Proveedor();
            }
        }
    }
}

