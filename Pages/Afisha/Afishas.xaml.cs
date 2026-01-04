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
            MainWindow.mainWindow.afishas.Clear();
            MainWindow.mainWindow.LoadAfishas(cinemas);
            if(MainWindow.mainWindow.afishas.Count == 0)
            {
                parent.Children.Add(new TextBlock
                {
                    Text = "Сеансов не найдено",
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 30,
                    Margin = new Thickness(0,20,0,20)
                });
            }
            var _afishas = MainWindow.mainWindow.afishas;
            foreach (var afishas in _afishas)
            {
                parent.Children.Add(new AfishaItm(afishas, cinemas));
            }
            parent.Children.Add(new AddAfisha(cinemas));
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Cinemas());
        }
    }
}
