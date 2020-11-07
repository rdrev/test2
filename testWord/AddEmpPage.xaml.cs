using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace testWord
{
    /// <summary>
    /// Логика взаимодействия для AddEmpPage.xaml
    /// </summary>
    public partial class AddEmpPage : Page
    {
        private Сотрудники сотрудник = new Сотрудники();

        public AddEmpPage(Сотрудники сотрудник)
        {
            this.сотрудник = сотрудник;

            InitializeComponent();
            DataContext = сотрудник;
            CBB.ItemsSource = testWordEntities1.GetTestWordEntities1().Бригады.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(password1.Password == password2.Password)
                {
                    сотрудник.Пароль = password1.Password;
                    if (сотрудник.КодСотрудника != 0)
                        testWordEntities1.GetTestWordEntities1().Сотрудники.Remove(сотрудник);
                    testWordEntities1.GetTestWordEntities1().SaveChanges();
                    testWordEntities1.GetTestWordEntities1().Сотрудники.Add(сотрудник);
                    testWordEntities1.GetTestWordEntities1().SaveChanges();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MenegerPage.Frame.GoBack();
        }

        private void ObzBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                var img = File.ReadAllBytes(filename);
                var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Bilder", filename);
                var uri = new Uri(path);
                var bitmap = new BitmapImage(uri);

                сотрудник.Фото = img;

                ipmegePoto.Source = bitmap;
            }
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerPage.Frame.GoBack();
        }
    }
}
