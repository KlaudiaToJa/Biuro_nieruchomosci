using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class OknoSzczegolyOfert : Window
    {
        Oferta _oferta = new Oferta();

        public OknoSzczegolyOfert()
        {
            InitializeComponent();
        }

        public OknoSzczegolyOfert(Oferta o) : this()
        {
            _oferta = o;
            txtBoxDataWystawienia.Text = _oferta.DataWystawienia.ToString("dd-MM-yyyy");
            txtBoxIdOferty.Text = _oferta.IdOferty;
            if (_oferta.CzyAktywna)
            {
                txtBoxStatus.Text = "Aktywna";
            }
            else
            {
                txtBoxStatus.Text = "Zakonczona";
            }
            txtBoxOpis.Text = _oferta.Opis;
        }

        private void buttonSzczegolyNieruchomosci_Click(object sender, RoutedEventArgs e)
        {
            OknoSzczegolyNieruchomosci okno = new OknoSzczegolyNieruchomosci(_oferta.Umowa.Nieruchomosc);

            this.Hide();
            bool? ret = okno.ShowDialog(); //wywołanie okna
            if (okno.IsActive == false)
            {
                this.Show();
            }
          
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAktualizuj_Click(object sender, RoutedEventArgs e)
        {
            string mess = "Czy na pewno chcesz edytowac dane?";
            string tit = "Edycja danych";
            if(MessageBox.Show(mess, tit, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _oferta.Opis = txtBoxOpis.Text;
            }
            MessageBox.Show("Zaktualizowano opis.", "Sukces!", MessageBoxButton.OK);
            DialogResult = true;
        }
    }
}
