using System;
namespace BiuroNieruchomosci
{
    [Serializable]
    public class UmowaPosrednictwaKupna : Umowa
    {
        [NonSerialized]static int _numer;
        public string _nrUmowy;

        public static int Numer { get => _numer; set => _numer = value; }
        public string NrUmowy { get => _nrUmowy; set => _nrUmowy = value; }

        static UmowaPosrednictwaKupna()
       {
            _numer = 0;
       }
            
        public UmowaPosrednictwaKupna() : base()
        {
            Numer = Numer++;
            NrUmowy = $"{Numer}/K/{DataZawarcia.Year}";
        }
    }
}
