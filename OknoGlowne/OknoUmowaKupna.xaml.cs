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
    /// Logika interakcji dla klasy OknoUmowaKupna.xaml
    /// </summary>
    public partial class OknoUmowaKupna : Window
    {
        UmowaPosrednictwaKupna _umowa = new UmowaPosrednictwaKupna();
        Pracownicy DanePracownikow = (Pracownicy)Pracownicy.OdczytajXML("listaPracownikow.xml");
        Klienci DaneKlientow = (Klienci)Klienci.OdczytajXML("listaKlientow.xml");

        public OknoUmowaKupna()
        {
            InitializeComponent();
            foreach (Klient k in DaneKlientow.ListaKlientow)
            {
                ComboBoxKlient.Items.Add(k); // dodawanie elementow listy rozwijanej
            }
        }

        public OknoUmowaKupna(UmowaPosrednictwaKupna u) : this()
        {
            _umowa = u;
        }

        private void ButtonDodajNowegoKlienta_Click(object sender, RoutedEventArgs e)
        {
            OknoDodajKlienta okno = new OknoDodajKlienta();
            bool? ret = okno.ShowDialog();
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(txtBoxProwizja.Text == "")
            {
                string message = "Nie wpisano prowizji.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxProwizja.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if(txtBoxDataZawarciaUmowy.Text == "")
            {
                string message = "Nie wpisano daty zawarcia umowy.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZawarciaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
            else if(txtBoxDataZakonczeniaUmowy.Text == "")
            {
                string message = "Nie wpisano daty zakończenia umowy.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                txtBoxDataZakonczeniaUmowy.Focus(); // po kliknieciu OK na MessageBox, kursor ustawia sie automatycznie w odpowiednim polu
                return;
            }
        }

        private void ButtonDodajNowegoPracownika(object sender, RoutedEventArgs e)
        {
            OknoDodajPracownika okno = new OknoDodajPracownika();
            bool? ret = okno.ShowDialog();
        }
    }
}
