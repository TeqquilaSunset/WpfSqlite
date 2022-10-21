using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace WpfSqlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }


        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Clients.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Clients.Local.ToObservableCollection();
        }


        //Add
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow ClientWindow = new ClientWindow(new Client());
            if (ClientWindow.ShowDialog() == true)
            {
                Client Client = ClientWindow.Client;
                db.Clients.Add(Client);
                db.SaveChanges();
            }
        }

        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? client = clientsList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (client is null) return;

            ClientWindow ClientWindow = new ClientWindow(new Client
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Adress = client.Adress,
            });

            if (ClientWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                client = db.Clients.Find(ClientWindow.Client.Id);
                if (client != null)
                {
                    client.Name = ClientWindow.Client.Name;
                    client.Surname = ClientWindow.Client.Surname;
                    client.PhoneNumber = ClientWindow.Client.PhoneNumber;
                    client.Adress = ClientWindow.Client.Adress;
                    db.SaveChanges();
                    clientsList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? client = clientsList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (client is null) return;
            db.Clients.Remove(client);
            db.SaveChanges();
        }
    }
}
