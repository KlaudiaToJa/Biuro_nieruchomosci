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


//TA SAMA SYTUACJA CO Z KLIENTAMI I PRACOWNIKAMI. PROPONUJE I TYM RAZEM WYRZUCIC ZBIOROWOSC I NAPISAC DO NICH FUNKCJE OSOBNO, BO TO WCALE NIE CHCE DZIALAC... (Klaudia)

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoUtworzNowaUmowe.xaml
    /// </summary>
    public partial class OknoUtworzNowaUmowe : Window
    {
        public OknoUtworzNowaUmowe()
        {
            InitializeComponent();
        }

        private void ButtonUmowaPosrednictwaSprzedazy_Click(object sender, RoutedEventArgs e)
        {
            UmowySprzedazy umowy = new UmowySprzedazy();

            if (File.Exists("listaUmowKupna.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                umowy = (UmowySprzedazy)UmowySprzedazy.OdczytajXML("listaUmowySprzedazy.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            UmowaPosrednictwaSprzedazy um = new UmowaPosrednictwaSprzedazy();
            OknoUmowaSprzedazy okno = new OknoUmowaSprzedazy(); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna

            if (ret == true)
            {
                umowy.DodajUmowe(um);
                umowy.ZapiszXML("listaUmowySprzedazy.xml");
            }
        }

        private void ButtonUmowaPosrednictwaKupna_Click(object sender, RoutedEventArgs e)
        {
            UmowyKupna umowy = new UmowyKupna();

            if (File.Exists("listaUmowKupna.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                umowy = (UmowyKupna)UmowyKupna.OdczytajXML("listaUmowyKupna.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            UmowaPosrednictwaKupna um = new UmowaPosrednictwaKupna();
            OknoUmowaKupna okno = new OknoUmowaKupna(um); //inicjalizowanie okna
            bool? ret = okno.ShowDialog(); //wywołanie okna

            if(ret == true)
            {
                umowy.DodajUmowe(um);
                umowy.ZapiszXML("listaUmowyKupna.xml");
            }
        }
    }
}
