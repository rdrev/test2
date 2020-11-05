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
            LVC.ItemsSource = testWordEntities1.GetTestWordEntities1().Сотрудники.ToList();
            DGT.ItemsSource = testWordEntities1.GetTestWordEntities1().Задачи.ToList();
        }
    }
}
