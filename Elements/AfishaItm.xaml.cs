using Cinema_Shashin.Classes;
using Google.Protobuf.WellKnownTypes;
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

namespace Cinema_Shashin.Elements
{
    /// <summary>
    /// Логика взаимодействия для AfishaItm.xaml
    /// </summary>
    public partial class AfishaItm : UserControl
    {
        Afish afishas;
        public AfishaItm(Afish _afish)
        {
            InitializeComponent();
            afishas = _afish;
            movie.Content = afishas.movie;
            date_seans.Content += afishas.date_seans.ToString("dd MMMM");
            time_film.Content += afishas.time_film.ToString();
            price.Content += $"{afishas.price}₽";
        }

        private void afishaEdit(object sender, RoutedEventArgs e)
        {

        }

        private void afishaDelete(object sender, RoutedEventArgs e)
        {

        }
    }
}
