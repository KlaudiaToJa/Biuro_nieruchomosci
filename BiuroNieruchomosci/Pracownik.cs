using System;
namespace BiuroNieruchomosci
{
    [Serializable]
    public class Pracownik : Osoba, IComparable<Pracownik>, IEquatable<Pracownik>
    {
        public Pracownik() : base()
        {

        }

        public Pracownik(string imie, string nazwisko, string dataurodzenia, string pesel) : base(imie, nazwisko, dataurodzenia, pesel)
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

        public int CompareTo(Pracownik other) //moze zwrocic 3 wartosci. porownuje 2 elementy i zwraca -1 jesli A<B 0 jesli A=B oraz 1 jesli A>B
        {
            int wynik = Nazwisko.CompareTo(other.Nazwisko);
            if (wynik != 0)
            {
                return wynik;
            }
            return Imie.CompareTo(other.Imie);
        }

        public bool Equals(Pracownik other)
        {
            return PESEL.Equals(other.PESEL);
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {NrTelefonu}"; // potrzebne do odpowiedniego wyswietlania w combobox
        }


    }
}
