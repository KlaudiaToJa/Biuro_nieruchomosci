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
        DateTime _dataWystawienia;
        UmowaPosrednictwaSprzedazy _umowa;
        bool czyAktywna;

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
            _opis = opis;
            _umowa = umowa;
            _idOferty = $"{Umowa.NumerUmowy}/O{Numer}";
        }

        public void Archiwizuj()
        {
            this.czyAktywna = false;
        }

        public override string ToString()
        {
            return $"ID: {IdOferty} {_dataWystawienia.ToString("dd-MM-yyyy")}";
        }
    }
}
