using System;
using System.Globalization;

namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa zawierajaca pola oraz metody obiektu Oferta.
    /// </summary>
    [Serializable]
    public class Oferta : ICloneable
    {
        public string _idOferty;
        string _opis;
        public DateTime _dataWystawienia;
        public UmowaPosrednictwaSprzedazy _umowa;
        public bool czyAktywna;
       [NonSerialized] private static int _numer;

        public static int Numer { get => _numer; set => _numer = value; }
        public string IdOferty { get => _idOferty; }
        public string Opis { get => _opis; set => _opis = value; }
        public DateTime DataWystawienia { get => _dataWystawienia; set => _dataWystawienia = value; }
        public UmowaPosrednictwaSprzedazy Umowa { get => _umowa; set => _umowa = value; }
        public bool CzyAktywna { get => czyAktywna; set => czyAktywna = value; }

        static Oferta()
        {
            Numer = 0;
        }

        public Oferta()
        {
            Opis = string.Empty;
            DataWystawienia = DateTime.Now;
            ++Numer;
            _idOferty = $"{Numer}/O/{DateTime.Now.Year}";
            CzyAktywna = true;
        }

        public Oferta(string opis, UmowaPosrednictwaSprzedazy umowa)
        {
            Opis = opis;
            Umowa = umowa;
            
        }
        /// <summary>
        /// Archiwizowanie oferty poprzed przypisanie polu CzyAktywna wartosci false
        /// </summary>
        public void Archiwizuj()
        {
            CzyAktywna = false;
        }

        /// <summary>
        /// Nadpisanie metody ToString
        /// </summary>
        /// <returns>
        /// Atrybuty obiektu Klient: IdOferty, DataWystawienia, Opis w formacie string
        /// </returns>
        public override string ToString()
        {
            return $"ID: {IdOferty} Data wystawienia: {DataWystawienia.ToString("dd-MM-yyyy")} Opis: {Opis} ";
        }

        public object Clone()
        {
            return MemberwiseClone(); //skopiuje wszystkie elementy, ktore sa w klasie; stworzy obiekt o takich samych wartoscia pól
        }
    }
}
