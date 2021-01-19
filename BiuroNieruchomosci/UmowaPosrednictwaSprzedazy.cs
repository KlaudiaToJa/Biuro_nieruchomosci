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
        static int _numer = 0;
        string _numerUmowy;

        public Nieruchomosc Nieruchomosc { get => _nieruchomosc; set => _nieruchomosc = value; }
        public static int Numer { get => _numer; set => _numer = value; }
        public string NumerUmowy { get => _numerUmowy; set => _numerUmowy = value; }

        public UmowaPosrednictwaSprzedazy() : base()
        {
            NumerUmowy = $"{Numer}/S/{DataZawarcia.Year}";
        }

        public UmowaPosrednictwaSprzedazy(Nieruchomosc nieruchomosc) : this()
        {
            Nieruchomosc = nieruchomosc;
        }
    }
}
