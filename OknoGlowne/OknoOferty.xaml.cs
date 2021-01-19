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
    /// Logika interakcji dla klasy OknoOferty.xaml
    /// </summary>
    public partial class OknoOferty : Window
    {
       OfertyRazem _wszystkieOferty = new OfertyRazem();
       OfertyRazem _nowaLista = new OfertyRazem();


        public OknoOferty()
        {
            InitializeComponent();


            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _wszystkieOferty = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaOfert.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_wszystkieOferty.ListaOfert is object)
            {
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
            }
        }

        //filtrowanie zlozone
        private void ButtonFiltruj_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _nowaLista = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaOfert.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_nowaLista.ListaOfert.Count == 0)
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //otwiera wszystkie ify po kolei, zatem lista nieruchomosci bedzie sie aktualizowac z kazda kolejna :)
            //sprawdzamy, czy checkbox jest zaznaczony - wtedy filtrujemy po archiwum

            if (CheckBoxArchiwum.IsChecked == false)
            {
                _nowaLista.ListaOfert = _nowaLista.PrzegladajOferty(true);
            }
            else
            {
                _nowaLista.ListaOfert = _nowaLista.PrzegladajOferty(false);
            }

            if (TextBoxImieKlienta.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujImieKlienta(TextBoxImieKlienta.Text);
            }

            if (TextBoxNazwiskoKlienta.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text);
            }

            if (TextBoxImieOpiekuna.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text);
            }

            if (TextBoxNazwiskoKlienta.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text);
            }

            if (TextBoxData.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujDate(TextBoxData.Text);
            }

            ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_nowaLista.ListaOfert);
        }

        private void ButtonUsungOferte_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOferty.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej oferty.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Oferta k = (Oferta)ListViewOferty.SelectedItem;
            string message = $"Czy na pewno chcesz usunac oferte {k.IdOferty} data wystawienia: {k._dataWystawienia.ToString("dd-MM-yyyy")}?";
            string title = "Usuwanie oferty";

            if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _wszystkieOferty.UsunOferte(k.IdOferty);
                _wszystkieOferty.ZapiszXMLOferty("listaOfert.xml");
                string m = "Pomyslnie usunieto oferte.";
                string t = "Sukces";
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                MessageBox.Show(m, t, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
