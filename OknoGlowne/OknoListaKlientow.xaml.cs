using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy OknoListaKlientow.xaml
    /// </summary>
    public partial class OknoListaKlientow : Window
    {
        Klienci _klienci = new Klienci();

        public OknoListaKlientow()
        {
            InitializeComponent();

            if (File.Exists("listaKlientow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _klienci = (Klienci)Klienci.OdczytajXML("listaKlientow.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych klientow. Sprobuj ich najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_klienci is object)
            {
                listViewKlienci.ItemsSource = new ObservableCollection<Klient>(_klienci.ListaKlientow);
            }
        }

        private void buttonSzukajKlienta_Click(object sender, RoutedEventArgs e)
        {
            Regex wzorzec = new Regex(@"^[0-9]{11}$");
            int check = 0;
            if (wzorzec.IsMatch(textBoxPESEL.Text))
            {
                foreach(Klient k in listViewKlienci.Items)
                {
                    if(k.PESEL == textBoxPESEL.Text)
                    {
                        listViewKlienci.SelectedItem = k;
                        check = 1;
                    }
                }
                if(check == 0)
                {
                    string message = "Nie znaleziono klienta o podanym numerze PESEL.";
                    string title = "Brak danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else
            {
                string message = "Numer pesel zostal wpisany w zlej formie.";
                string title = "Niepoprawna forma";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxPESEL.Focus();
                return;
            }
        }

        private void buttonSortujNazwiskami_Click(object sender, RoutedEventArgs e) //sortuje nazwiskami a pozniej imionami
        {
            if(_klienci.ListaKlientow.Count > 0)
            {
                _klienci.SortujNazwiskaImiona();
                listViewKlienci.ItemsSource = new ObservableCollection<Klient>(_klienci.ListaKlientow);
            }
            else
            {
                string message = "Nie wprowadzono zadnych klientow.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonSortujMiastami_Click(object sender, RoutedEventArgs e)
        {
            if (_klienci.ListaKlientow.Count > 0)
            {
                _klienci.SortujMiejscowosciami();
                listViewKlienci.ItemsSource = new ObservableCollection<Klient>(_klienci.ListaKlientow);
            }
            else
            {
                string message = "Nie wprowadzono zadnych klientow.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
