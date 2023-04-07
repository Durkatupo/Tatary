using System;
using Yayantary.Properties;
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

namespace Yayantary.Forms
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void AddEnterButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddRegButton_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Login = AddLogin.Text;
            users.Password = AddPassword.Password;

            if (string.IsNullOrEmpty(AddLogin.Text) || string.IsNullOrEmpty(AddPassword.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
            if(TataryEntities1.GetContext().Users.Count(x => x.Login == AddLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }

            try
                {
                    TataryEntities1.GetContext().Users.Add(users);
                    TataryEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Успешно", "Добавление пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            
        }
    }
}
