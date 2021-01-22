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
    public partial class OknoUtworzNowaUmowe : Window
    {
        public OknoUtworzNowaUmowe()
        {
            InitializeComponent();
        }

        private void ButtonUmowaPosrednictwaSprzedazy_Click(object sender, RoutedEventArgs e)
        {
            UmowySprzedazy umowy = new UmowySprzedazy();

            if (File.Exists("listaUmowySprzedazy.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                umowy = (UmowySprzedazy)UmowySprzedazy.OdczytajXML("listaUmowySprzedazy.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            UmowaPosrednictwaSprzedazy um = new UmowaPosrednictwaSprzedazy();
            OknoUmowaSprzedazy okno = new OknoUmowaSprzedazy(um); //inicjalizowanie okna

            this.Hide();
            bool? ret = okno.ShowDialog(); //wywołanie okna
            if (okno.IsActive == false)
            {
                this.Show();
            }

            if (ret == true)
            {
                umowy.DodajUmowe(um);
                umowy.ZapiszXML("listaUmowySprzedazy.xml");
            }
        }

        private void ButtonUmowaPosrednictwaKupna_Click(object sender, RoutedEventArgs e)
        {
            UmowyKupna umowy = new UmowyKupna();

            if (File.Exists("listaUmowyKupna.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                umowy = (UmowyKupna)UmowyKupna.OdczytajXML("listaUmowyKupna.xml"); // pliki o stalej nazwie, w ktorym przechowywane sa dane klientow
            }

            UmowaPosrednictwaKupna um = new UmowaPosrednictwaKupna();
            OknoUmowaKupna okno = new OknoUmowaKupna(um); //inicjalizowanie okna

            this.Hide();
            bool? ret = okno.ShowDialog(); //wywołanie okna
            if (okno.IsActive == false)
            {
                this.Show();
            }

            if (ret == true)
            {
                umowy.DodajUmowe(um);
                umowy.ZapiszXML("listaUmowyKupna.xml");
            }
        }
    }
}
