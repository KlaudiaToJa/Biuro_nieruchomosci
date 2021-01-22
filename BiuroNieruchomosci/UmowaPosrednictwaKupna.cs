using System;
namespace BiuroNieruchomosci
{
    [Serializable]
    public class UmowaPosrednictwaKupna : Umowa
    {
        [NonSerialized]static int _numer;
        public string _nrUmowy;
        Klient _klient;

        public static int Numer { get => _numer; set => _numer = value; }
        public string NrUmowy { get => _nrUmowy; set => _nrUmowy = value; }
        public Klient Klient { get => _klient; set => _klient = value; }

        static UmowaPosrednictwaKupna()
       {
            _numer = 0;
       }
            
        public UmowaPosrednictwaKupna() : base()
        {
            ++Numer;
            NrUmowy = $"{Numer}/K/{DataZawarcia.Year}";
        }

        public UmowaPosrednictwaKupna(Pracownik opiekunKlienta, double prowizja, string dataZawarcia, string dataZakonczenia, Klient klient) :
            base(opiekunKlienta, prowizja, dataZawarcia, dataZakonczenia)
        {

        }
    }
}
