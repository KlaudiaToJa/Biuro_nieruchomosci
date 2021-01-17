using System;
using System.Globalization;

namespace BiuroNieruchomosci
{
    public class Oferta
    {
        public enum Status
        {
            aktywna,
            zawieszona,
            zakonczona
        }

        static int _numer = 0;
        string _idOferty;                   /*nw z czego ma powstać id :/ */
        string _opis;
        DateTime _dataWystawienia;
        Status _status;
        UmowaPosrednictwaSprzedazy _umowa;
        bool czyAktywna;

        public static int Numer { get => _numer; set => _numer = value; }
        public string IdOferty { get => _idOferty; set => _idOferty = value; }
        public string Opis { get => _opis; set => _opis = value; }
        public DateTime DataWystawienia { get => _dataWystawienia; set => _dataWystawienia = value; }
        public Status Status1 { get => _status; set => _status = value; }
        public UmowaPosrednictwaSprzedazy Umowa { get => _umowa; set => _umowa = value; }
        public bool CzyAktywna { get => czyAktywna; set => czyAktywna = value; }

        public Oferta()
        {
            Opis = string.Empty;
            DataWystawienia = DateTime.Now;
            Numer++;
            this.czyAktywna = true;
        }

        public Oferta(string opis,string dataWystawienia, Status status, UmowaPosrednictwaSprzedazy umowa)
        {
            _opis = opis;
            DateTime.TryParseExact(dataWystawienia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataWystawienia);
            _status = status;
            _umowa = umowa;
        }

  
        public void Archiwizuj()
        {
            this.czyAktywna = false;
        }


        public override string ToString()
        {
            return $"{Status1} {IdOferty} {Opis} {_dataWystawienia.ToString("dd-MM-yyyy")}";
        }
    }
}
