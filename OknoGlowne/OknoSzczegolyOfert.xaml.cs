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
    /// <summary>
    /// Logika interakcji dla klasy OknoSzczegolyOfert.xaml
    /// </summary>
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

        //dodac mozliwosc edytowania!
    }
}
