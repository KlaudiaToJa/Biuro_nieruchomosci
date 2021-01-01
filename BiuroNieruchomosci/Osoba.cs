using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Osoba
    {
        string _imie;
        string _nazwisko;
        DateTime _dataUrodzenia;
        string _PESEL;
        string _miejscowosc;
        string _ulica;
        string _numerDomu;
        string _numerMieszkania;
        string _email;
        string _nrTelefonu;


        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }

        public string Email
        {
            get => _email;
            set
            {
                Regex wzorzec2 = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
                if (wzorzec2.IsMatch(value))
                {
                    _email = value;
                }

            }
        }

        public string Miejscowosc { get => _miejscowosc; set => _miejscowosc = value; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string NumerDomu { get => _numerDomu; set => _numerDomu = value; }
        public string NumerMieszkania { get => _numerMieszkania; set => _numerMieszkania = value; }
        public string NrTelefonu { get => _nrTelefonu; set => _nrTelefonu = value; }
        public string PESEL { get => _PESEL; set => _PESEL = value; }

        public Osoba()
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            DataUrodzenia = DateTime.Now;
            PESEL = new string('0', 11);
            Miejscowosc = string.Empty;
            Ulica = string.Empty;
            NumerDomu = string.Empty;
            NumerMieszkania = string.Empty;
            Email = string.Empty;
            NrTelefonu = new string('0', 9);
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string Pesel) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            PESEL = Pesel;
            DateTime.TryParseExact(dataUrodzenia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataUrodzenia);
        }

        public Osoba(string imie, string nazwisko, string pesel, string dataUrodzenia, string miejscowosc, string numerdomu, string email, string nrtelefonu) : this(imie, nazwisko, dataUrodzenia, pesel)
        {
            Miejscowosc = miejscowosc;
            NumerDomu = numerdomu;
            Email = email;
            NrTelefonu = nrtelefonu;
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {
            Ulica = ulica;
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, string numermieszkania) : this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {
            NumerMieszkania = numermieszkania;
        }


        //TO MOZE BYC DO POPRAWKI BO NIE WIEM CZY BEDZIE OKEJ JAK UZYJEMY NIEZNANYCH METOD XD
        public override string ToString()
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            if (Ulica == null)
            {
                return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {NumerDomu} {Email} {NrTelefonu}";
            }

            if (NumerMieszkania == "")
            {
                return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {myTI.ToTitleCase(Ulica)} {NumerDomu} {Email} {NrTelefonu}";
            }
            return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {myTI.ToTitleCase(Ulica)} {NumerDomu}/{NumerMieszkania} {Email} {NrTelefonu}";

        }
    }
}
