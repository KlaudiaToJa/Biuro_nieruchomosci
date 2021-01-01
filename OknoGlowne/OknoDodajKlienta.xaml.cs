using System;
using System.Text.RegularExpressions;
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
            if (txtBoxPESEL.Text != "" && txtBoxImie.Text != "" && txtBoxNazwisko.Text != "" && txtBoxDataUrodzenia.Text != "")
            {
                string[] formatDaty = { "dd-MM-yyyy" };
                DateTime.TryParseExact(txtBoxDataUrodzenia.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataUr);
                if (dataUr.Year == 1)
                {
                    string message = "Data urodzenia powinna zostać wpisana w formacie dd-MM-yyyy";
                    string title = "Zła forma";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxDataUrodzenia.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                    return;
                }
                else
                {
                    _klient.Imie = txtBoxImie.Text;
                    _klient.Nazwisko = txtBoxNazwisko.Text;
                    _klient.DataUrodzenia = dataUr;

                    if (txtBoxPESEL.Text.Length != 11)
                    {
                        string message1 = "Niepoprawna forma nr PESEL";
                        string title1 = "Zła forma";
                        MessageBox.Show(message1, title1, MessageBoxButton.OK, MessageBoxImage.Error);
                        txtBoxPESEL.Focus();
                        return;
                    }

                    _klient.PESEL = txtBoxPESEL.Text;
                    //czy trzeba dopisac tutaj sprawdzanie czy sa wszystkie pola uzupelnione? Wydaje mi sie ze trzeba cos z tym ogarnac.
                    if (txtBoxMiejscowosc.Text != "")
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
                    string message = "Właśnie dodałeś nowego klienta!";
                    string title = "Sukces";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
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
