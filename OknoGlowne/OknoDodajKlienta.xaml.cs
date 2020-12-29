using System;
using System.Windows;
using BiuroNieruchomosci;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajKlienta.xaml
    /// </summary>
    public partial class OknoDodajKlienta : Window
    {
        Klient _klient = new Klient();

        public OknoDodajKlienta()
        {
            InitializeComponent();
        }

        public OknoDodajKlienta(Klient klient) : this()
        {
            _klient = klient;
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxPESEL.Text != "" && txtBoxImie.Text != "" && txtBoxNazwisko.Text != "")
            {
                string[] formatDaty = { "dd-MM-yyyy" };
                DateTime.TryParseExact(txtBoxDataUrodzenia.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataUr);
                if (dataUr.Year == 1)
                {
                    string message = "Data urodzenia powinna zostać wpisana w formacie dd-MM-yyyy";
                    string title = "Niepoprawny format daty";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                }
                else
                {
                    _klient.Imie = txtBoxImie.Text;
                    _klient.Nazwisko = txtBoxNazwisko.Text;
                    _klient.DataUrodzenia = dataUr;
                    _klient.PESEL = txtBoxPESEL.Text;
                    if (txtBoxMiejscowosc.Text != "") //wystarczy ten warunek, bo wtedy obowiązkowo trzeba podać resztę do wywołania konstruktora
                    {
                        _klient.Miejscowosc = txtBoxMiejscowosc.Text;
                        _klient.NumerDomu = txtBoxNumerDomu.Text;
                        _klient.Email = txtBoxEmail.Text;
                        _klient.NrTelefonu = txtBoxNumerTelefonu.Text;
                        if (txtBoxUlica.Text != "")
                        {
                            _klient.Ulica = txtBoxUlica.Text;
                        }
                        if (txtBoxNumerMieszkania.Text != "")
                        {
                            _klient.NumerMieszkania = txtBoxNumerMieszkania.Text;
                        }
                    }
                    DialogResult = true; // to co wpisalismy jest okej, dlatego tez wczesniej przypisalismy wszystko do odpowiednich zmiennych
                }
            }
            else
            {
                string message = "Nie wprowadzono istotnych danych";
                string title = "Brak danych";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
            }
        }
    }
}
