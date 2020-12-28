using System;
using System.Globalization;

namespace Biuro_nieruchomosci
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

        public static int Numer { get => _numer; set => _numer = value; }
        public string IdOferty { get => _idOferty; set => _idOferty = value; }
        public string Opis { get => _opis; set => _opis = value; }
        public DateTime DataWystawienia { get => _dataWystawienia; set => _dataWystawienia = value; }
        public Status Status1 { get => _status; set => _status = value; }

        public Oferta()
        {
            Opis = string.Empty;
            DataWystawienia = DateTime.Now;
            Numer++;
        }

        public Oferta (string opis, string dataWystawienia, Status status)
        {
            Opis = opis;
            DateTime.TryParseExact(dataWystawienia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataWystawienia);
            Status1 = status;
        }

        public override string ToString()
        {
            return $"{Status1} {IdOferty} {Opis} {_dataWystawienia.ToString("dd-MM-yyyy")}";
        }
    }
}
