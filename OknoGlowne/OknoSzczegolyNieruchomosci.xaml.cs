using BiuroNieruchomosci;
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

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoSzczegolyNieruchomosci.xaml
    /// </summary>
    public partial class OknoSzczegolyNieruchomosci : Window
    {
       Nieruchomosc _nieruchomosc;
        public OknoSzczegolyNieruchomosci()
        {
            InitializeComponent();
        }

        public OknoSzczegolyNieruchomosci(Nieruchomosc n) : this()
        {
            _nieruchomosc = n; 
            if(n is object)
            {
                TextBoxMiekscowosc.Text = _nieruchomosc.Miejscowosc;
                TextBoxUlica.Text = _nieruchomosc.Ulica;
                TextBoxNumerDomu.Text = _nieruchomosc.NumerDomu;
                TextBoxNumerMieszkania.Text = _nieruchomosc.NumerMieszkania;
                TextBoxPowierzchnia.Text = _nieruchomosc.Powierzchnia.ToString();
                TextBoxLiczbaPokojow.Text = _nieruchomosc.LiczbaPokojow.ToString();
                TextBoxPietro.Text = _nieruchomosc.Pietro.ToString();
                TextBoxWysokoscOplat.Text = _nieruchomosc.WysokoscOplat.ToString();
                TextBoxTypNieruchomosci.Text = _nieruchomosc.TypNieruchomosci1.ToString();
                TextBoxRodzajNieruchomosci.Text = _nieruchomosc.RodzajNieruchomosci1.ToString();
                TextBoxTypTransakcji.Text = _nieruchomosc.TypTransakcji1.ToString();
                TextBoxStandard.Text = _nieruchomosc.Standard1.ToString();
                TextBoxRynek.Text = _nieruchomosc.Rynek1.ToString();
                TextBoxRodzajKuchni.Text = _nieruchomosc.RodzajKuchni1.ToString();
                TextBoxCena.Text = _nieruchomosc.Cena.ToString();
                if (_nieruchomosc.Balkon)
                    TextBoxBalkon.Text = "Tak";
                if (_nieruchomosc.Parking)
                    TextBoxParking.Text = "Tak";
                if (_nieruchomosc.Umeblowane)
                    TextBoxUmeblowane.Text = "Tak";
                TextBoxImie.Text = _nieruchomosc.Wlasciciel.Imie;
                TextBoxNazwisko.Text = _nieruchomosc.Wlasciciel.Nazwisko;
                TextBoxTelefon.Text = _nieruchomosc.Wlasciciel.NrTelefonu;
                TextBoxMail.Text = _nieruchomosc.Wlasciciel.Email;
            }
            
        }

        private void ButtonPowrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
