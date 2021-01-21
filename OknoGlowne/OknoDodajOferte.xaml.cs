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
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajOferte.xaml
    /// </summary>
    public partial class OknoDodajOferte : Window
    {
        Oferta _oferta = new Oferta();
        UmowySprzedazy _umowy = new UmowySprzedazy();
        OfertyRazem _ofertyRazem = new OfertyRazem();

        public OknoDodajOferte()
        {
            InitializeComponent();

            if (File.Exists("listaUmowySprzedazy.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _umowy = (UmowySprzedazy)UmowySprzedazy.OdczytajXML("listaUmowySprzedazy.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _ofertyRazem = (OfertyRazem)OfertyRazem.OdczytajXMLOferty("listaOfert.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            foreach (UmowaPosrednictwaSprzedazy u in _umowy.ListaUmow)
            {
                //dodawanie do comboBox nieruchomosci tylko z tych umow, ktore w danym momencie nie stracily jeszcze waznosci i nie posiadaja jeszcze utworzonej oferty
                if(DateTime.Compare(u.DataZakonczenia, DateTime.Today) >= 0 && !_ofertyRazem.ListaOfert.Exists(k => k.Umowa.NumerUmowy == u.NumerUmowy))
                {
                    ComboBoxNieruchomosci.Items.Add(u.Nieruchomosc); // dodawanie elementow do listy rozwijanej
                }
            }

            if(ComboBoxNieruchomosci.Items.Count == 0)
            {
                string message = "Brak trwajacych umow posrednictwa sprzedazy lub wystawiono oferty do wszystkich nieruchomosci.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public OknoDodajOferte(Oferta o) : this()
        {
            _oferta = o;
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxNieruchomosci.SelectedIndex == -1)
            {
                string message = "Nie wybrano żadnej nieruchomosci.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(textBoxOpis.Text == "")
            {
                string message = "Nie dodano opisu.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Nieruchomosc n = (Nieruchomosc)ComboBoxNieruchomosci.SelectedItem;

            _oferta.Umowa = _umowy.ListaUmow.Find(x => x.Nieruchomosc.IdNieruchomosci == n.IdNieruchomosci);
            _oferta.Opis = textBoxOpis.Text;
            DialogResult = true;
            string a = "Wlasnie dodales nowa oferte.";
            string b = "Sukces!";
            MessageBox.Show(a, b, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
