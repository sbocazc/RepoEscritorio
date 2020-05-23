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

using Controller;
using CapaDatosAccess;

using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Messages.Core;
using ToastNotifications.Core;

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for AgregarProveedoresWpf.xaml
    /// </summary>
    public partial class AgregarProveedoresWpf : Window
    {
        public AgregarProveedoresWpf()
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





        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_cancelar_proveedor_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_proveedor_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProveedorDAO prove = new ProveedorDAO();

                if (txt_fono_proveedor.Text != "" && txt_nombre_proveedor.Text != "" && txt_numero_proveedor.Text != "" && txt_rubro_proveedor.Text != "")
                {
                    Proveedor provee = new Proveedor();
                    provee.Nombproveedor = txt_nombre_proveedor.Text;
                    provee.Id_proveedor = Convert.ToInt32(txt_modificar_Proveedor.Text);
                    provee.Fonoproveedor = Convert.ToInt32(txt_fono_proveedor.Text);
                    provee.Rubroproveedor = txt_rubro_proveedor.Text;




                   
                    prove.modificar_proveedor(Convert.ToInt32(txt_modificar_Proveedor.Text),provee);
                    notifier.ShowSuccess("Se a modificado el proveedor", options);
                    this.Close();

                   



                }
                else
                {
                    notifier.ShowWarning("Debe ingresar todos los campos, son obligatorios", options);

                }




            }
            catch (Exception)
            {

                notifier.ShowWarning("Debes Ingresar los datos como corresponden, numero de proveedor y fono son de tipo numericos, el nombre y rubro pueden contener letras y numeros ", options);
            }
        }

        private void btn_agregar_proveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProveedorDAO prove = new ProveedorDAO();
               
                if (txt_fono_proveedor.Text != "" && txt_nombre_proveedor.Text != "" && txt_numero_proveedor.Text != "" && txt_rubro_proveedor.Text != "")
                {
                    Proveedor provee = new Proveedor();
                    provee.Nombproveedor = txt_nombre_proveedor.Text;
                    provee.Id_proveedor = Convert.ToInt32(txt_numero_proveedor.Text);
                    provee.Fonoproveedor = Convert.ToInt32(txt_fono_proveedor.Text);
                    provee.Rubroproveedor = txt_rubro_proveedor.Text;
                    



                    if (prove.ExisteProveedor(provee.Id_proveedor) == true)
                    {
                        notifier.ShowInformation("El proveedor ya existe", options);
                    }
                    else
                    {
                        prove.insertar_proveedor(provee);
                        notifier.ShowSuccess("Se a guardado el proveedor", options);
                        
                        this.Close();
                        
                    }



                }
                else
                {
                    notifier.ShowWarning("Debe ingresar todos los campos, son obligatorios", options);

                }




            }
            catch (Exception)
            {

                notifier.ShowWarning("Debes Ingresar los datos como corresponden, numero de proveedor y fono son de tipo numericos, el nombre y rubro pueden contener letras y numeros ", options);
            }
        }

    }
}

