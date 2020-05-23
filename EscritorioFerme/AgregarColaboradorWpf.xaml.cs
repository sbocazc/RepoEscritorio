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
using Controller;
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
        public AgregarColaboradorWpf()
        {
            InitializeComponent();
        }
        //Mensajes
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
        //---------------------------------------------------------------------
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
                if (txtRut.Text != "")
                {
                    Colaborador cola = new Colaborador();
                    cola.Rut_cola = txtRut.Text.Trim();
                    cola.Activo = 1;
                    ColaboradoresDAO dao = new ColaboradoresDAO();
                    dao.insertar(cola);
                  
                    notifier.ShowSuccess("Permiso registrado con éxito", options);
                    CargaTabla();
                }
                else
                {
                    notifier.ShowInformation("Debe ingresar un rut", options);
                }
            }
            catch (Exception)
            {
                notifier.ShowError("Error", options);
            }
            
        }
        private void CargaTabla()
        {
            ColaboradoresDAO cola = new ColaboradoresDAO();
            var lista = cola.listarUsuarios();
            dtg_Colaboradores.ItemsSource = lista;
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void dtg_Colaboradores_Loaded(object sender, RoutedEventArgs e)
        {
            CargaTabla();
        }
        private void dtg_Colaboradores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object selectUser = dtg_Colaboradores.SelectedItem;
                string Rut = (dtg_Colaboradores.SelectedCells[0].Column.GetCellContent(selectUser) as TextBlock).Text;
                string nombre = (dtg_Colaboradores.SelectedCells[1].Column.GetCellContent(selectUser) as TextBlock).Text;
                string Apellido = (dtg_Colaboradores.SelectedCells[2].Column.GetCellContent(selectUser) as TextBlock).Text;
                string Desc = (dtg_Colaboradores.SelectedCells[3].Column.GetCellContent(selectUser) as TextBlock).Text;
                string login = (dtg_Colaboradores.SelectedCells[4].Column.GetCellContent(selectUser) as TextBlock).Text;
                string pass = (dtg_Colaboradores.SelectedCells[5].Column.GetCellContent(selectUser) as TextBlock).Text;
                string activo = (dtg_Colaboradores.SelectedCells[6].Column.GetCellContent(selectUser) as TextBlock).Text;
                if (Rut != "" || nombre != "" || Apellido != "" || Desc != "" || login != "" || pass != "" || activo != "")
                {
                    if (Rut != "")
                    {
                        var Result = MessageBox.Show("Está seguro(a) de eliminar el permiso de este usuario?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (Result == MessageBoxResult.Yes)
                        {
                            Colaborador cola = new Colaborador();
                            cola.Rut_cola = Rut;
                            ColaboradoresDAO dao = new ColaboradoresDAO();
                            if (dao.eliminar(cola) == true)
                            {
                                CargaTabla();
                            }
                            else
                            {
                                notifier.ShowWarning("No se pudo eliminar el permiso", options);
                            }
                        }
                        else if (Result == MessageBoxResult.No)
                        {
                            notifier.ShowInformation("Eliminación cancelada", options);
                        }
                    }
                    else
                    {
                        notifier.ShowInformation("La selección fue érronea", options);
                    }
                }
                else
                {
                    notifier.ShowInformation("Debe seleccionar una fila correcta", options);
                }
                
            }
            catch (Exception ex)
            {
                notifier.ShowSuccess("Permiso eliminado con éxito", options);
            }
        }
    }
}
