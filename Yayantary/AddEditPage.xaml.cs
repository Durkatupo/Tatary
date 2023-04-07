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
using Yayantary.Properties;

namespace Yayantary
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Assortment _currentAssortment = new Assortment();
        public AddEditPage(Assortment selectedAssortment)
        {
            InitializeComponent();

            if (selectedAssortment != null)
                _currentAssortment = selectedAssortment;

            DataContext = _currentAssortment;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAssortment.Name))
                errors.AppendLine("Укажите наименование товара");
            if (string.IsNullOrWhiteSpace(_currentAssortment.Manufacturer))
                errors.AppendLine("Укажите компанию-производитель");
            if (string.IsNullOrWhiteSpace(_currentAssortment.Price))
                errors.AppendLine("Укажите цену");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentAssortment.IDProduct == 0)
            {
                TataryEntities1.GetContext().Assortment.Add(_currentAssortment);
            }

            try
            {
                TataryEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
