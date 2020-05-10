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
        UserControlColaboradores colLista = new UserControlColaboradores();
        OracleConnection conn = null;
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
