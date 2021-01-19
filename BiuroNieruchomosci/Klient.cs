using System;
namespace BiuroNieruchomosci
{

    /// <summary>
    /// Klasa zawierajaca pola oraz metody obiektu Klient. Dziedziczy po klasie Osoba 
    /// </summary>
    [Serializable]
    public class Klient : Osoba, IComparable<Klient>, IEquatable<Klient>
    {
        public Klient() : base()
        {

        }

        public Klient(string imie, string nazwisko, string PESEL, string dataUrodzenia) : base(imie, nazwisko, PESEL, dataUrodzenia)
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {

        }

        public Klient(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, string numermieszkania) : base(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu, numermieszkania)
        {

        }

        /// <summary>
        /// Porównuje bieżące wystąpienie z innym obiektem tego samego typu za pomoca atrybutu Nazwisko i zwraca liczbę całkowitą, która wskazuje, czy bieżące wystąpienie poprzedza,
        /// następuje po lub występuje w tym samym położeniu, co inny obiekt w porządku sortowania.
        /// Jesli zwracana wartosc = 0, porownywane jest biezace wystapienie z innym obiektem za pomoca atrybutu Imie.
        /// </summary>
        /// <param name="other">
        /// obiekt typu Klient
        /// </param>
        /// <returns>
        /// Mniej niż zero:	To wystąpienie poprzedza other w porządku sortowania.
        /// Zero: To wystąpienie występuje w tym samym położeniu w kolejności sortowania, jak other.
        /// Większe od zera: To wystąpienie następuje po other w kolejności sortowania.
        /// </returns>
        public int CompareTo(Klient other) 
        {
            int wynik = Nazwisko.CompareTo(other.Nazwisko);
            if (wynik != 0) 
            {
                return wynik;
            }
            return Imie.CompareTo(other.Imie);
        }

        /// <summary>
        /// Określa, czy dwa wystąpienia obiektu są takie same za pomoca atrybutu PESEL
        /// </summary>
        /// <param name="other">
        /// obiekt typu Klient
        /// </param>
        /// <returns>
        /// true Jeśli określony obiekt jest równy bieżącemu obiektowi; w przeciwnym razie false .
        /// </returns>
        public bool Equals(Klient other)
        {
            return PESEL.Equals(other.PESEL);
        }

        /// <summary>
        /// Nadpisanie metody ToString
        /// </summary>
        /// <returns>
        /// Atrybuty obiektu Klient: Imie, Nazwisko, NrTelefonu w formacie string
        /// </returns>
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, nr telefonu: {NrTelefonu}"; 
        }

    }
}
