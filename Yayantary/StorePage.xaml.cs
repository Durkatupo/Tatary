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
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        public StorePage()
        {
            InitializeComponent();
            DgridYantary.ItemsSource = TataryEntities1.GetContext().Assortment.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Assortment));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var assortmentForRemoving = DgridYantary.SelectedItems.Cast<Assortment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {assortmentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TataryEntities1.GetContext().Assortment.RemoveRange(assortmentForRemoving);
                    TataryEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация удалена!");

                    DgridYantary.ItemsSource = TataryEntities1.GetContext().Assortment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                    
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TataryEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridYantary.ItemsSource = TataryEntities1.GetContext().Assortment.ToList();
            }
        }
    }
}
