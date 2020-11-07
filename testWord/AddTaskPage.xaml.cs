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

namespace testWord
{
    /// <summary>
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        private Задачи задача = new Задачи();

        public AddTaskPage()
        {
            InitializeComponent();
            DataContext = задача;
            Bri.ItemsSource = testWordEntities1.GetTestWordEntities1().Бригады.ToList();
        }

        private void BtnVxod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                testWordEntities1.GetTestWordEntities1().Задачи.Add(задача);
                testWordEntities1.GetTestWordEntities1().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            MenegerPage.Frame.GoBack();
        }

        private void Cle_Click(object sender, RoutedEventArgs e)
        {
            MenegerPage.Frame.GoBack();
        }
    }
}
