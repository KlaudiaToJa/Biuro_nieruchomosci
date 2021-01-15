using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using BiuroNieruchomosci;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoListaNieruchomosci.xaml
    /// </summary>
    public partial class OknoListaNieruchomosci : Window
    {
        WszystkieNieruchomosci _caloscNieruchomosci;
        WszystkieNieruchomosci _nowaLista = new WszystkieNieruchomosci();
        int razOtworzone = 0;

        public OknoListaNieruchomosci()
        {
            InitializeComponent();

            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _caloscNieruchomosci = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych nieruchomosci. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_caloscNieruchomosci is object)
            {
                listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_caloscNieruchomosci.ListaNieruchomosci);
            }
        }

        //filtrowanie zlozone
        private void ButtonFiltruj_Click(object sender, RoutedEventArgs e)
        {
            if(razOtworzone == 0)
            {
                if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
                {
                    _nowaLista = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
                }
                else
                {
                    string message = "Nie znaleziono zadnych nieruchomosci. Sprobuj je najpierw dodac.";
                    string title = "Brak danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
            ++razOtworzone;
            //otwiera wszystkie ify po kolei, zatem lista nieruchomosci bedzie sie aktualizowac z kazda kolejna :)
            if (textBoxMiejscowosc.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujMiejscowosc(textBoxMiejscowosc.Text);
            }
            if(textBoxCenaOd.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxCenaOd.Text, out pom)))
                {
                    string message = "Cena została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujCena(pom, 100000000); // maksymalna granica 100 milionow zl
            }
            if(textBoxCenaDo.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxCenaOd.Text, out pom)))
                {
                    string message = "Cena została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujCena(0, pom); // minimalna granica 0 zl
            }

            //po tych wszystkich ifach zamieniam widoczna liste w boxie na nowa:

            listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_nowaLista.ListaNieruchomosci);
        }
    }
}
