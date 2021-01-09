using System;
namespace BiuroNieruchomosci
{
    [Serializable]
    public class Pracownik : Osoba
    {
        public Pracownik() : base()
        {

        }

        public Pracownik(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {

        }

        public Pracownik(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {

        }

        public Pracownik(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, string numermieszkania) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu, numermieszkania)
        {

        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {NrTelefonu}"; // potrzebne do odpowiedniego wyswietlania w combobox
        }


    }
}
