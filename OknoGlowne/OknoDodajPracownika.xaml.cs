using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (txtBoxPESEL.Text != "" && txtBoxImie.Text != "" && txtBoxNazwisko.Text != "" && txtBoxDataUrodzenia.Text != "")
            {
                string[] formatDaty = { "dd-MM-yyyy" };
                DateTime.TryParseExact(txtBoxDataUrodzenia.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataUr);
                if (dataUr.Year == 1)
                {
                    string message = "Data urodzenia powinna zostać wpisana w formacie dd-MM-yyyy";
                    string title = "Niepoprawna forma";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    txtBoxDataUrodzenia.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                    return;
                }
                else
                {
                    _pracownik.Imie = txtBoxImie.Text;
                    _pracownik.Nazwisko = txtBoxNazwisko.Text;
                    _pracownik.DataUrodzenia = dataUr;

                    if (txtBoxPESEL.Text.Length != 11)
                    {
                        string message1 = "Niepoprawna forma nr PESEL";
                        string title1 = "Niepoprawna forma";
                        MessageBox.Show(message1, title1, MessageBoxButton.OK, MessageBoxImage.Error);
                        txtBoxPESEL.Focus();
                        return;
                    }

                    _pracownik.PESEL = txtBoxPESEL.Text;

                    if (txtBoxMiejscowosc.Text == "")
                    {
                        string messagedom = "Nie wpisano miejscowosci. Czy chcesz zapisac pracownika bez adresu i danych kontaktowych?";
                        string titledom = "Brak danych";
                        if (MessageBox.Show(messagedom, titledom, MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    if (txtBoxMiejscowosc.Text != "" && txtBoxNumerDomu.Text == "")
                    {
                        string messagedom = "Nie wpisano numeru domu.";
                        string titledom = "Brak danych";
                        MessageBox.Show(messagedom, titledom, MessageBoxButton.OK, MessageBoxImage.Error);
                        txtBoxNumerDomu.Focus();
                        return;
                    }
                    else if (txtBoxMiejscowosc.Text != "" && txtBoxEmail.Text == "")
                    {
                        string messageemail = "Nie wpisano adresu e-mail.";
                        string titleemail = "Brak danych";
                        MessageBox.Show(messageemail, titleemail, MessageBoxButton.OK, MessageBoxImage.Error);
                        txtBoxEmail.Focus();
                        return;
                    }
                    else if (txtBoxMiejscowosc.Text != "" && txtBoxNumerTelefonu.Text == "")
                    {
                        string messagetelefon = "Nie wpisano numeru telefonu.";
                        string titletelefon = "Brak danych";
                        MessageBox.Show(messagetelefon, titletelefon, MessageBoxButton.OK, MessageBoxImage.Error);
                        txtBoxNumerTelefonu.Focus();
                        return;
                    }
                    else
                    {
                        _pracownik.Miejscowosc = txtBoxMiejscowosc.Text;
                        _pracownik.NumerDomu = txtBoxNumerDomu.Text;

                        Regex wzorzec2 = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
                        if (wzorzec2.IsMatch(txtBoxEmail.Text))
                        {
                            _pracownik.Email = txtBoxEmail.Text;
                        }
                        else
                        {
                            string messagetelefon = "Email zostal wpisany w zlej formie.";
                            string titletelefon = "Niepoprawna forma";
                            MessageBox.Show(messagetelefon, titletelefon, MessageBoxButton.OK, MessageBoxImage.Error);
                            txtBoxEmail.Focus();
                            return;
                        }

                        Regex wzorzec = new Regex(@"^[0-9]{9}$");
                        if (wzorzec.IsMatch(txtBoxNumerTelefonu.Text))
                        {
                            _pracownik.NrTelefonu = txtBoxNumerTelefonu.Text;
                        }
                        else
                        {
                            string messagetelefon = "Numer telefonu zostal wpisany w zlej formie.";
                            string titletelefon = "Niepoprawna forma";
                            MessageBox.Show(messagetelefon, titletelefon, MessageBoxButton.OK, MessageBoxImage.Error);
                            txtBoxNumerTelefonu.Focus();
                            return;
                        }

                        if (txtBoxUlica.Text != "")
                        {
                            _pracownik.Ulica = txtBoxUlica.Text;
                        }
                        if (txtBoxNumerMieszkania.Text != "")
                        {
                            _pracownik.NumerMieszkania = txtBoxNumerMieszkania.Text;
                        }
                    }

                    DialogResult = true; // to co wpisalismy jest okej, dlatego tez wczesniej przypisalismy wszystko do odpowiednich zmiennych
                    string message = "Właśnie dodałeś nowego pracownika!";
                    string title = "Sukces";
                    MessageBox.Show(message, title, MessageBoxButton.OK);
                }
            }
            else
            {
                string message = "Nie wprowadzono istotnych danych - wymagane: imię, nazwisko, data urodzenia, PESEL.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
