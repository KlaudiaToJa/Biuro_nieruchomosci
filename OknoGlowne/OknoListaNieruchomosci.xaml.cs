using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy OknoListaNieruchomosci.xaml
    /// </summary>
    public partial class OknoListaNieruchomosci : Window
    {
        WszystkieNieruchomosci _caloscNieruchomosci;
        WszystkieNieruchomosci _nowaLista = new WszystkieNieruchomosci();


        public OknoListaNieruchomosci()
        {
            InitializeComponent();

            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _caloscNieruchomosci = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych nieruchomosci. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_caloscNieruchomosci is object)
            {
                listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_caloscNieruchomosci.ListaNieruchomosci);
            }

            ComboBoxTypNieruchomosci.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.TypNieruchomosci));
            ComboBoxTypTransakcji.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.TypTransakcji));
            ComboBoxRynek.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.Rynek));
            ComboBoxStandard.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.Standard));
            ComboBoxRodzajKuchni.ItemsSource = Enum.GetValues(typeof(Nieruchomosc.RodzajKuchni));
        }

        //filtrowanie zlozone
        private void ButtonFiltruj_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists("listaNieruchomosci.xml")) // sprawdzenie, czy plik został już utworzony - jesli tak, odczytuje
            {
                _nowaLista = (WszystkieNieruchomosci)WszystkieNieruchomosci.OdczytajXML("listaNieruchomosci.xml");
            }
            else
            {
                string message = "Nie znaleziono zadnych nieruchomosci. Sprobuj je najpierw dodac.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //otwiera wszystkie ify po kolei, zatem lista nieruchomosci bedzie sie aktualizowac z kazda kolejna :)
            if (textBoxMiejscowosc.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujMiejscowosc(textBoxMiejscowosc.Text);
            }
            if (textBoxCenaOd.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxCenaOd.Text, out pom)))
                {
                    string message = "Cena została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujCena(pom, 100000000); // maksymalna granica 100 milionow zl
            }
            if (textBoxCenaDo.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxCenaDo.Text, out pom)))
                {
                    string message = "Cena została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujCena(0, pom); // minimalna granica 0 zl
            }
            if (textBoxPowierzchniaOd.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxPowierzchniaOd.Text, out pom)))
                {
                    string message = "Powierzchnia została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujPowierzchnia(pom, 200000); // maksymalna ilosc to 200 tys m^2
            }
            if (textBoxPowierzchniaDo.Text != "")
            {
                double pom;
                if (!(double.TryParse(textBoxPowierzchniaDo.Text, out pom)))
                {
                    string message = "Powierzchnia została wpisana w złym formacie - być może użyto kropki zamiast przecinka?";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujPowierzchnia(0, pom); // maksymalna ilosc to 200 tys m^2
            }
            if (ComboBoxTypNieruchomosci.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujTypNieruchomosci((Nieruchomosc.TypNieruchomosci)ComboBoxTypNieruchomosci.SelectedItem);
            }
            if (ComboBoxTypTransakcji.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujTypTransakcji((Nieruchomosc.TypTransakcji)ComboBoxTypTransakcji.SelectedItem);
            }
            if (ComboBoxRynek.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujRynek((Nieruchomosc.Rynek)ComboBoxRynek.SelectedItem);
            }
            if (ComboBoxStandard.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujStandard((Nieruchomosc.Standard)ComboBoxRynek.SelectedItem);
            }
            if(textBoxIloscPokoi.Text != "")
            {
                int pom;
                if (!(int.TryParse(textBoxIloscPokoi.Text, out pom)))
                {
                    string message = "Loczba pokoi została wpisana w złym formacie.";
                    string title = "Błąd danych";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujIloscPokojow(pom);
            }
            if (ComboBoxRodzajKuchni.Text != "")
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujRodzajKuchni((Nieruchomosc.RodzajKuchni)ComboBoxRynek.SelectedItem);
            }
            if ((bool)CheckBoxBalkon.IsChecked)
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujBalkon();
            }
            if ((bool)CheckBoxParking.IsChecked)
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujParking();
            }
            if ((bool)CheckBoxUmeblowane.IsChecked)
            {
                _nowaLista.ListaNieruchomosci = _nowaLista.filtrujUmeblowane();
            }

            //po tych wszystkich ifach zamieniam widoczna liste w boxie na nowa:
            listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_nowaLista.ListaNieruchomosci);
        }

        private void ButtonWyczyscFiltry_Click(object sender, RoutedEventArgs e)
        {
            
           listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_caloscNieruchomosci.ListaNieruchomosci);
            
            textBoxMiejscowosc.Text = "";
            textBoxCenaOd.Text = "";
            textBoxCenaDo.Text = "";
            textBoxPowierzchniaOd.Text = "";
            textBoxPowierzchniaDo.Text = "";
            ComboBoxTypNieruchomosci.Text = "";
            ComboBoxTypTransakcji.Text = "";
            ComboBoxRynek.Text = "";
            ComboBoxStandard.Text = "";
            ComboBoxRodzajKuchni.Text = "";
            textBoxIloscPokoi.Text = "";
        }

        private void ButtonSortuj_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxOpcjeSortowania.Text == "Po cenie rosnaco")
            {
                _caloscNieruchomosci.SortujPoCenaRosnaco();
            }
            if (ComboBoxOpcjeSortowania.Text == "Po cenie malejaco")
            {
                _caloscNieruchomosci.SortujPoCenaMalejaco();
            }
            listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_caloscNieruchomosci.ListaNieruchomosci);
        }

        private void ButtonSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxNieruchomosci.SelectedIndex == -1)
            {
                string message = "Nie zaznaczono zadnej nieruchomosci.";
                string title = "Brak danych";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           Nieruchomosc n = listBoxNieruchomosci.SelectedItem as Nieruchomosc;
           
           OknoSzczegolyNieruchomosci okno = new OknoSzczegolyNieruchomosci(n);
           okno.ShowDialog();
        }

        private void ButtonUsunNieruchomosc_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxNieruchomosci.SelectedIndex == -1)
            {
                string mess = "Nie zaznaczono zadnej nieruchomosci.";
                string tit = "Brak zaznaczenia";
                MessageBox.Show(mess, tit, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Nieruchomosc k = (Nieruchomosc)listBoxNieruchomosci.SelectedItem;
            string message = $"Czy na pewno chcesz usunac nieruchomosc {k.IdNieruchomosci} {k.Miejscowosc} cena: {k.Cena:C}?";
            string title = "Usuwanie nieruchomosci";

            if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _caloscNieruchomosci.UsunNieruchomosc(k.IdNieruchomosci);
                _caloscNieruchomosci.ZapiszXML("listaNieruchomosci.xml");
                string m = "Pomyslnie usunieto nieruchomosc.";
                string t = "Sukces";
                listBoxNieruchomosci.ItemsSource = new ObservableCollection<Nieruchomosc>(_caloscNieruchomosci.ListaNieruchomosci);
                MessageBox.Show(m, t, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
