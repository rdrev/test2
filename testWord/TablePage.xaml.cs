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
        private bool d;
        private Бригады b = new Бригады();
        
        public TablePage(bool d, Бригады b)
        {     
            InitializeComponent();

            this.d = d;
            this.b = b;

            var comboList = testWordEntities1.GetTestWordEntities1().Бригады.ToList();

            comboList.Insert(0, new Бригады
            {
                Машина = "Все"
            });
            CBB1.ItemsSource = comboList;
            CBB2.ItemsSource = comboList;

            CBB1.SelectedIndex = 0;
            CBB2.SelectedIndex = 0;

            if (d)
            {
                TB1.Visibility = Visibility.Visible;
                TB2.Visibility = Visibility.Visible;
                AddBri.Visibility = Visibility.Visible;
                AddEmp.Visibility = Visibility.Visible;
                AddTask.Visibility = Visibility.Visible;
                CBB1.Visibility = Visibility.Visible;
                CBB2.Visibility = Visibility.Visible;
            }
            else
            {
                TB1.Visibility = Visibility.Hidden;
                TB2.Visibility = Visibility.Hidden;
                AddBri.Visibility = Visibility.Hidden;
                AddEmp.Visibility = Visibility.Hidden;
                AddTask.Visibility = Visibility.Hidden;
                CBB1.Visibility = Visibility.Hidden;
                CBB2.Visibility = Visibility.Hidden;
            }
            update1();
            update2();
        }

        private void update2()
        {
            if (d) 
            {
                var comboList = testWordEntities1.GetTestWordEntities1().Сотрудники.ToList();
                if (CBB2.SelectedIndex > 0)
                    comboList = comboList.Where(p => p.Бригады == (CBB2.SelectedItem as Бригады)).ToList();

                comboList = comboList.Where(p => p.Имя.ToLower().Contains(TBN.Text.ToLower())).ToList();

                LVC.ItemsSource = comboList;
            }
            else
            {
                var comboList = testWordEntities1.GetTestWordEntities1().Сотрудники.Where(p => p.Бригада == b.КодБригады).ToList();

                comboList = comboList.Where(p => p.Имя.ToLower().Contains(TBN.Text.ToLower())).ToList();

                LVC.ItemsSource = comboList;
            }
        }
        private void update1()
        {
            if (d)
            {
                var comboList = testWordEntities1.GetTestWordEntities1().Задачи.ToList();
                if (CBB1.SelectedIndex > 0)
                    comboList = comboList.Where(p => p.Бригады == (CBB1.SelectedItem as Бригады)).ToList();


                DGT.ItemsSource = comboList;
            }
            else
            {
                var comboList = testWordEntities1.GetTestWordEntities1().Задачи.Where(p => p.Бригада == b.КодБригады).ToList();

                DGT.ItemsSource = comboList;
            }
        }
        private void CBB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update2();
        }

        private void TBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            update2();
        }

        private void CBB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update1();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBri_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
