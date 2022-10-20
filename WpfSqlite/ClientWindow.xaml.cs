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

namespace WpfSqlite
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public Client Client { get; private set; }
        public ClientWindow(Client client)
        {
            InitializeComponent();
            Client = client;
            DataContext = Client;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
