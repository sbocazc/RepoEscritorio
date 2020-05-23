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
    /// Interaction logic for AgregarProductosWpf.xaml
    /// </summary>
    public partial class AgregarProductosWpf : Window
    {
        public AgregarProductosWpf()
        {
            InitializeComponent();
            cargaCombo();
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

        private void Cbo_Proveedor_ProductoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cbo_Proveedor_Producto_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorDAO pro = new ProveedorDAO();
            var listacombo = pro.cargaComboProve();
            foreach (var item in listacombo)
            {
                ComboboxItemLlenado m = new ComboboxItemLlenado();
                m.Id = item.id;
                m.Texto = item.nombre;
                Cbo_Proveedor_Producto.Items.Add(m);
            }

        }
        private void cargaCombo()
        {
            ClaseDAO c = new ClaseDAO();
            var listarcomboc = c.cargaComboClase();
            foreach (var item in listarcomboc)
            {
                ComboboxItemLlenado ct = new ComboboxItemLlenado();
                ct.Id = item.id;
                ct.Texto = item.nombre;
                Cbo_Clase_Producto.Items.Add(ct);
            }
        }

        private void Cbo_TipoClase_Producto_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Cbo_Clase_Producto_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void Btn_Agregar_Producto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductosDAO dao = new ProductosDAO();
                string _idproducto = "";
                var id_prove = 0;
                var id_clase = 0;
                var id_tipo = 0;
                if (Cbo_Clase_Producto.SelectedIndex != -1 && Cbo_Proveedor_Producto.SelectedIndex != -1 && Cbo_TipoClase_Producto.SelectedIndex != -1 &&
                    Txt_Nombre_Producto.Text != "" && Txt_Precio_Producto.Text != "" && Txt_StockCri_Producto.Text != "" && Txt_Stock_Producto.Text != "")
                {
                    Producto pro = new Producto();
                    id_prove = ((ComboboxItemLlenado)Cbo_Proveedor_Producto.SelectedItem).Id;
                    id_clase = ((ComboboxItemLlenado)Cbo_Clase_Producto.SelectedItem).Id;
                    id_tipo = ((ComboboxItemLlenado)Cbo_TipoClase_Producto.SelectedItem).Id;
                    if (dt_Vencimiento_Producto.SelectedDate.ToString() == "")
                    {

                        var cero = "00-00-0000 0:00:00";
                        var nul = (cero.Split('-'));
                        var n = (nul[0] + nul[1] + nul[2]);
                        n.Remove(8, 8);
                        string x = n.Remove(8, 8);



                        _idproducto = (id_prove.ToString() + id_clase.ToString() + x.ToString() + id_tipo.ToString());

                        pro.Idproducto = _idproducto;
                    }
                    else
                    {
                        
                        var fec = dt_Vencimiento_Producto.SelectedDate.ToString();
                        
                        var spli = (fec.Split('-'));
                        var dias = (spli[0] + spli[1] + spli[2]);
                        dias.Remove(8, 8);
                        string z = dias.Remove(8, 8);

                        var fecha = Int32.Parse(z);
                        _idproducto = (id_prove.ToString() + id_clase.ToString() + fecha.ToString() + id_tipo.ToString());
                        pro.Idproducto = _idproducto;
                        pro.Fecha_vencproducto = dt_Vencimiento_Producto.SelectedDate.ToString().Remove(10, 8).Replace("-", "/");

                    }
                    
                    pro.Nombproducto = Txt_Nombre_Producto.Text;
                    pro.Preciounitario = Convert.ToInt32(Txt_Precio_Producto.Text);
                    pro.Stock_producto = Convert.ToInt32(Txt_Stock_Producto.Text);
                    pro.Stock_critico = Convert.ToInt32(Txt_StockCri_Producto.Text);
                    pro.Idproveedor = id_prove;
                    pro.Idclase = id_tipo;



                    if (dao.ExisteProdu(_idproducto) == true)
                    {
                        notifier.ShowInformation("El producto ya existe", options);
                    }
                    else
                    {
                        dao.insertar(pro);
                        notifier.ShowSuccess("Se a guardado el producto", options);
                        this.Close();
                    }



                }
                else 
                {
                    notifier.ShowWarning("Debe ingresar Todos los campos, el unico que puede ser vacio es la fecha de vencimiento ", options);
                    
                }
                


            
            }
            catch (Exception)
            {

                notifier.ShowWarning("Debes Ingresar los datos como corresponden, (stock,stock critico y precio son de tipo numericos) y el nombre puede contener letras y numeros ", options);
            }
        }
            

        private void Cbo_Clase_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cbo_TipoClase_Producto.Items.Clear();
            TipoClaseDAO tc = new TipoClaseDAO();
            var id_clase = ((ComboboxItemLlenado)Cbo_Clase_Producto.SelectedItem).Id;
            var listarcombo = tc.cargaComboTipoClase(id_clase);
            foreach (var item in listarcombo)
            {
                ComboboxItemLlenado t = new ComboboxItemLlenado();
                t.Id = item.id;
                t.Texto = item.nombre;
                Cbo_TipoClase_Producto.Items.Add(t);
            }
        }

        private void Btn_Modificar_Producto_click(object sender, RoutedEventArgs e)
        {


            try
            {
                ProductosDAO dao = new ProductosDAO();
                string _idproducto = "";
                var id_prove = 0;
                var id_clase = 0;
                var id_tipo = 0;
                if (Cbo_Clase_Producto.SelectedIndex != -1 && Cbo_Proveedor_Producto.SelectedIndex != -1 && Cbo_TipoClase_Producto.SelectedIndex != -1 &&
                    Txt_Nombre_Producto.Text != "" && Txt_Precio_Producto.Text != "" && Txt_StockCri_Producto.Text != "" && Txt_Stock_Producto.Text != "")
                {
                    Producto pro = new Producto();
                    id_prove = ((ComboboxItemLlenado)Cbo_Proveedor_Producto.SelectedItem).Id;
                    id_clase = ((ComboboxItemLlenado)Cbo_Clase_Producto.SelectedItem).Id;
                    id_tipo = ((ComboboxItemLlenado)Cbo_TipoClase_Producto.SelectedItem).Id;
                    if (dt_Vencimiento_Producto.SelectedDate.ToString() == "")
                    {

                        var cero = "00-00-0000 0:00:00";
                        var nul = (cero.Split('-'));
                        var n = (nul[0] + nul[1] + nul[2]);
                        n.Remove(8, 8);
                        string x = n.Remove(8, 8);



                        _idproducto = (id_prove.ToString() + id_clase.ToString() + x.ToString() + id_tipo.ToString());

                        pro.Idproducto = _idproducto;
                    }
                    else
                    {
                        
                        var fec = dt_Vencimiento_Producto.SelectedDate.ToString();
                        
                        var spli = (fec.Split('-'));
                        var dias = (spli[0] + spli[1] + spli[2]);
                        dias.Remove(8, 8);
                        string z = dias.Remove(8, 8);

                        var fecha = Int32.Parse(z);
                        _idproducto = (id_prove.ToString() + id_clase.ToString() + fecha.ToString() + id_tipo.ToString());
                        pro.Idproducto = _idproducto;
                        pro.Fecha_vencproducto = dt_Vencimiento_Producto.SelectedDate.ToString().Remove(10, 8).Replace("-", "/");

                    }
                    
                    pro.Nombproducto = Txt_Nombre_Producto.Text;
                    pro.Preciounitario = Convert.ToInt32(Txt_Precio_Producto.Text);
                    pro.Stock_producto = Convert.ToInt32(Txt_Stock_Producto.Text);
                    pro.Stock_critico = Convert.ToInt32(Txt_StockCri_Producto.Text);
                    pro.Idproveedor = id_prove;
                    pro.Idclase = id_tipo;



                    if (dao.ExisteProdu(_idproducto) == true)
                    {
                        notifier.ShowWarning("El producto ya existe", options);
                    }
                    else
                    {
                        dao.modificar_producto(Txt_idamodificar_Producto.Text,pro);
                        notifier.ShowSuccess("Se a modificado con exito",options);
                        this.Close();
                    }



                }
                else
                {
                    notifier.ShowWarning("Debe ingresar Todos los campos, el unico que puede ser vacio es la fecha de vencimiento ", options);

                }




            }
            catch (Exception)
            {

                throw;
            }
        }
    

        private void Btn_Cancelar_Producto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
