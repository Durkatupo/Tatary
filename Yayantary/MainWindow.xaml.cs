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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yayantary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new TataryEntities1())
            {
                var user = db.Users
                   .AsNoTracking()
                   .FirstOrDefault(u => u.Login == Login.Text && u.Password == Password.Password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден");
                    return;
                }
                MessageBox.Show("Пользователь успешно найден!");
                Forms.UserWindow userWindow = new Forms.UserWindow();
                userWindow.Show();
                this.Close();
            }
        }

        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.RegWindow regWindow = new Forms.RegWindow();
            regWindow.Show();
            this.Close();
        }
    }
}
