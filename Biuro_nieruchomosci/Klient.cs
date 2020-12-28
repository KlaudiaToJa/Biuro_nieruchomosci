using System;
namespace Biuro_nieruchomosci
{
    public class Klient:Osoba
    {
        public Klient():base()
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, int numermieszkania) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu, numermieszkania)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
