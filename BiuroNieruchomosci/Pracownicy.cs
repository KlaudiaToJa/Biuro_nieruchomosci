using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;





namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa Pracownicy agreguje pracownikow (obiekty  typu Pracownik). 
    /// </summary>
    [Serializable]
    public class Pracownicy
    {
        List<Pracownik> _listaPracownikow = new List<Pracownik>();

        public List<Pracownik> ListaPracownikow { get => _listaPracownikow; set => _listaPracownikow = value; }

        public Pracownicy()
        {

        }

        /// <summary>
        /// Dodawanie obiektu typu pracownik do listy pracownikow
        /// </summary>
        /// <param name="p">
        /// Obiekt typu pracownik
        /// </param>
        public void DodajPracownika(Pracownik p)
        {
            ListaPracownikow.Add(p);
        }

        /// <summary>
        /// Usuwanie obiektu typu pracownik z listy pracownikow
        /// </summary>
        /// <param name="p">
        /// Obiekt typu Pracownik
        /// </param>
        public void UsunPracownika(Pracownik p)
        {
            foreach (Pracownik o in ListaPracownikow)
            {
                if (o.Equals(p))
                {
                    ListaPracownikow.Remove(o);
                    break;
                }
            }
        }

        /// <summary>
        /// Sprawdzanie po numerze PESEL czy Pracownik znajduje sie w bazie
        /// </summary>
        /// <param name="pesel">
        /// PESEL pracownika
        /// </param>
        /// <returns>
        /// True jesli Pracownik znajduje sie w bazie, False w przeciwnym wypadku
        /// </returns>
        public bool CzyJestWBazie(string pesel)
        {
            foreach (Pracownik k in ListaPracownikow)
            {
                if (k.PESEL == pesel)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Serializacja do XML
        /// </summary>
        /// <param name="plik">
        /// Nazwa pliku, w ktorym chcemy zapisac dokument XML.
        /// </param>
        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pracownicy)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }
        /// <summary>
        /// Deserializacja pliku XML
        /// </summary>
        /// <param name="plik">
        /// Plik, z ktorego chcemy deserializowac XML.
        /// </param>
        /// <returns>
        /// Zdeserializowany obiekt
        /// </returns>
        public static Pracownicy OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pracownicy));
                return (Pracownicy)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// Sortuje alfabetycznie nazwiska pracownikow za pomoca metody CompareTo()
        /// </summary>
        public void SortujNazwiskaImiona()
        {
            ListaPracownikow.Sort();
        }

        /// <summary>
        /// Sortuje alfabetycznie miejscowosci za pomoca Comparison: (x, y) => x.Miejscowosc.CompareTo(y.Miejscowosc))
        /// </summary>
        public void SortujMiejscowosciami()
        {
            ListaPracownikow.Sort((x, y) => x.Miejscowosc.CompareTo(y.Miejscowosc));
        }
    }
}
