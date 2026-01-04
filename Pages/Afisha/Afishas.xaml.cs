using Cinema_Shashin.Elements;
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

namespace Cinema_Shashin.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Afishas.xaml
    /// </summary>
    public partial class Afishas : Page
    {
        Classes.Cinemas cinemas;
        public Afishas(Classes.Cinemas _cinemas)
        {
            InitializeComponent();
            cinemas = _cinemas;
            cinemaLabel.Content += cinemas.Title;
            MainWindow.mainWindow.LoadAfishas(cinemas);
            var _afishas = MainWindow.mainWindow.afishas;
            foreach (var afishas in _afishas)
            {
                parent.Children.Add(new AfishaItm(afishas));
            }
            parent.Children.Add(new AddCinema());
        }
    }
}
