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
using Cinema_Shashin.Classes;

namespace Cinema_Shashin.Elements
{
    /// <summary>
    /// Логика взаимодействия для CinemasItm.xaml
    /// </summary>
    public partial class CinemasItm : UserControl
    {
        Cinemas cinemas;
        public CinemasItm(Cinemas _cinemas)
        {
            InitializeComponent();
            cinemas = _cinemas;
            cinemaName.Content = cinemas.Title;
            countHalls.Content += cinemas.Hall_Count.ToString();
            countSit.Content += cinemas.Total_Seats.ToString();
        }

        private void afishaCheck(object sender, RoutedEventArgs e)
        {

        }

        private void cinemaEdit(object sender, RoutedEventArgs e)
        {

        }
    }
}
