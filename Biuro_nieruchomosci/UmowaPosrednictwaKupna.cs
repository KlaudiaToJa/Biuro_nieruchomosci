using System;
namespace Biuro_nieruchomosci
{
    public class UmowaPosrednictwaKupna:Umowa
    {
        Klient _nabywca;
        static int _numer = 0;
        string _nrUmowy;

        public Klient Nabywca { get => _nabywca; set => _nabywca = value; }
        public static int Numer { get => _numer; set => _numer = value; }
        public string NrUmowy { get => _nrUmowy; set => _nrUmowy = value; }

        public UmowaPosrednictwaKupna()
        {
            Numer = Numer + 1;
            NrUmowy = $"{Numer}/K/{DataZawarcia.Year}";
        }
    }
}
