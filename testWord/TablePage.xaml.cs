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
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public TablePage(bool b)
        {
            InitializeComponent();

            var comboList = testWordEntities1.GetTestWordEntities1().Бригады.ToList();

            comboList.Insert(0, new Бригады
            {
                Машина = "Все"
            });
            CBB.ItemsSource = comboList;

            CBB.SelectedIndex = 0;

            LVC.ItemsSource = testWordEntities1.GetTestWordEntities1().Сотрудники.ToList();
            DGT.ItemsSource = testWordEntities1.GetTestWordEntities1().Задачи.ToList();

            update();
        }

        private void update()
        {
            var comboList = testWordEntities1.GetTestWordEntities1().Сотрудники.ToList();
            if (CBB.SelectedIndex > 0)
                comboList = comboList.Where(p => p.Бригады == (CBB.SelectedItem as Бригады)).ToList();

            comboList = comboList.Where(p => p.Имя.ToLower().Contains(TBN.Text.ToLower())).ToList();

            LVC.ItemsSource = comboList;
        }

        private void CBB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void TBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }
    }
}
