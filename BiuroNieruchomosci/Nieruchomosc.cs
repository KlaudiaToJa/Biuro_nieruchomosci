using System;
namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa zawierajaca pola oraz metody obiektu Nieruchomosc.
    /// </summary>
    public class Nieruchomosc : IComparable<Nieruchomosc>
    {
        public enum TypNieruchomosci { Mieszkanie, Działka, Dom, Lokal, Magazyn, Obiekt }
        public enum RodzajNieruchomosci { WłasnośćHipoteczna, PrawoWłasnościoweBezKsięgiWieczystej, PrawoWłasnościoweZKsięgą }
        public enum TypTransakcji { Sprzedaż, Wynajem }
        public enum RodzajKuchni { Aneks, Oddzielna }
        public enum Standard { Wysoki, DoOdświeżenia, DoRemontu, PodKlucz, StanDeweloperski, StanSurowy }
        public enum Rynek { Wtórny, Pierwotny }

        private static int numer;

        string _idNieruchomosci;
        string _ulica;
        string _miejscowosc;
        string _numerDomu;
        string _numerMieszkania;
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
        RodzajKuchni _rodzajKuchni;
        Klient _wlasciciel;

        public Klient Wlasciciel { get => _wlasciciel; set => _wlasciciel = value; }
        public string IdNieruchomosci { get => _idNieruchomosci; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string Miejscowosc { get => _miejscowosc; set => _miejscowosc = value; }
        public string NumerDomu { get => _numerDomu; set => _numerDomu = value; }
        public string NumerMieszkania { get => _numerMieszkania; set => _numerMieszkania = value; }
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
        public RodzajKuchni RodzajKuchni1 { get => _rodzajKuchni; set => _rodzajKuchni = value; }
        public static int Numer { get => numer; set => numer = value; }

        static Nieruchomosc()
        {
            Numer = 0;
        }
        public Nieruchomosc()
        {
            ++Numer;
            _idNieruchomosci = $"{Numer}/{DateTime.Now.Year}";
        }

       
        public Nieruchomosc(Klient wlasciciel, string miejscowosc, string ulica, string numerDomu,
            string numerMieszkania, double cena, double powierzchnia, int liczbaPokojow, int pietro,
            bool balkon, bool umeblowane, bool parking, double wysokoscOplat, TypNieruchomosci typNieruchomosci,
            RodzajNieruchomosci rodzajNieruchomosci, TypTransakcji typTransakcji, Standard standard, Rynek rynek, RodzajKuchni rodzajKuchni):this()
        { 
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
            RodzajKuchni1 = rodzajKuchni;
        }

        /// <summary>
        /// Nadpisanie metody ToString
        /// </summary>
        /// <returns>
        /// Atrybuty obiektu Nieruchomosc: _idNieruchomosci, Miejscowosc, Ulica, NumerDomu, Numer Mieszkania, Powierzchnia, Cena w formacie string
        /// </returns>
        public override string ToString()
        {
            return $"{_idNieruchomosci} {Miejscowosc} ul. {Ulica} {NumerDomu}/{NumerMieszkania}, {Powierzchnia} m^2, cena: {Cena:C}";
        }

        /// <summary>
        /// Porównuje bieżące wystąpienie z innym obiektem tego samego typu za pomoca atrybutu Cena i zwraca liczbę całkowitą, która wskazuje, czy bieżące wystąpienie poprzedza,
        /// następuje po lub występuje w tym samym położeniu, co inny obiekt w porządku sortowania.
        /// 
        /// </summary>
        /// <param name="other">
        /// obiekt typu Nieruchomosc
        /// </param>
        /// <returns>
        /// Mniej niż zero:	To wystąpienie poprzedza other w porządku sortowania. 
        /// Zero: To wystąpienie występuje w tym samym położeniu w kolejności sortowania, jak other.
        /// Większe od zera: To wystąpienie następuje po other w kolejności sortowania.
        /// </returns>
        public int CompareTo(Nieruchomosc other)
        {
            return _cena.CompareTo(other.Cena);
        }
    }
}
