using System;
using System.Collections.Generic;
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

//SKONCZONE I DZIALA (Klaudia)

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajNieruchomosc.xaml
    /// </summary>
    public partial class OknoDodajNieruchomosc : Window
    {
        Nieruchomosc _nieruchomosc = new Nieruchomosc();
        WszystkieNieruchomosci _caloscNieruchomosci;

        Klienci DaneKlientow = new Klienci();

        public OknoDodajNieruchomosc()
        {
            InitializeComponent();

            if (File.Exists("listaKlientow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                DaneKlientow = (Klienci)Klienci.OdczytajXML("listaKlientow.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }
            else
            {
                string message = "Nie znaleziono żadnych klientów. Pamiętaj, żeby najpierw ich dodać, by móc ustawić właściciela dla nieruchomości.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK);
            }
            foreach (Klient k in DaneKlientow.ListaKlientow)
            {
                ComboBoxWlasciciel.Items.Add(k); // dodawanie elementow listy rozwijanej
            }
            ComboBoxRodzajNieruchomosci.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.RodzajNieruchomosci));
            ComboBoxRynek.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.Rynek));
            ComboBoxStandard.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.Standard));
            ComboBoxTypNieruchomosci.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.TypNieruchomosci));
            ComboBoxTypTransakcji.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.TypTransakcji));
            ComboBoxRodzajKuchni.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.RodzajKuchni));
        }

        public OknoDodajNieruchomosc(Nieruchomosc n) : this()
        {
            _nieruchomosc = n;
        }

        private void ButtonDodajNowegoKlienta_Click(object sender, RoutedEventArgs e)
        {
            Klient kl = new Klient();
            OknoDodajKlienta okno = new OknoDodajKlienta(kl);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                DaneKlientow.DodajKlienta(kl);
                DaneKlientow.ZapiszXML("listaKlientow.xml");
                ComboBoxWlasciciel.Items.Add(kl); // dodawanie elementow listy rozwijanej
            }
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {

            // trzeba dodac sprawdzanie czy zadne z okienek nie jest puste, a jesli puste to ustawic na null (ale trzeba
            // w miare logicznie, zeby nie dalo sie na przyklad dodac bez ceny albo miejscowosci bo szanujmy sie xD
            _nieruchomosc.Wlasciciel = (Klient)ComboBoxWlasciciel.SelectedItem;
            _nieruchomosc.Miejscowosc = txtBoxMiejscowosc.Text;
            _nieruchomosc.Ulica = txtBoxUlica.Text;
            _nieruchomosc.NumerDomu = txtBoxNumerDomu.Text;
            if(txtBoxNumerMieszkania.Text != "")
            {
                _nieruchomosc.NumerMieszkania = txtBoxNumerMieszkania.Text;
            }

            double pom;
            int pom1;

            if (!(double.TryParse(txtBoxPowierzchniaCalkowita.Text, out pom)))
            {
                string message = "Powierzchnia została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxPowierzchniaCalkowita.Focus();
                return;
            }
            _nieruchomosc.Powierzchnia = pom;

            if (!(int.TryParse(txtBoxLiczbaPokojow.Text, out pom1)))
            {
                string message = "Liczba pokojów została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _nieruchomosc.LiczbaPokojow = pom1;

            if (!(int.TryParse(txtBoxPietro.Text, out pom1)))
            {
                string message = "Liczba pieter została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _nieruchomosc.Pietro = pom1;

            if (!(double.TryParse(txtBoxWysokoscOplat.Text, out pom)))
            {
                string message = "Wysokość opłat została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _nieruchomosc.WysokoscOplat = pom;

            if (!(double.TryParse(txtBoxCena.Text, out pom)))
            {
                string message = "Cena została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _nieruchomosc.Cena = pom;

            _nieruchomosc.TypNieruchomosci1 = (Nieruchomosc.TypNieruchomosci)ComboBoxTypNieruchomosci.SelectedItem;
            _nieruchomosc.TypTransakcji1 = (Nieruchomosc.TypTransakcji)ComboBoxTypTransakcji.SelectedItem;
            _nieruchomosc.RodzajNieruchomosci1 = (Nieruchomosc.RodzajNieruchomosci)ComboBoxRodzajNieruchomosci.SelectedItem;
            _nieruchomosc.Standard1 = (Nieruchomosc.Standard)ComboBoxStandard.SelectedItem;
            _nieruchomosc.Rynek1 = (Nieruchomosc.Rynek)ComboBoxRynek.SelectedItem;
            _nieruchomosc.RodzajKuchni1 = (Nieruchomosc.RodzajKuchni)ComboBoxRodzajKuchni.SelectedItem;

            if ((bool)CheckBoxBalkon.IsChecked)
            {
                _nieruchomosc.Balkon = true;
            }
            else
            {
                _nieruchomosc.Balkon = false;
            }

            if ((bool)CheckBoxParking.IsChecked)
            {
                _nieruchomosc.Parking = true;
            }
            else
            {
                _nieruchomosc.Parking = false;
            }

            if ((bool)CheckBoxUmeblowane.IsChecked)
            {
                _nieruchomosc.Umeblowane= true;
            }
            else
            {
                _nieruchomosc.Umeblowane = false;
            }

            DialogResult = true;
            string message1 = "Właśnie dodałeś nową nieruchomość!";
            string title1 = "Sukces";
            MessageBox.Show(message1, title1, MessageBoxButton.OK);
        }
    }
}
