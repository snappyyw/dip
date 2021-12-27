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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow
    {
        DatabaseEntities databaseEntities = new DatabaseEntities(); 
        public RegistrationWindow()
        {
            InitializeComponent();
            Role.ItemsSource = new string[] { "Читатель", "Библиотекарь" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private bool isChecked()
        {
            StringBuilder error = new StringBuilder();
            if(string.IsNullOrEmpty(FIO.Text))
            {
                error.AppendLine("Введите ФИО");
            }
            if (string.IsNullOrEmpty(Address.Text))
            {
                error.AppendLine("Введите адрес");
            }
            if (string.IsNullOrEmpty(Login.Text))
            {
                error.AppendLine("Введите логин");
            }
            if (string.IsNullOrEmpty(Data.Text))
            {
                error.AppendLine("Введите паспортные данные");
            }
            if (string.IsNullOrEmpty((string)Role.SelectedValue))
            {
                error.AppendLine("Выберите роль");
            }

            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошбика!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.FIO = FIO.Text;
            users.Date = Data.Text;
            users.Login = Login.Text;
            users.Place = Address.Text;
            users.Role = (string)Role.SelectedValue;
            if (isChecked())
            {
                try
                {
                    databaseEntities.Users.Add(users);
                    databaseEntities.SaveChanges();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошбика!");
                }
            }
         
        }

      
    }
}
