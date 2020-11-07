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
    /// Логика взаимодействия для AddBriPage.xaml
    /// </summary>
    public partial class AddBriPage : Page
    {
        private Бригады бригада = new Бригады();

        public AddBriPage()
        {
            InitializeComponent();
            DataContext = бригада;
        }

        private void BtnVxod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                testWordEntities1.GetTestWordEntities1().Бригады.Add(бригада);
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
