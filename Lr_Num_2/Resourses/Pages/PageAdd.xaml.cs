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
using Lr_Num_2.Resourses.Classes;
using System.Windows.Shapes;

namespace Lr_Num_2.Resourses.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        public PageAdd()
        {
            InitializeComponent();
        }


        private void btnBack(object sender, RoutedEventArgs e)
        {
            FrameAPP.frmobj.Navigate(new Table_about());
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(firstBox.Text) || String.IsNullOrEmpty(secondBox.Text) || String.IsNullOrEmpty(finalBox.Text))
            {
                MessageBox.Show("заполните поля");
            }
            else
            {
                WORKER wk = new WORKER()
                {
                    SurnameInitial = firstBox.Text,
                    Post = secondBox.Text,
                    ExperienceYears = int.Parse(finalBox.Text)
                };
                ConnnectHelper.objdb.WORKER.Add(wk);
            }
        }
    }
}
