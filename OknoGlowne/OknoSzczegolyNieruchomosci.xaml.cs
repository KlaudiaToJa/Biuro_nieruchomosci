using BiuroNieruchomosci;
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

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoSzczegolyNieruchomosci.xaml
    /// </summary>
    public partial class OknoSzczegolyNieruchomosci : Window
    {
        Nieruchomosc _nieruchomosc = new Nieruchomosc();

        public OknoSzczegolyNieruchomosci()
        {
            InitializeComponent();
        }

        public OknoSzczegolyNieruchomosci(Nieruchomosc n) : this()
        {
            _nieruchomosc = n; 
            if(n is object)
            {
                TextBoxMiekscowosc.Text = _nieruchomosc.Miejscowosc;
                TextBoxUlica.Text = _nieruchomosc.Ulica;
                TextBoxNumerDomu.Text = _nieruchomosc.NumerDomu;
                TextBoxNumerMieszkania.Text = _nieruchomosc.NumerMieszkania;
                TextBoxPowierzchnia.Text = _nieruchomosc.Powierzchnia.ToString();
                TextBoxLiczbaPokojow.Text = _nieruchomosc.LiczbaPokojow.ToString();
                TextBoxPietro.Text = _nieruchomosc.Pietro.ToString();
                TextBoxWysokoscOplat.Text = _nieruchomosc.WysokoscOplat.ToString();
                TextBoxTypNieruchomosci.Text = _nieruchomosc.TypNieruchomosci1.ToString();
                TextBoxRodzajNieruchomosci.Text = _nieruchomosc.RodzajNieruchomosci1.ToString();
                TextBoxTypTransakcji.Text = _nieruchomosc.TypTransakcji1.ToString();
                TextBoxStandard.Text = _nieruchomosc.Standard1.ToString();
                TextBoxRynek.Text = _nieruchomosc.Rynek1.ToString();
                TextBoxRodzajKuchni.Text = _nieruchomosc.RodzajKuchni1.ToString();
                TextBoxCena.Text = _nieruchomosc.Cena.ToString();
                if (_nieruchomosc.Balkon)
                    TextBoxBalkon.Text = "Tak";
                if (_nieruchomosc.Parking)
                    TextBoxParking.Text = "Tak";
                if (_nieruchomosc.Umeblowane)
                    TextBoxUmeblowane.Text = "Tak";
                TextBoxImie.Text = _nieruchomosc.Wlasciciel.Imie;
                TextBoxNazwisko.Text = _nieruchomosc.Wlasciciel.Nazwisko;
                TextBoxTelefon.Text = _nieruchomosc.Wlasciciel.NrTelefonu;
                TextBoxMail.Text = _nieruchomosc.Wlasciciel.Email;
            }
            
        }

        private void ButtonPowrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonPokazOferty_Click(object sender, RoutedEventArgs e)
        {
            OfertyRazem of = new OfertyRazem();
            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                of = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaOfert.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych istniejacych ofert. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OknoOferty okno = new OknoOferty();
            okno.ListViewOferty.ItemsSource = new ObservableCollection<Oferta>(of.ListaOfert.Where(x => x.Umowa.Nieruchomosc.IdNieruchomosci == _nieruchomosc.IdNieruchomosci));
            okno.ButtonFiltruj.IsEnabled = false; // wylacza mozliwosc uzycia przycisku
            okno.ButtonWyczyscFiltry.IsEnabled = false;
            okno.ButtonUsungOferte.IsEnabled = false;
            okno.ButtonArchiwizujOferte.IsEnabled = false;
            okno.ShowDialog();
        }

        private void ButtonPokazUmowy_Click(object sender, RoutedEventArgs e)
        {
            UmowySprzedazy of = new UmowySprzedazy();
            if (File.Exists("listaUmowySprzedazy.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                of = (UmowySprzedazy)UmowySprzedazy.OdczytajXML("listaUmowySprzedazy.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych istniejacych umow sprzedazy. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OknoListaUmow okno = new OknoListaUmow();
            okno.ListViewUmowyKupna.ItemsSource = null;
            okno.ListViewUmowySprzedazy.ItemsSource = new ObservableCollection<UmowaPosrednictwaSprzedazy>(of.ListaUmow.Where(x => x.Nieruchomosc.IdNieruchomosci == _nieruchomosc.IdNieruchomosci));
            okno.buttonUsunUmowe.IsEnabled = false; // wylaczanie mozliwosci usuwania
            okno.buttonSzczegolyNieruchomosci.IsEnabled = false; //poniewaz to z okna szczegolow w tym przypadku wywoluje okno umow
            okno.ShowDialog();
        }
    }
}
