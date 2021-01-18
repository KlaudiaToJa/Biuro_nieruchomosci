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
       //OfertyRazem _nowaLista = new OfertyRazem();


        public OknoOferty()
        {
            InitializeComponent();


            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _wszystkieOferty = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaNieruchomosci.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_wszystkieOferty is object)
            {
                
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
            }
        }

        //filtrowanie zlozone
        private void ButtonFiltruj_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _wszystkieOferty = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaNieruchomosci.xml");
            }
            else
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

                
                if (TextBoxImieKlienta.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujImieKlienta(TextBoxImieKlienta.Text, true);
                    _wszystkieOferty.filtrujImieKlienta(TextBoxImieKlienta.Text, true);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxNazwiskoKlienta.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text, true);
                    _wszystkieOferty.filtrujNazwiskoKlienta(TextBoxNazwiskoKlienta.Text, true);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxImieOpiekuna.Text != "")
                {
                    //   _nowaLista.ListaOfert = _nowaLista.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text, true);
                    _wszystkieOferty.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text, true);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxNazwiskoKlienta.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text, true);
                    _wszystkieOferty.filtrujNazwiskoOpiekuna(TextBoxNazwiskoOpiekuna.Text, true);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxData.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujDate(TextBoxData.Text, true);
                    _wszystkieOferty.filtrujDate(TextBoxData.Text, true);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }
            }

           else
            {
                if (TextBoxImieKlienta.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujImieKlienta(TextBoxImieKlienta.Text, false);
                    _wszystkieOferty.filtrujImieKlienta(TextBoxImieKlienta.Text, false);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);

                }

                if (TextBoxNazwiskoKlienta.Text != "")
                {
                    // _nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text, false);
                    _wszystkieOferty.filtrujNazwiskoKlienta(TextBoxNazwiskoKlienta.Text, false);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxImieOpiekuna.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text,false);
                    _wszystkieOferty.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text, false);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxNazwiskoKlienta.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxImieKlienta.Text, false);
                    _wszystkieOferty.filtrujNazwiskoOpiekuna(TextBoxNazwiskoOpiekuna.Text, false);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

                if (TextBoxData.Text != "")
                {
                    //_nowaLista.ListaOfert = _nowaLista.filtrujDate(TextBoxData.Text, false);
                    _wszystkieOferty.filtrujDate(TextBoxData.Text, false);
                    ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);
                }

            }

        }
    }
}
