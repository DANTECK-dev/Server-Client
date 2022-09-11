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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Server server;
        public MainWindow()
        {
            InitializeComponent();
            server = new Server();
            server.Visibility = Visibility.Visible;
        }

        private void Sender_Click(object sender, RoutedEventArgs e)
        {
            server.Read();
            OutputText.Content = server.InputText.Content.ToString();
            OutputText.Content += "\nDone";
        }
    }
}
