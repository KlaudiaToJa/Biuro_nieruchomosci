using System;
namespace BiuroNieruchomosci
{
    [Serializable]
    public class UmowaPosrednictwaKupna : Umowa
    {
        static int _numer = 0;
        string _nrUmowy;

        public static int Numer { get => _numer; set => _numer = value; }
        public string NrUmowy { get => _nrUmowy; set => _nrUmowy = value; }

        public UmowaPosrednictwaKupna() : base()
        {
            Numer = Numer + 1;
            NrUmowy = $"{Numer}/K/{DataZawarcia.Year}";
        }
    }
}
