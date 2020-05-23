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
    /// Interaction logic for AgregarClienteWpf.xaml
    /// </summary>
    public partial class AgregarClienteWpf : Window
    {
        public AgregarClienteWpf()
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

        private void btn_cancelar_cliente_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_cliente_CLick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ClienteDAO daocli = new ClienteDAO();
                var id_comuna = 0;

                if (Cbo_comuna_Cliente.SelectedIndex != -1 && txt_apellidos_cliente.Text != "" && txt_email_cliente.Text != "" && txt_fono_cliente.Text != ""
                    && txt_nombres_cliente.Text != "" && txt_rut_cliente.Text != "")
                {
                    Cliente cli = new Cliente();
                    id_comuna = ((ComboboxItemLlenado)Cbo_comuna_Cliente.SelectedItem).Id;
                    if (txt_direccion_cliente.Text != "")
                    {
                        cli.Direccioncli = txt_direccion_cliente.Text.Trim(); ;
                    }
                    else
                    {
                        cli.Direccioncli = "NO HAY REGISTRO";

                    }

                    cli.Apellidos = txt_apellidos_cliente.Text.Trim();
                    cli.Email_cli = txt_email_cliente.Text.Trim();
                    cli.Fono_cliente = Convert.ToInt32(txt_fono_cliente.Text);
                    cli.Idcomuna_cli = id_comuna;
                    cli.Nombres = txt_nombres_cliente.Text.Trim();
                    cli.Rut = txt_modificar_cliente.Text.Trim();

                    daocli.modificarCliente(txt_modificar_cliente.Text, cli);
                    notifier.ShowSuccess("Se a modificado el Cliente", options);
                    this.Close();





                }
                else
                {
                    notifier.ShowWarning("Debe ingresar Todos los campos, el unico que puede ser vacio es la direccion ", options);

                }




            }
            catch (Exception)
            {


                notifier.ShowWarning("Debes Ingresar los datos como corresponden, (telefono es de tipo numerico) y los demas caracteres(letras) ", options);
            }
        }

        private void btn_agregar_cliente_Cliente(object sender, RoutedEventArgs e)
        {
            try
            {
                ClienteDAO daocli = new ClienteDAO();
                
                var id_comuna = 0;

                if (Cbo_comuna_Cliente.SelectedIndex != -1 && txt_apellidos_cliente.Text != ""  && txt_email_cliente.Text != "" && txt_fono_cliente.Text != ""
                    && txt_nombres_cliente.Text != "" && txt_rut_cliente.Text != "" )
                {
                    Cliente cli = new Cliente();
                    id_comuna = ((ComboboxItemLlenado)Cbo_comuna_Cliente.SelectedItem).Id;
                    if (txt_direccion_cliente.Text != "")
                    {
                        cli.Direccioncli = txt_direccion_cliente.Text.Trim(); ;
                    }
                    else
                    {
                        cli.Direccioncli = "NO HAY REGISTRO";
                        
                    }

                    cli.Apellidos = txt_apellidos_cliente.Text.Trim();
                    cli.Email_cli = txt_email_cliente.Text.Trim();
                    cli.Fono_cliente = Convert.ToInt32(txt_fono_cliente.Text);
                    cli.Idcomuna_cli = id_comuna;
                    cli.Nombres = txt_nombres_cliente.Text.Trim();
                    cli.Rut = txt_rut_cliente.Text.Trim();



                    if (daocli.ExisteCliente(txt_rut_cliente.Text.Trim()) == true)
                    {
                        notifier.ShowInformation("El Cliente ya existe", options);
                    }
                    else
                    {
                        daocli.insertarCliente(cli);
                        notifier.ShowSuccess("Se a guardado el Cliente", options);
                        this.Close();
                    }



                }
                else
                {
                    notifier.ShowWarning("Debe ingresar Todos los campos, el unico que puede ser vacio es la direccion ", options);

                }

            }
            catch (Exception)
            {

                notifier.ShowWarning("Debes Ingresar los datos como corresponden, (telefono es de tipo numerico) y los demas caracteres(letras) ", options);
            }
        }
    

        private void Cbo_comuna_Cliente_loaded(object sender, RoutedEventArgs e)
        {

            ComunaDAO com = new ComunaDAO();
            var listacombo = com.carga_ComboComuna();
            foreach (var item in listacombo)
            {
                ComboboxItemLlenado m = new ComboboxItemLlenado();
                m.Id = item.id;
                m.Texto = item.nombre;
                Cbo_comuna_Cliente.Items.Add(m);
            }
        }
    }
}
