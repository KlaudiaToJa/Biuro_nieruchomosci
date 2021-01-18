using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using BiuroNieruchomosci;


//SKONCZONE I DZIALA (Klaudia)


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
                    
                    if(txtBoxMiejscowosc.Text == "")
                    {
                        string messagedom = "Nie wpisano miejscowosci. Czy chcesz zapisac klienta bez adresu i danych kontaktowych?";
                        string titledom = "Brak danych";
                        if (MessageBox.Show(messagedom, titledom, MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            return;
                        }
                    }
                    
                    if(txtBoxMiejscowosc.Text != "" && txtBoxNumerDomu.Text == "")
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
                        _klient.Miejscowosc = txtBoxMiejscowosc.Text;
                        _klient.NumerDomu = txtBoxNumerDomu.Text;

                        Regex wzorzec2 = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
                        if (wzorzec2.IsMatch(txtBoxEmail.Text))
                        {
                            _klient.Email = txtBoxEmail.Text;
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
                            _klient.NrTelefonu = txtBoxNumerTelefonu.Text;
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
                            _klient.Ulica = txtBoxUlica.Text;
                        }
                        if (txtBoxNumerMieszkania.Text != "")
                        {
                            _klient.NumerMieszkania = txtBoxNumerMieszkania.Text;
                        }
                    }

                    DialogResult = true; 
                }
            }
            else
            {
                string message = "Nie wprowadzono istotnych danych - wymagane: imię, nazwisko, data urodzenia, PESEL.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
