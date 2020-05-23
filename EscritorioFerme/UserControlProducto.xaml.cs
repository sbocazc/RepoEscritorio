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
    /// Interaction logic for UserControlProducto.xaml
    /// </summary>
    public partial class UserControlProducto : UserControl
    {
        public UserControlProducto()
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


        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void CargaTabla_Producto()
        {
            try
            {
                ProductosDAO pro = new ProductosDAO();
                var listapro = pro.listarProductos();
                dataGrid_Productos.ItemsSource = listapro;

            }
            catch (Exception e)
            {
                
                notifier.ShowError("Error al cargar la tabla, es posible que no hayan datos en la base de datos");
            }
        }


       

        private void dataGrid_Productos_loaded(object sender, RoutedEventArgs e)
        {
            CargaTabla_Producto();
           
        }

        private void Click_Agregar_Producto(object sender, RoutedEventArgs e)
        {
            AgregarProductosWpf produ = new AgregarProductosWpf();
            produ.Show();
        }

        private void dataGrid_Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Modificar_Producto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object selected = dataGrid_Productos.SelectedItem;

                string id = (dataGrid_Productos.SelectedCells[0].Column.GetCellContent(selected) as TextBlock).Text;
                string nombre = (dataGrid_Productos.SelectedCells[1].Column.GetCellContent(selected) as TextBlock).Text;
                //var fecha = (dataGrid_Productos.SelectedCells[1].Column.GetCellContent(selected) as DatePicker).SelectedDate;
                //string fecha = Convert.ToDateTime(dataGrid_Productos.SelectedCells[2].Column.GetCellContent(selected) as DatePickerFormat).ToString();
                //string fecha = (dataGrid_Productos.SelectedCells[2].Column.GetCellContent(selected) as DatePicker).ToString();
                string precio = (dataGrid_Productos.SelectedCells[3].Column.GetCellContent(selected) as TextBlock).Text;
                string stock = (dataGrid_Productos.SelectedCells[4].Column.GetCellContent(selected) as TextBlock).Text;
                string stock_cri = (dataGrid_Productos.SelectedCells[5].Column.GetCellContent(selected) as TextBlock).Text;

                string prove = (dataGrid_Productos.SelectedCells[6].Column.GetCellContent(selected) as TextBlock).Text;



                //string tipo = (dataGrid_Productos.SelectedCells[7].Column.GetCellContent(selected) as TextBlock).ToString();




                AgregarProductosWpf mp = new AgregarProductosWpf();
                mp.Txt_idamodificar_Producto.Text = id;
                mp.Txt_Nombre_Producto.Text = nombre;
                //mp.dt_Vencimiento_Producto = fecha.ToString("dd-MM-yyyy");
                mp.Txt_Precio_Producto.Text = precio;
                mp.Txt_Stock_Producto.Text = stock;
                mp.Txt_StockCri_Producto.Text = stock_cri;
                //mp.Cbo_Proveedor_Producto.SelectedItem = prove;
                //mp.Cbo_TipoClase_Producto.SelectedItem = tipo;

                mp.Show();

            }
            catch (Exception)
            {

                notifier.ShowWarning("Debe seleccionar el producto para  modificar");
            }
            
        }


       

        private void Txt_Buscar_Producto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void Buscar_id_producto(object sender, KeyEventArgs e)
        {
            try
            {
                if (Txt_Buscar_Producto.Text != "")
                {
                    ProductosDAO pro = new ProductosDAO();
                    var listapro = pro.buscaridProducto(Txt_Buscar_Producto.Text);
                    dataGrid_Productos.ItemsSource = listapro;
                }
                else
                {
                    notifier.ShowInformation("Debes ingresar una id para buscar");
                    CargaTabla_Producto();
                }
                
            }
            catch (Exception )
            {

                notifier.ShowError("Debes solo debes ingresar numeros para  buscar");
                CargaTabla_Producto();
            }
            
        }

        private void txt_buscarnomb_producto_keyup(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_buscarnomb_producto.Text != "")
                {
                    ProductosDAO pro = new ProductosDAO();
                    var listapro = pro.buscarnombProducto(txt_buscarnomb_producto.Text);
                    dataGrid_Productos.ItemsSource = listapro;
                 

                    
                }
                else
                {
                    notifier.ShowInformation("Debes ingresar un nombre de producto para buscar");
                    CargaTabla_Producto();
                }

            }
            catch (Exception)
            {

                notifier.ShowError("Solo debes ingresar caracteres");
                CargaTabla_Producto();
            }

        }
    }
    
}
