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
    /// Logika interakcji dla klasy OknoListaUmow.xaml
    /// </summary>
    public partial class OknoListaUmow : Window
    {
        UmowySprzedazy _uSprzedazy = new UmowySprzedazy();
        UmowyKupna _uKupna = new UmowyKupna();

        public OknoListaUmow()
        {
            InitializeComponent();

            if (File.Exists("listaUmowySprzedazy.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _uSprzedazy = (UmowySprzedazy)UmowySprzedazy.OdczytajXML("listaUmowySprzedazy.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych umow posrednictwa sprzedazy.";
                string title = "Brak danych.";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (File.Exists("listaUmowyKupna.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _uKupna = (UmowyKupna)UmowyKupna.OdczytajXML("listaUmowyKupna.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych umow posrednictwa kupna.";
                string title = "Brak danych.";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(_uSprzedazy.ListaUmow.Count > 0)
            {
                ListViewUmowySprzedazy.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow);
            }

            if (_uKupna.ListaUmow.Count > 0)
            {
                ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow);
            }

            checkBoxWyswietlAktualne.IsChecked = true;
            checkBoxWyswietlZakonczone.IsChecked = true;
        }

        private void buttonFiltruj_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxWyswietlAktualne.IsChecked == true)
            {
                ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow.Where(x => x.DataZakonczenia.Date.CompareTo(DateTime.Today.Date) >= 0));
                ListViewUmowySprzedazy.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow.Where(x => x.DataZakonczenia.Date.CompareTo(DateTime.Today.Date) >= 0));
            }
            else
            {
                ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow.Where(x => x.DataZakonczenia.Date.CompareTo(DateTime.Today.Date) < 0));
                ListViewUmowySprzedazy.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow.Where(x => x.DataZakonczenia.Date.CompareTo(DateTime.Today.Date) < 0));
            }
        }

        private void buttonSzczegolyNieruchomosci_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewUmowySprzedazy.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej umowy posrednictwa sprzedazy.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UmowaPosrednictwaSprzedazy n = (UmowaPosrednictwaSprzedazy)ListViewUmowySprzedazy.SelectedItem;
            if (!(ListViewUmowySprzedazy.SelectedIndex == -1))
            {
                OknoSzczegolyNieruchomosci ok = new OknoSzczegolyNieruchomosci(n.Nieruchomosc);
                ok.ShowDialog();
            }
        }

        private void buttonSortNazwKlientow_Click(object sender, RoutedEventArgs e)
        {
            _uKupna.SortNazwKlientow();
            _uSprzedazy.SortNazwKlientow();
            ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow);
            ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow);
        }

        private void buttonSortNazwPrac_Click(object sender, RoutedEventArgs e)
        {
            _uKupna.SortNazwPracowwnika();
            _uSprzedazy.SortNazwPracowwnika();
            ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow);
            ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow);
        }

        private void buttonUsunUmowe_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewUmowyKupna.SelectedIndex == -1 && ListViewUmowySprzedazy.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej umowy.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!(ListViewUmowyKupna.SelectedIndex == -1))
            {
                UmowaPosrednictwaKupna u_kupna  = (UmowaPosrednictwaKupna)ListViewUmowyKupna.SelectedItem;
                string message = $"Czy na pewno chcesz usunac umowe kupna {u_kupna.NrUmowy},  opiekun: {u_kupna.OpiekunKlienta}, data zawarcia: {u_kupna.DataZawarcia}?";
                string title = "Usuwanie umowy kupna";

                if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _uKupna.UsunUmowe(u_kupna.NrUmowy);
                    _uKupna.ZapiszXML("listaUmowyKupna.xml");
                    string m = "Pomyslnie usunieto umowe kupna.";
                    string t = "Sukces";
                    ListViewUmowyKupna.ItemsSource = new ObservableCollection<UmowaPosrednictwaKupna>(_uKupna.ListaUmow);
                    MessageBox.Show(m, t, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            if (!(ListViewUmowySprzedazy.SelectedIndex == -1))
            {
                UmowaPosrednictwaSprzedazy u_sprzedazy = (UmowaPosrednictwaSprzedazy)ListViewUmowySprzedazy.SelectedItem;
                string message = $"Czy na pewno chcesz usunac umowe sprzedaży {u_sprzedazy.NumerUmowy},  opiekun: {u_sprzedazy.OpiekunKlienta}, data zawarcia: {u_sprzedazy.DataZawarcia}?";
                string title = "Usuwanie umowy sprzedaży";

                if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _uSprzedazy.UsunUmowe(u_sprzedazy.NumerUmowy);
                    _uSprzedazy.ZapiszXML("listaUmowySprzedazy.xml");
                    string m = "Pomyslnie usunieto umowe sprzedaży.";
                    string t = "Sukces";
                    ListViewUmowySprzedazy.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(_uSprzedazy.ListaUmow);
                    MessageBox.Show(m, t, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void buttonWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
