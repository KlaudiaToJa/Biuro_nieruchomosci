using System;
namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa UmowaPosrednictwaSprzedazy dziedziczy po klasie Umowa oraz komponuje obiekty typu Nieruchomosc.
    /// </summary>
    [Serializable]
    public class UmowaPosrednictwaSprzedazy : Umowa
    {
        Nieruchomosc _nieruchomosc;
        [NonSerialized]static int _numer;
        public string _numerUmowy;

        public Nieruchomosc Nieruchomosc { get => _nieruchomosc; set => _nieruchomosc = value; }
        public static int Numer { get => _numer; set => _numer = value; }
        public string NumerUmowy { get => _numerUmowy; set => _numerUmowy = value; }

        static UmowaPosrednictwaSprzedazy()
        {
            _numer = 0;
        }
        public UmowaPosrednictwaSprzedazy() : base()
        {
            Numer++;
            NumerUmowy = $"{Numer}/S/{DataZawarcia.Year}";
        }

        public UmowaPosrednictwaSprzedazy(Nieruchomosc nieruchomosc) : this()
        {
            Nieruchomosc = nieruchomosc;
        }
    }
}
