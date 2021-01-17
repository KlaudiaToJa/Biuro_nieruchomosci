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



// POWINNO BYĆ CAŁE DZIAŁAJĄCE (Klaudia)


namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoUmowaSprzedazy.xaml
    /// </summary>
    public partial class OknoUmowaSprzedazy : Window
    {
        UmowaPosrednictwaSprzedazy _umowa = new UmowaPosrednictwaSprzedazy();

        Pracownicy DanePracownikow = new Pracownicy();
        Klienci DaneKlientow = new Klienci();
        WszystkieNieruchomosci DaneNieruchomosci = new WszystkieNieruchomosci();

        public OknoUmowaSprzedazy()
        {
            InitializeComponent();

            if (File.Exists("listaKlientow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                DaneKlientow = (Klienci)Klienci.OdczytajXML("listaKlientow.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }
            else
            {
                string message = "Nie znaleziono żadnych klientów. Pamiętaj, żeby najpierw ich dodać.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK);
            }

            if (File.Exists("listaPracownikow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                DanePracownikow = (Pracownicy)Pracownicy.OdczytajXML("listaPracownikow.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }
            else
            {
                string message = "Nie znaleziono żadnych pracowników. Pamiętaj, żeby najpierw ich dodać.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK);
            }

            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                DaneNieruchomosci = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }
            else
            {
                string message = "Nie znaleziono żadnych nieruchomości. Pamiętaj, żeby najpierw je dodać.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK);
            }

            foreach (Klient k in DaneKlientow.ListaKlientow)
            {
                ComboBoxKlient.Items.Add(k); // dodawanie elementow listy rozwijanej
            }

            foreach (Pracownik p in DanePracownikow.ListaPracownikow)
            {
                ComboBoxPracownik.Items.Add(p); // dodawanie elementow listy rozwijanej
            }

            foreach (Nieruchomosc n in DaneNieruchomosci.ListaNieruchomosci)
            {
                ComboBoxNieruchomosc.Items.Add(n); // dodawanie elementow listy rozwijanej
            }
        }

        public OknoUmowaSprzedazy(UmowaPosrednictwaSprzedazy u) : this()
        {
            _umowa = u;
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
                ComboBoxKlient.Items.Add(kl); // dodawanie elementow listy rozwijanej
            }
        }

        private void ButtonDodajNowaNieruchomosc_Click(object sender, RoutedEventArgs e)
        {
            WszystkieNieruchomosci listaNieruchomosci = new WszystkieNieruchomosci();
            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                listaNieruchomosci = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
            }

            Nieruchomosc n = new Nieruchomosc();
            OknoDodajNieruchomosc okno = new OknoDodajNieruchomosc(n);
            bool? ret = okno.ShowDialog();

            if (ret == true)
            {
                MessageBox.Show("okejka");
                listaNieruchomosci.DodajNieruchomosc(n);
                listaNieruchomosci.ZapiszXML("listaNieruchomosci.xml");
                ComboBoxNieruchomosc.Items.Add(n);
            }
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonDodajPracownika_Click(object sender, RoutedEventArgs e)
        {
            Pracownik p = new Pracownik();
            OknoDodajPracownika okno = new OknoDodajPracownika(p);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                DanePracownikow.DodajPracownika(p); // dodaje pracownika do listy
                DanePracownikow.ZapiszXML("listaPracownikow.xml"); // zapisuje nowa liste w pliku xml
                ComboBoxPracownik.Items.Add(p); // ...dodaje do combobox
            }
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxProwizja.Text == "")
            {
                string message = "Nie wpisano prowizji.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxProwizja.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if (txtBoxDataZawarciaUmowy.Text == "")
            {
                string message = "Nie wpisano daty zawarcia umowy.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZawarciaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if (txtBoxDataZakonczeniaUmowy.Text == "")
            {
                string message = "Nie wpisano daty zakończenia umowy.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZakonczeniaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if (ComboBoxKlient.SelectedIndex == -1)
            {
                string message = "Nie wybrano żadnego klienta.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (ComboBoxPracownik.SelectedIndex == -1)
            {
                string message = "Nie wybrano żadnego pracownika.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(ComboBoxNieruchomosc.SelectedIndex == -1)
            {
                string message = "Nie wybrano żadnej nieruchomości.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double pom;
            bool isNumber = double.TryParse(txtBoxProwizja.Text, out pom);
            if (!isNumber)
            {
                string message = "Prowizja została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _umowa.Prowizja = pom;
            _umowa.OpiekunKlienta = (Pracownik)ComboBoxPracownik.SelectedItem;
            _umowa.Nieruchomosc = (Nieruchomosc)ComboBoxNieruchomosc.SelectedItem;
            string[] formatDaty = { "dd-MM-yyyy" };
            DateTime.TryParseExact(txtBoxDataZakonczeniaUmowy.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataZakonczenia);
            DateTime.TryParseExact(txtBoxDataZawarciaUmowy.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataZawarcia);
            if (dataZawarcia.Year == 1)
            {
                string message = "Data urodzenia powinna zostać wpisana w formacie dd-MM-yyyy";
                string title = "Zła forma";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZawarciaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if (dataZakonczenia.Year == 1)
            {
                string message = "Data urodzenia powinna zostać wpisana w formacie dd-MM-yyyy";
                string title = "Zła forma";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZakonczeniaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            _umowa.DataZakonczenia = dataZakonczenia;
            _umowa.DataZawarcia = dataZawarcia;

            DialogResult = true; // to co wpisalismy jest okej, dlatego tez wczesniej przypisalismy wszystko do odpowiednich zmiennych
            string message1 = "Właśnie dodałeś nową umowę!";
            string title1 = "Sukces";
            MessageBox.Show(message1, title1, MessageBoxButton.OK);
        }
    }
}
