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

        }

        private void buttonWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
