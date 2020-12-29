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
        Klient _klient;

        public OknoDodajKlienta()
        {
            InitializeComponent();
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                    _klient.PESEL = txtBoxPESEL.Text;
                    _klient.Imie = txtBoxImie.Text;
                    _klient.Nazwisko = txtBoxNazwisko.Text;
                    _klient.DataUrodzenia = dataUr;
                    if (txtBoxUlica.Text != "")
                    {
                        _klient.Ulica = txtBoxUlica.Text;
                    }
                    if(txtBoxNumerMieszkania.Text != "")
                    {
                        _klient.NumerMieszkania = txtBoxNumerMieszkania.Text;
                    }
                    
                    DialogResult = true; // to co wpisalismy jest okej, dlatego tez wczesniej przypisalismy wszystko do odpowiednich zmiennych
                }
            }
        }
    }
}
