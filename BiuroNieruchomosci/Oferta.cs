using System;
using System.Globalization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Oferta
    {
        static int _numer = 0;
        string _idOferty;
        string _opis;
        public DateTime _dataWystawienia;
        public UmowaPosrednictwaSprzedazy _umowa;
        public bool czyAktywna;

        public static int Numer { get => _numer; set => _numer = value; }
        public string IdOferty { get => _idOferty; }
        public string Opis { get => _opis; set => _opis = value; }
        public DateTime DataWystawienia { get => _dataWystawienia; set => _dataWystawienia = value; }
        public UmowaPosrednictwaSprzedazy Umowa { get => _umowa; set => _umowa = value; }
        public bool CzyAktywna { get => czyAktywna; set => czyAktywna = value; }

        public Oferta()
        {
            Opis = string.Empty;
            DataWystawienia = DateTime.Now;
            Numer++;
            this.czyAktywna = true;

        }

        public Oferta(string opis, UmowaPosrednictwaSprzedazy umowa)
        {
            Opis = opis;
            Umowa = umowa;
            _idOferty = $"{Umowa.NumerUmowy}/O{Numer}";
        }

        public void Archiwizuj()
        {
            CzyAktywna = false;
        }

        public override string ToString()
        {
            return $"ID: {IdOferty} Data wystawienia: {DataWystawienia.ToString("dd-MM-yyyy")} Opis: {Opis} ";
        }
    }
}
