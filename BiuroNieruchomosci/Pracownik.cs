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
        /// <summary>
        /// Porównuje bieżące wystąpienie z innym obiektem tego samego typu za pomoca atrybutu Nazwisko i zwraca liczbę całkowitą, która wskazuje, czy bieżące wystąpienie poprzedza,
        /// następuje po lub występuje w tym samym położeniu, co inny obiekt w porządku sortowania.
        /// Jesli zwracana wartosc = 0, porownywane jest biezace wystapienie z innym obiektem za pomoca atrybutu Imie.
        /// </summary>
        /// <param name="other">
        /// obiekt typu Pracownik
        /// </param>
        /// <returns>
        /// Mniej niż zero:	To wystąpienie poprzedza other w porządku sortowania.
        /// Zero: To wystąpienie występuje w tym samym położeniu w kolejności sortowania, jak other.
        /// Większe od zera: To wystąpienie następuje po other w kolejności sortowania.
        /// </returns>
        public int CompareTo(Pracownik other) //moze zwrocic 3 wartosci. porownuje 2 elementy i zwraca -1 jesli A<B 0 jesli A=B oraz 1 jesli A>B
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
        /// obiekt typu Pracownik
        /// </param>
        /// <returns>
        /// true Jeśli określony obiekt jest równy bieżącemu obiektowi; w przeciwnym razie false .
        /// </returns>
        public bool Equals(Pracownik other)
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
            return $"{Imie} {Nazwisko} {NrTelefonu}"; // potrzebne do odpowiedniego wyswietlania w combobox
        }


    }
}
