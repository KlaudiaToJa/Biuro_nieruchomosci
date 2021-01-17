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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BiuroNieruchomosci;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonUtworzNowaUmowe_Click(object sender, RoutedEventArgs e)
        {
            OknoUtworzNowaUmowe okno = new OknoUtworzNowaUmowe(); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna
        }

        private void ButtonDodajNowegoKlienta_Click(object sender, RoutedEventArgs e)
        {
            Klienci listaKlientow = new Klienci();

            if (File.Exists("listaKlientow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                listaKlientow = (Klienci)Klienci.OdczytajXML("listaKlientow.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            Klient k = new Klient();
            OknoDodajKlienta okno = new OknoDodajKlienta(k);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                listaKlientow.DodajKlienta(k); //dodajemy klienta
                listaKlientow.ZapiszXML("listaKlientow.xml");
            }
        }

        private void ButtonDodajNieruchomosc_Click(object sender, RoutedEventArgs e)
        {
            WszystkieNieruchomosci listaNieruchomosci = new WszystkieNieruchomosci();
            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                listaNieruchomosci = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
            }

            Nieruchomosc n = new Nieruchomosc();
            OknoDodajNieruchomosc okno = new OknoDodajNieruchomosc(n);
            bool? ret = okno.ShowDialog();

            if(ret == true)
            {
                listaNieruchomosci.DodajNieruchomosc(n);
                listaNieruchomosci.ZapiszXML("listaNieruchomosci.xml");
            }
        }

        private void ButtonDodajPracownika_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy listaPracownikow = new Pracownicy();
            if (File.Exists("listaPracownikow.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                listaPracownikow = (Pracownicy)Pracownicy.OdczytajXML("listaPracownikow.xml");
            }

            Pracownik p = new Pracownik();
            OknoDodajPracownika okno = new OknoDodajPracownika(p);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                listaPracownikow.DodajPracownika(p); //dodajemy klienta
                listaPracownikow.ZapiszXML("listaKlientow.xml");
            }
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
            OknoOferty okno = new OknoOferty();
            bool? ret = okno.ShowDialog();

        }

       /* private void ButtonDodajOferte_Click(object sender, RoutedEventArgs e)
        {
            OfertyRazem listaOfert = new OfertyRazem();
            if (File.Exists("listaOfert.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                listaOfert = OfertyRazem.OdczytajXMLOferty("listaOfert.xml") as OfertyRazem;
            }

            Oferta oferta = new Oferta();
            OknoDodajOferte okno = new OknoDodajOferte(oferta);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                listaOfert.DodajOferte(oferta); //dodajemy oferte
                listaOfert.ZapiszXMLOferty("listaOfert.xml");
            }
        }*/
    }
}
