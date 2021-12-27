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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();  
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (isChecked()) {
               Users users = databaseEntities.Users.FirstOrDefault(item => item.Login == Login.Text);
                if (users != null)
                {
                    if(users.Role == "Читатель")
                    {
                        UserWindow userWindow = new UserWindow(users);
                        userWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        LibrarianWindow librarianWindow = new LibrarianWindow();
                        librarianWindow.Show();
                        this.Close();
                    }
                }
                else {
                    MessageBox.Show("Пользователь не найдет", "Ошбика!");
                }
            }
        }

        private bool isChecked()
        {
            StringBuilder error = new StringBuilder();
            
            if (string.IsNullOrEmpty(Login.Text))
            {
                error.AppendLine("Введите логин");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошбика!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
