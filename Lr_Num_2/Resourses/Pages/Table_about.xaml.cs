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
using Lr_Num_2.Resourses.Classes;

namespace Lr_Num_2.Resourses.Pages
{
    /// <summary>
    /// Логика взаимодействия для Table_about.xaml
    /// </summary>
    public partial class Table_about : Page
    {
        public Table_about()
        {
            InitializeComponent();
            WorkersTable.ItemsSource = ConnnectHelper.objdb.WORKER.ToList();
        }

        private void Added_Frame(object sender, RoutedEventArgs e)
        {
            FrameAPP.frmobj.Navigate(new PageAdd());
        }

        private void Delete_Frame(object sender, RoutedEventArgs e)
        {
            WORKER wkr = WorkersTable.SelectedItem as WORKER;
            if (wkr == null) MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
            else
            {
                if (MessageBox.Show("Вы хотите удалить данну запись?","Уведомление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConnnectHelper.objdb.WORKER.Remove(wkr);
                    ConnnectHelper.objdb.SaveChanges();
                    WorkersTable.ItemsSource = ConnnectHelper.objdb.WORKER.ToList();
                }
            }
        }

        private void SearchExperience_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchExperience.Text.Length == 0)
            {
                WorkersTable.ItemsSource = ConnnectHelper.objdb.WORKER.ToList();
            }
            else
            {
                WorkersTable.ItemsSource = ConnnectHelper.objdb.WORKER.Where(x => x.ExperienceYears.ToString().Contains(SearchExperience.Text)).ToList();
            }
        }
    }
}
