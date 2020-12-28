using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Biuro_nieruchomosci
{
    public class Osoba
    {
        string _imie;
        string _nazwisko;
        DateTime _dataUrodzenia;
        string _PESEL;
        string _miejscowosc;
        string _ulica;
        string _numerDomu;
        int _numerMieszkania;
        string _email;
        string _nrTelefonu;


        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }

        public string NrTelefonu
        {
            get => _nrTelefonu;
            set
            {
                Regex wzorzec = new Regex("^\\d{9}$");
                if (wzorzec.IsMatch(value))
                {
                    _nrTelefonu = value;
                }

                else
                {
                    throw new FormatException();
                }
               
            }

        }

        public string PESEL
        {
            get => _PESEL;
            set
            {
                Regex wzorzec1 = new Regex("^\\d{11}$");
                if (wzorzec1.IsMatch(value))
                {
                    _PESEL = value;
                }

                else
                {
                    throw new FormatException();
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                Regex wzorzec2 = new Regex("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$");
                if (wzorzec2.IsMatch(value))
                {
                    _email = value;
                }
                
            }
        }

        public string Miejscowosc { get => _miejscowosc; set => _miejscowosc = value; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string NumerDomu { get => _numerDomu; set => _numerDomu = value; }
        public int NumerMieszkania { get => _numerMieszkania; set => _numerMieszkania = value; }
        

        public Osoba()
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            DataUrodzenia = DateTime.Now;
            PESEL = new string('0', 11);
            Miejscowosc = string.Empty;
            Ulica = string.Empty;
            NumerDomu = string.Empty;
            NumerMieszkania = 0;
            Email = string.Empty;
            NrTelefonu = new string('0', 9);
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string numerdomu, string email, string nrtelefonu):this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DateTime.TryParseExact(dataurodzenia, new[] {"dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataUrodzenia);
            PESEL = pesel;
            Miejscowosc = miejscowosc;
            NumerDomu = numerdomu;
            Email = email;
            NrTelefonu = nrtelefonu;
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {
            Ulica = ulica;
        }



        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, int numermieszkania):this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {
            NumerMieszkania = numermieszkania;
        }

        public override string ToString()
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            if (Ulica==null)
            {
                return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {NumerDomu} {Email} {NrTelefonu}";
            }

            if (NumerMieszkania==0)
            {
                return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {myTI.ToTitleCase(Ulica)} {NumerDomu} {Email} {NrTelefonu}";
            }
            return $"{myTI.ToTitleCase(Imie)} {myTI.ToTitleCase(Nazwisko)} {DataUrodzenia.ToString("dd-MM-yyyy")} {PESEL} {myTI.ToTitleCase(Miejscowosc)} {myTI.ToTitleCase(Ulica)} {NumerDomu}/{NumerMieszkania} {Email} {NrTelefonu}";

        }
    }
}
