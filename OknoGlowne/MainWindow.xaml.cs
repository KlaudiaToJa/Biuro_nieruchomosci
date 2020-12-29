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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BiuroNieruchomosci;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Klienci listaKlientow = new Klienci();

        public MainWindow()
        {
            InitializeComponent();
            listaKlientow = (Klienci)Klienci.OdczytajXML("listaKlientow.xml");
        }

        private void ButtonUtworzNowaUmowe_Click(object sender, RoutedEventArgs e)
        {
            OknoUtworzNowaUmowe okno = new OknoUtworzNowaUmowe(); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna
        }

        private void ButtonDodajNowegoKlienta_Click(object sender, RoutedEventArgs e)
        {
            Klient k = new Klient();
            OknoDodajKlienta okno = new OknoDodajKlienta(k);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                listaKlientow.DodajOsobe(k); //dodajemy klienta
                listaKlientow.ZapiszXML("listaKlientow.xml");

            }
        }

        private void ButtonDodajNieruchomosc_Click(object sender, RoutedEventArgs e)
        {
            OknoDodajNieruchomosc okno = new OknoDodajNieruchomosc();
            bool? ret = okno.ShowDialog();
        }

        private void ButtonDodajPracownika_Click(object sender, RoutedEventArgs e)
        {
            OknoDodajPracownika okno = new OknoDodajPracownika();
            bool? ret = okno.ShowDialog();
        }

        private void ButtonPrzegladajListeNieruchomosci_Click(object sender, RoutedEventArgs e)
        {
            OknoListaNieruchomosci okno = new OknoListaNieruchomosci();
            bool? ret = okno.ShowDialog();
        }

        private void ButtonWyswietlArchiwum_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPrzegladajListeKlientow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPrzegladajListePracownikow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPrzegladajAktualneOferty_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
