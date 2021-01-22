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
                _nowaLista = (OfertyRazem)_wszystkieOferty.Clone();
            }
            else
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_wszystkieOferty.ListaOfert is object)
            {
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert.Where(x => x.czyAktywna == true)); //wyswietlenie aktywnych ofert
            }
        }

        //filtrowanie zlozone
        private void ButtonFiltruj_Click(object sender, RoutedEventArgs e)
        {
            _nowaLista = (OfertyRazem)_wszystkieOferty.Clone();

            if (_nowaLista.ListaOfert.Count == 0)
            {
                string message = "Nie znaleziono zadnych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //otwiera wszystkie ify po kolei, zatem lista nieruchomosci bedzie sie aktualizowac z kazda kolejna.
            //sprawdzamy, czy checkbox jest zaznaczony - wtedy filtrujemy po archiwum

            if (CheckBoxArchiwum.IsChecked == false)
            {
                _nowaLista.ListaOfert = _nowaLista.PrzegladajOferty(true);
                lblOferty.Content = "Oferty - aktywne";
            }
            else
            {
                _nowaLista.ListaOfert = _nowaLista.PrzegladajOferty(false);
                lblOferty.Content = "Oferty - archiwum";
            }

            if (TextBoxImieKlienta.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujImieKlienta(TextBoxImieKlienta.Text);
            }

            if (TextBoxNazwiskoKlienta.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoKlienta(TextBoxNazwiskoKlienta.Text);
            }

            if (TextBoxImieOpiekuna.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujImieOpiekuna(TextBoxImieOpiekuna.Text);
            }

            if (TextBoxNazwiskoOpiekuna.Text != "")
            {
                _nowaLista.ListaOfert = _nowaLista.filtrujNazwiskoOpiekuna(TextBoxNazwiskoOpiekuna.Text);
            }

            if (TextBoxData.Text != "")
            {
                DateTime dataFiltr;
                DateTime.TryParseExact(TextBoxData.Text, new[] { "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataFiltr);
                if(dataFiltr.Year == 1)
                {
                    string message = "Data powinna zostać wpisana w formacie dd-MM-yyyy";
                    string title = "Zła forma";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    TextBoxData.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                    return;
                }
                _nowaLista.ListaOfert = _nowaLista.filtrujDate(dataFiltr);
            }
            ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_nowaLista.ListaOfert);
        }

        private void buttonSortujMiastami_Click(object sender, RoutedEventArgs e)
        {
            if (_nowaLista.ListaOfert.Count > 0)
            {
                _nowaLista.SortujMiejscowosciami();
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_nowaLista.ListaOfert);
            }
            else
            {
                string message = "Okno ofert jest puste.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void ButtonWyczyscFiltry_Click(object sender, RoutedEventArgs e)
        {
            ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert);

            TextBoxImieKlienta.Text = "";
            TextBoxNazwiskoKlienta.Text = "";
            TextBoxImieOpiekuna.Text = "";
            TextBoxNazwiskoOpiekuna.Text = "";
            TextBoxData.Text = "";
            CheckBoxArchiwum.IsChecked = false;
        }

        private void ButtonSzczegolyOferty_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOferty.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej oferty.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Oferta k = (Oferta)ListViewOferty.SelectedItem;
            OknoSzczegolyOfert okienko = new OknoSzczegolyOfert(k);

            this.Hide();
            bool? ret = okienko.ShowDialog();
            if (okienko.IsActive == false)
            {
                this.Show();
            }

            if(ret == true)
            {
                _wszystkieOferty.ListaOfert.Find(x => x.IdOferty == k.IdOferty).Opis = k.Opis;
                _wszystkieOferty.ZapiszXMLOferty("listaOfert.xml");
            }
        }

        private void ButtonArchiwizujOferte_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOferty.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej oferty.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Oferta k = (Oferta)ListViewOferty.SelectedItem;

            if(k.czyAktywna == false)
            {
                string mess = "Oferta juz jest zarchiwizowana.";
                string tit = "Bledne polecenie";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(MessageBox.Show("Czy na pewno chcesz zarchiwizowac oferte? Tej operacji nie mozna juz cofnac.", "Archiwizowanie oferty", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _wszystkieOferty.ListaOfert.Find(x => x.IdOferty == k.IdOferty).czyAktywna = false;
                ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(_wszystkieOferty.ListaOfert.Where(x => x.czyAktywna == false));
                CheckBoxArchiwum.IsChecked = true;
                _wszystkieOferty.ZapiszXMLOferty("listaOfert.xml");
            }
        }
    }
}
