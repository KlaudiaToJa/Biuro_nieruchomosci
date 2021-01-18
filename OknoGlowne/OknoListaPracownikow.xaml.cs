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
    /// Logika interakcji dla klasy OknoListaPracownikow.xaml
    /// </summary>
    public partial class OknoListaPracownikow : Window
    {
        Pracownicy _pracownicy = new Pracownicy();

        public OknoListaPracownikow()
        {
            InitializeComponent();

            if (File.Exists("listaPracownikow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _pracownicy = (Pracownicy)Pracownicy.OdczytajXML("listaPracownikow.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych pracownikow. Sprobuj ich najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_pracownicy is object)
            {
                listViewPracownicy.ItemsSource = new ObservableCollection<Pracownik>(_pracownicy.ListaPracownikow);
            }
        }

        private void buttonSzukajPracownika_Click(object sender, RoutedEventArgs e)
        {
            Regex wzorzec = new Regex(@"^[0-9]{11}$");
            int check = 0;
            if (wzorzec.IsMatch(textBoxPESEL.Text))
            {
                foreach (Klient k in listViewPracownicy.Items)
                {
                    if (k.PESEL == textBoxPESEL.Text)
                    {
                        listViewPracownicy.SelectedItem = k;
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    string message = "Nie znaleziono pracownika o podanym numerze PESEL.";
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

        private void buttonSortujNazwiskami_Click(object sender, RoutedEventArgs e)
        {
            if (_pracownicy.ListaPracownikow.Count > 0)
            {
                _pracownicy.SortujNazwiskaImiona();
                listViewPracownicy.ItemsSource = new ObservableCollection<Pracownik>(_pracownicy.ListaPracownikow);
            }
            else
            {
                string message = "Nie wprowadzono zadnych pracownikow.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonSortujMiastami_Click(object sender, RoutedEventArgs e)
        {
            if (_pracownicy.ListaPracownikow.Count > 0)
            {
                _pracownicy.SortujMiejscowosciami();
                listViewPracownicy.ItemsSource = new ObservableCollection<Pracownik>(_pracownicy.ListaPracownikow);
            }
            else
            {
                string message = "Nie wprowadzono zadnych pracownikow.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonUsunPracownika_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
