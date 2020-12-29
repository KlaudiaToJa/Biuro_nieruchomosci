using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy OknoDodajPracownika.xaml
    /// </summary>
    public partial class OknoDodajPracownika : Window
    {
        Pracownik _pracownik = new Pracownik(); 
        public OknoDodajPracownika()
        {
            InitializeComponent();
        }

        public OknoDodajPracownika(Pracownik pracownik) : this()
        {
            _pracownik = pracownik;
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxPESEL.Text != "" && txtBoxImie.Text != "" && txtBoxNazwisko.Text != "" 
                && txtBoxDataUrodzenia.Text != "" && txtBoxNumerDomu.Text != "" && txtBoxMiejscowosc.Text != ""
                && txtBoxEmail.Text != "" && txtBoxNumerTelefonu.Text != "")
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
                    _pracownik.Imie = txtBoxImie.Text;
                    _pracownik.Nazwisko = txtBoxNazwisko.Text;
                    _pracownik.DataUrodzenia = dataUr;
                    _pracownik.PESEL = txtBoxPESEL.Text;
                    _pracownik.Miejscowosc = txtBoxMiejscowosc.Text;
                    _pracownik.NumerDomu = txtBoxNumerDomu.Text;
                    _pracownik.Email = txtBoxEmail.Text;
                    _pracownik.NrTelefonu = txtBoxNumerTelefonu.Text;
                    if (txtBoxUlica.Text != "")
                    {
                        _pracownik.Ulica = txtBoxUlica.Text;
                    }
                    if (txtBoxNumerMieszkania.Text != "")
                    {
                        _pracownik.NumerMieszkania = txtBoxNumerMieszkania.Text;
                    }
                    DialogResult = true; // to co wpisalismy jest okej, dlatego tez wczesniej przypisalismy wszystko do odpowiednich zmiennych
                    string message = "Właśnie dodałeś nowego pracownika!";
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

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
