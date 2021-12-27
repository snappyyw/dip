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
    /// Interaction logic for AddedBookWindow.xaml
    /// </summary>
    public partial class AddedBookWindow
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public AddedBookWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Show();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                Books books = new Books();
                books.Name = Name.Text;
                books.PublisherPlace = PublisherPlace.Text;
                books.Genre = Genre.Text;
                books.Auth = Auth.Text;
                books.IntvertNumber = int.Parse(IntvertNumber.Text);
                books.DatеEditions = DatеEditions.SelectedDate;
                books.isActive = true;
                books.Number = int.Parse(Number.Text);
                books.Publisher = Publisher.Text;

                try
                {
                    databaseEntities.Books.Add(books);
                    databaseEntities.SaveChanges();
                    LibrarianWindow librarianWindow = new LibrarianWindow();
                    librarianWindow.Show();
                    this.Close();

                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошбика!");
                }

            }
        }

        private bool isChecked()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Genre.Text))
            {
                error.AppendLine("Введите жанр");
            }
            if (string.IsNullOrEmpty(Name.Text))
            {
                error.AppendLine("Введите название");
            }
            if (string.IsNullOrEmpty(IntvertNumber.Text))
            {
                error.AppendLine("Введите инвентарный номер");
            }
            if (string.IsNullOrEmpty(Auth.Text))
            {
                error.AppendLine("Введите автора");
            }
            if (string.IsNullOrEmpty(DatеEditions.SelectedDate.ToString()))
            {
                error.AppendLine("Выберите дату публикации");
            }
            if (string.IsNullOrEmpty(Publisher.Text))
            {
                error.AppendLine("Введите публикатора");
            }
            if (string.IsNullOrEmpty(PublisherPlace.Text))
            {
                error.AppendLine("Введите адрес публикации");
            }
            if (string.IsNullOrEmpty(Number.Text))
            {
                error.AppendLine("Введите кол-во страниц");
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
