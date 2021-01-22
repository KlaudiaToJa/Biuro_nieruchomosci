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


namespace OknoGlowne
{
    public partial class OknoDodajNieruchomosc : Window
    {
        Nieruchomosc _nieruchomosc = new Nieruchomosc();
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
            if (ComboBoxWlasciciel.Text.Equals("") || txtBoxMiejscowosc.Text.Equals("") || txtBoxPowierzchniaCalkowita.Text.Equals("") ||
                txtBoxWysokoscOplat.Text.Equals("") || ComboBoxTypNieruchomosci.Text.Equals("") || ComboBoxRodzajNieruchomosci.Text.Equals("") ||
                ComboBoxTypTransakcji.Text.Equals("") || ComboBoxStandard.Text.Equals("") || ComboBoxRynek.Text.Equals("") ||
                ComboBoxRodzajKuchni.Text.Equals("") || txtBoxCena.Text.Equals(""))
            {
                string message = "Nie zostały uzupełnione podstawowe dane dotyczące nieruchmości. Wypełnij pola oznaczone gwiazdką";
                string title = "Błąd danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxPowierzchniaCalkowita.Focus();
                return;
            }

            if (ComboBoxTypNieruchomosci.Text.Equals("Mieszkanie"))
            {
                if(txtBoxNumerDomu.Text.Equals("") || txtBoxNumerMieszkania.Text.Equals("") || txtBoxUlica.Text.Equals("") ||
                    txtBoxLiczbaPokojow.Text.Equals("") || txtBoxPietro.Text.Equals("") || ComboBoxWlasciciel.Text.Equals("") || 
                    txtBoxMiejscowosc.Text.Equals("") || txtBoxPowierzchniaCalkowita.Text.Equals("") || txtBoxWysokoscOplat.Text.Equals("") || 
                    ComboBoxTypNieruchomosci.Text.Equals("") || ComboBoxRodzajNieruchomosci.Text.Equals("") ||
                    ComboBoxTypTransakcji.Text.Equals("") || ComboBoxStandard.Text.Equals("") || ComboBoxRynek.Text.Equals("") ||
                    ComboBoxRodzajKuchni.Text.Equals("") || txtBoxCena.Text.Equals(""))
                {
                    string message = "Nie zostały uzupełnione podstawowe dane dotyczące typu nierchomości - mieszkanie. Mieszkanie powinno dodatkowo zawierać" +
                        "inforamcje o: Ulica, Nr domu, Nr mieszkania, Liczba pokoi, Piętro.";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxPowierzchniaCalkowita.Focus();
                    return;
                }
            }

            if (ComboBoxTypNieruchomosci.Text.Equals("Dom"))
            {
                if (txtBoxLiczbaPokojow.Text.Equals("") || txtBoxPietro.Text.Equals("") || ComboBoxWlasciciel.Text.Equals("") || txtBoxMiejscowosc.Text.Equals("") || txtBoxPowierzchniaCalkowita.Text.Equals("") ||
                txtBoxWysokoscOplat.Text.Equals("") || ComboBoxTypNieruchomosci.Text.Equals("") || ComboBoxRodzajNieruchomosci.Text.Equals("") ||
                ComboBoxTypTransakcji.Text.Equals("") || ComboBoxStandard.Text.Equals("") || ComboBoxRynek.Text.Equals("") ||
                ComboBoxRodzajKuchni.Text.Equals("") || txtBoxCena.Text.Equals(""))
                {
                    string message = "Nie zostały uzupełnione podstawowe dane dotyczące typu nierchomości - dom." +
                        "Dom powienien dodatkowo zawierać" +
                        "inforamcje o: Liczba pokoi, Liczba pięter.";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxPowierzchniaCalkowita.Focus();
                    return;
                }
            }

            if( ComboBoxTypNieruchomosci.Text.Equals("Działka"))
            {
                if ((bool)CheckBoxBalkon.IsChecked || (bool)CheckBoxUmeblowane.IsChecked || (bool)CheckBoxParking.IsChecked)
                {
                    string message = "Zostału wypełnione dane nieodpowiednie dla typu nieruchomości - działka. Odznacz checkboxa.";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxPowierzchniaCalkowita.Focus();
                    return;
                }

            }
            if (ComboBoxTypNieruchomosci.Text.Equals("Magazyn"))
            {
                if ((bool)CheckBoxBalkon.IsChecked || (bool)CheckBoxUmeblowane.IsChecked)
                {
                    string message = "Zostału wypełnione dane nieodpowiednie dla typu nieruchomości - magazyn. Odznacz checkboxa.";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxPowierzchniaCalkowita.Focus();
                    return;
                }
            }

            if (ComboBoxTypNieruchomosci.Text.Equals("Lokal") || ComboBoxTypNieruchomosci.Text.Equals("Obiekt"))
            {
                if (txtBoxNumerDomu.Text.Equals("") ||  txtBoxUlica.Text.Equals("") || txtBoxPietro.Text.Equals("") || ComboBoxWlasciciel.Text.Equals("") ||
                  txtBoxMiejscowosc.Text.Equals("") || txtBoxPowierzchniaCalkowita.Text.Equals("") || txtBoxWysokoscOplat.Text.Equals("") ||
                  ComboBoxTypNieruchomosci.Text.Equals("") || ComboBoxRodzajNieruchomosci.Text.Equals("") ||
                  ComboBoxTypTransakcji.Text.Equals("") || ComboBoxStandard.Text.Equals("") || ComboBoxRynek.Text.Equals("") ||
                  ComboBoxRodzajKuchni.Text.Equals("") || txtBoxCena.Text.Equals(""))
                {
                    
                    string message_l = "Nie zostały uzupełnione podstawowe dane dotyczące typu nierchomości - lokal. " +
                        "Lokal powinien dodatkowo zawierać informacje  o: Numer budynku, Ulica, Piętro.";
                    string message_o = "Nie zostały uzupełnione podstawowe dane dotyczące typu nierchomości - obiekt." +
                        "Obiekt powinien dodatkowo zawierać informacje  o: Numer budynku, Ulica, Liczba pięter.";
                    string title = "Błąd danych";
                    if (ComboBoxTypNieruchomosci.Text.Equals("Lokal"))
                    {
                        MessageBox.Show(message_l, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (ComboBoxTypNieruchomosci.Text.Equals("Obiekt"))
                    {
                        MessageBox.Show(message_o, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    txtBoxPowierzchniaCalkowita.Focus();
                    return;
                }
            }

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

            if (!txtBoxLiczbaPokojow.Text.Equals(""))
            {
                if (!(int.TryParse(txtBoxLiczbaPokojow.Text, out pom1)))
                {
                    string message = "Liczba pokojów została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _nieruchomosc.LiczbaPokojow = pom1;
            }

            if (!txtBoxPietro.Text.Equals(""))
            {
                if (!(int.TryParse(txtBoxPietro.Text, out pom1)))
                {
                    string message = "Liczba pieter została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _nieruchomosc.Pietro = pom1;
            }

           
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
