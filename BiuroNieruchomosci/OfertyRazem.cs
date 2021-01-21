using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa OfertyRazem agreguje oferty (obiekty Oferta). 
    /// </summary>
    [Serializable]
    public class OfertyRazem : IOferuje
    {
        List<Oferta> _listaOfert = new List<Oferta>();
        public List<Oferta> ListaOfert { get => _listaOfert; set => _listaOfert = value; }

        public OfertyRazem()
        {
            
        }

        /// <summary>
        /// Dodawanie obiektu typu Oferta do listy ofert
        /// </summary>
        /// <param name="o">
        /// obiekt typu Oferta
        /// </param>
        public void DodajOferte(Oferta o)
        {
            ListaOfert.Add(o);
        }

        /// <summary>
        /// Usuwanie obiektu typu oferta z listy ofert
        /// </summary>
        /// <param name="idOferty">
        /// string zawierajacy id oferty, ktora chcemy usunac
        /// </param>
        public void UsunOferte(string idOferty)
        {
            Oferta oferta = new Oferta();
            foreach (Oferta o in ListaOfert)
            {
                if (o.IdOferty == idOferty)
                {
                    oferta = o;
                }
            }
            ListaOfert.Remove(oferta);
        }

        /// <summary>
        /// Serializacja do XML
        /// </summary>
        /// <param name="plik">
        /// Nazwa pliku, w ktorym chcemy zapisac dokument XML.
        /// </param>
        public void ZapiszXMLOferty(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OfertyRazem)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }


        /// <summary>
        /// Deserializacja dokumentu XML
        /// </summary>
        /// <param name="plik">
        /// Plik, z ktorego chcemy deserializowac XML.
        /// </param>
        /// <returns>
        /// Zdeserializowany obiekt
        /// </returns>
        public static OfertyRazem OdczytajXMLOferty (string plik)
        {
            if (File.Exists(plik))
            {
                OfertyRazem oferty = new OfertyRazem();
                using (StreamReader reader = new StreamReader(plik))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OfertyRazem));
                    oferty =  (OfertyRazem)serializer.Deserialize(reader);
                    if (!oferty._listaOfert.Count.Equals(0))
                    {
                        int liczba_znakow = oferty._listaOfert[oferty._listaOfert.Count - 1]._idOferty.IndexOf("/");
                        string id_ostatnie = oferty._listaOfert[oferty._listaOfert.Count - 1]._idOferty.Substring(0, liczba_znakow);
                        int numer_pom;
                        int.TryParse(id_ostatnie, out numer_pom);
                        Oferta.Numer = numer_pom;
                    }
                }
                return oferty;
            }
            return null;
        }

        /// <summary>
        /// Filtrowanie listy po imieniu klienta
        /// </summary>
        /// <param name="imie">
        /// Szukane imie
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty
        /// </returns>
        public List<Oferta> filtrujImieKlienta(string imie)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach(Oferta oferta in ListaOfert)
            {
                if(oferta.Umowa.Klient.Imie.ToUpper() == imie.ToUpper())
                {
                    wyniki.Add(oferta);
                    
                }
            }
            return wyniki;
        }

        /// <summary>
        /// Filtrowanie listy po nazwisku klienta
        /// </summary>
        /// <param name="nazwisko">
        /// Szukane nazwisko
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty
        /// </returns>
        public List<Oferta> filtrujNazwiskoKlienta(string nazwisko)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach(Oferta oferta in ListaOfert)
            {
                if(oferta.Umowa.Klient.Nazwisko.ToUpper() == nazwisko.ToUpper())
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        /// <summary>
        /// Filtrowanie listy po wskazane dacie
        /// </summary>
        /// <param name="data">
        /// Szukana data
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty
        /// </returns>
        public List<Oferta> filtrujDate(string data)
        {
            
            List<Oferta> wyniki = new List<Oferta>();
            DateTime dataFiltr;
            DateTime.TryParseExact(data, new[] { "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataFiltr);
            foreach (Oferta oferta in ListaOfert)
            {
                if ((oferta.DataWystawienia.Year == dataFiltr.Year && oferta.DataWystawienia.Month == dataFiltr.Month || oferta.DataWystawienia == dataFiltr))
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        /// <summary>
        /// Filtrowanie listy po imieniu opiekuna klienta
        /// </summary>
        /// <param name="imie">
        /// Szukane imie opiekuna klienta
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty
        /// </returns>
        public List<Oferta> filtrujImieOpiekuna(string imie)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach (Oferta oferta in ListaOfert)
            {
                if (oferta.Umowa.OpiekunKlienta.Imie.ToUpper() == imie.ToUpper())
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        /// <summary>
        /// Filtrowanie listy po nazwisku opiekuna klienta
        /// </summary>
        /// <param name="nazwisko">
        /// Szukane nazwisko opiekuna klienta
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty 
        /// </returns>
        public List<Oferta> filtrujNazwiskoOpiekuna(string nazwisko)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach (Oferta oferta in ListaOfert)
            {
                if (oferta.Umowa.OpiekunKlienta.Nazwisko.ToUpper() == nazwisko.ToUpper())
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        /// <summary>
        /// Wyswietla liste wszystkich ofert o danym parametrze aktywnosci
        /// </summary>
        /// <param name="czyAktywna">
        /// Okresla czy oferta jest aktywna. true = oferta aktywna; false = oferta nieaktywna
        /// </param>
        /// <returns>
        /// Lista ofert List Oferta
        /// </returns>
        public List<Oferta> PrzegladajOferty(bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach (Oferta oferta in ListaOfert)
            {
                if (oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }



        /// <summary>
        /// Sortuje alfabetycznie miejscowosci za pomoca Comparison: (x, y) => x.Umowa.Nieruchomosc.Miejscowosc.CompareTo(y.Miejscowosc))
        /// </summary>
        public void SortujMiejscowosciami()
        {
            ListaOfert.Sort((x, y) => x.Umowa.Nieruchomosc.Miejscowosc.CompareTo(y.Umowa.Nieruchomosc.Miejscowosc));
           
        }
    }
}


