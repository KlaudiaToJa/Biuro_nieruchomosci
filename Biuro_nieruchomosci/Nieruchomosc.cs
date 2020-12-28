using System;
namespace Biuro_nieruchomosci
{
    public class Nieruchomosc
    {
        public enum TypNieruchomosci { mieszkanie, dzialka, dom, lokal, magazyn, obiekt }
        public enum RodzajNieruchomosci { wlasnoscHipoteczna, prawoWlasnoscioweBezKsiegi, prawoWlasnoscioweZKsiega }
        public enum TypTransakcji { sprzedaz, wynajem }
        public enum RodzajKuchni { aneks, oddzielna }
        public enum Standard { wysoki, doOdswiezenia, doRemontu, podKlucz, stanDeweloperski, stanSurowy }
        public enum Rynek { wtorny, pierwotny }

        static int _numer = 0;

        //Klient _wlasciciel;
        string _idNieruchomosci;
        string _ulica;
        string _miejscowosc;
        string _numerDomu;
        int _numerMieszkania;
        double _cena;
        double _powierzchnia;
        int _liczbaPokojow;
        int _pietro;
        bool _balkon;
        bool _umeblowane;
        bool _parking;
        double _wysokoscOplat;
        TypNieruchomosci _typNieruchomosci;
        RodzajNieruchomosci _rodzajNieruchomosci;
        TypTransakcji _typTransakcji;
        Standard _standard;
        Rynek _rynek;
        Klient _wlasciciel;

        public Klient Wlasciciel { get => _wlasciciel; set => _wlasciciel = value; }
        public string IdNieruchomosci { get => _idNieruchomosci; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string Miejscowosc { get => _miejscowosc; set => _miejscowosc = value; }
        public string NumerDomu { get => _numerDomu; set => _numerDomu = value; }
        public int NumerMieszkania { get => _numerMieszkania; set => _numerMieszkania = value; }
        public double Cena { get => _cena; set => _cena = value; }
        public double Powierzchnia { get => _powierzchnia; set => _powierzchnia = value; }
        public int LiczbaPokojow { get => _liczbaPokojow; set => _liczbaPokojow = value; }
        public int Pietro { get => _pietro; set => _pietro = value; }
        public bool Balkon { get => _balkon; set => _balkon = value; }
        public bool Umeblowane { get => _umeblowane; set => _umeblowane = value; }
        public bool Parking { get => _parking; set => _parking = value; }
        public double WysokoscOplat { get => _wysokoscOplat; set => _wysokoscOplat = value; }
        public TypNieruchomosci TypNieruchomosci1 { get => _typNieruchomosci; set => _typNieruchomosci = value; }
        public RodzajNieruchomosci RodzajNieruchomosci1 { get => _rodzajNieruchomosci; set => _rodzajNieruchomosci = value; }
        public TypTransakcji TypTransakcji1 { get => _typTransakcji; set => _typTransakcji = value; }
        public Standard Standard1 { get => _standard; set => _standard = value; }
        public Rynek Rynek1 { get => _rynek; set => _rynek = value; }

        public Nieruchomosc()
        {

        }

        // nie tworze dodatkowego konstruktora, bo da sie w GUI uzupelniac to ladnie nullami :)
        public Nieruchomosc(Klient wlasciciel, string miejscowosc, string ulica, string numerDomu,
            int numerMieszkania, double cena, double powierzchnia, int liczbaPokojow, int pietro,
            bool balkon, bool umeblowane, bool parking, double wysokoscOplat, TypNieruchomosci typNieruchomosci,
            RodzajNieruchomosci rodzajNieruchomosci, TypTransakcji typTransakcji, Standard standard, Rynek rynek)
        {
            ++_numer;
            _idNieruchomosci = $"{_numer}/{DateTime.Now.Year}";
            Wlasciciel = wlasciciel;
            Miejscowosc = miejscowosc;
            Ulica = ulica;
            NumerDomu = numerDomu;
            NumerMieszkania = numerMieszkania;
            Cena = cena;
            Powierzchnia = powierzchnia;
            LiczbaPokojow = liczbaPokojow;
            Pietro = pietro;
            Balkon = balkon;
            Umeblowane = umeblowane;
            Parking = parking;
            WysokoscOplat = wysokoscOplat;
            TypNieruchomosci1 = typNieruchomosci;
            RodzajNieruchomosci1 = rodzajNieruchomosci;
            TypTransakcji1 = typTransakcji;
            Standard1 = standard;
            Rynek1 = rynek;
        }

        public override string ToString()
        {
            return IdNieruchomosci.ToString();
        }
    }
}
