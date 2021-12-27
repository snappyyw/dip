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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        Users _users = new Users();
        public UserWindow(Users user)
        {
            InitializeComponent();
            DateGrid.AutoGenerateColumns = false;
            DateGrid.ItemsSource = databaseEntities.Books.ToList();
            DateGridHistory.ItemsSource = databaseEntities.Accounting.Where(item=>item.UserId == _users.Id).ToList();
            _users = user;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DateGrid.SelectedItems.Count > 0)
            {
                Books books = (Books)DateGrid.SelectedItems[0];
                Accounting accounting = new Accounting();
                accounting.BookId = books.Id;
                accounting.DateStart = DateTime.Now;
                accounting.DateEnd = DateTime.Today.AddDays(6);
                accounting.UserId = _users.Id;
                try
                {
                    databaseEntities.Accounting.Add(accounting);
                    databaseEntities.SaveChanges();
                    MessageBox.Show("Книга забронирована", "Внимание!");
                    DateGridHistory.ItemsSource = databaseEntities.Accounting.Where(item => item.UserId == _users.Id).ToList();
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошбика!");
                }
               
            }
        }
    }
}
