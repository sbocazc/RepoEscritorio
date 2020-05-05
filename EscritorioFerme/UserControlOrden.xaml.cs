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

namespace EscritorioFerme
{
    /// <summary>
    /// Interaction logic for UserControlOrden.xaml
    /// </summary>
    public partial class UserControlOrden : UserControl
    {
        public UserControlOrden()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OrdenCompraWpf orden = new OrdenCompraWpf();
            orden.Show();
        }
    }
}
