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
using System.Windows.Shapes;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoUtworzNowaUmowe.xaml
    /// </summary>
    public partial class OknoUtworzNowaUmowe : Window
    {
        public OknoUtworzNowaUmowe()
        {
            InitializeComponent();
        }

        private void ButtonUmowaPosrednictwaSprzedazy_Click(object sender, RoutedEventArgs e)
        {
            OknoUmowaSprzedazy okno = new OknoUmowaSprzedazy(); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna
        }

        private void ButtonUmowaPosrednictwaKupna_Click(object sender, RoutedEventArgs e)
        {
            OknoUmowaKupna okno = new OknoUmowaKupna(); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna
        }
    }
}
