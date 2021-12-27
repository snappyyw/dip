using Diplom.Model;
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

namespace Diplom.Window
{
    /// <summary>
    /// Interaction logic for LibrarianWindow.xaml
    /// </summary>
    public partial class LibrarianWindow
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public LibrarianWindow()
        {
            InitializeComponent();
            DateGrid_Copy.AutoGenerateColumns = false;
            DateGrid.AutoGenerateColumns = false;
            DateGrid.ItemsSource = databaseEntities.Books.ToList();
            DateGrid_Copy.ItemsSource = databaseEntities.Users.ToList();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddedBookWindow addedBookWindow = new AddedBookWindow();
            addedBookWindow.Show();
            this.Close();
        }

        private void Button_Click_Delete_User(object sender, RoutedEventArgs e)
        {
            if (DateGrid_Copy.SelectedItems.Count > 0)
            {
                Users user = (Users)DateGrid_Copy.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    databaseEntities.Users.Remove(user);
                    databaseEntities.SaveChanges();
                    DateGrid_Copy.ItemsSource = databaseEntities.Users.ToList();
                }
            }
        }

        private void Button_Click_Delete_Book(object sender, RoutedEventArgs e)
        {
            if (DateGrid.SelectedItems.Count > 0)
            {
                Books books = (Books)DateGrid.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    databaseEntities.Books.Remove(books);
                    databaseEntities.SaveChanges();
                    DateGrid.ItemsSource = databaseEntities.Books.ToList();
                }
            }
        }
    }
}
