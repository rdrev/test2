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
    /// Логика взаимодействия для AvtorizPage.xaml
    /// </summary>
    public partial class AvtorizPage : Page
    {
        public AvtorizPage()
        {
            InitializeComponent();
        }

        private void BtnVxod_Click(object sender, RoutedEventArgs e)
        {
            if (testWordEntities1.GetTestWordEntities1().Сотрудники.ToList().Where(p => p.Логин == login.Text && p.Пароль == Convert.ToString(password.Password) && p.Должность == true).ToList().Count() > 0)
                MenegerPage.Frame.Navigate(new TablePage(true));
            else if (testWordEntities1.GetTestWordEntities1().Сотрудники.ToList().Where(p => p.Логин == login.Text && p.Пароль == Convert.ToString(password.Password) && p.Должность == false).ToList().Count() > 0)
                MenegerPage.Frame.Navigate(new TablePage(false));
            else
            MessageBox.Show("не верный лошин или пароль", "упс");

        }

        private void BtnAvtor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
