using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{

    /// <summary>
    /// Klasa WszystkieNieruchomosci agreguje obiekty typu Nieruchomosc.
    /// </summary>
    [Serializable]
    public class WszystkieNieruchomosci
    {
        List<Nieruchomosc> listaNieruchomosci;

        public List<Nieruchomosc> ListaNieruchomosci { get => listaNieruchomosci; set => listaNieruchomosci = value; }        
        
        public WszystkieNieruchomosci()
        {
            ListaNieruchomosci = new List<Nieruchomosc>();
        }

        /// <summary>
        /// Dodawanie obiektu typu Nieruchomosc do listy nieruchomosci
        /// </summary>
        /// <param name="n">
        /// Obiekt typu Nieruchomosc
        /// </param>
        public void DodajNieruchomosc(Nieruchomosc n)
        {
            ListaNieruchomosci.Add(n);
        }

        /// <summary>
        /// Usuwanie nieruchomosci z listy
        /// </summary>
        /// <param name="idUsuwanej">
        /// Id usuwanej nieruchomosci
        /// </param>
        public void UsunNieruchomosc(string idUsuwanej)
        {
            // znalezienie nieruchomosci z podanym id:
            int index = ListaNieruchomosci.FindIndex(item => item.IdNieruchomosci == idUsuwanej);
            if (index >= 0) // jesli taki element istnieje
            {
                ListaNieruchomosci.RemoveAt(index);
            }
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
                XmlSerializer serializer = new XmlSerializer(typeof(WszystkieNieruchomosci)); //tworzymy serializator xml
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
        public static WszystkieNieruchomosci OdczytajXML(string plik)
        {
            if (File.Exists(plik))
            {
                WszystkieNieruchomosci wszystkieNieruchomosci = new WszystkieNieruchomosci();
                using (StreamReader reader = new StreamReader(plik))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(WszystkieNieruchomosci));
                    wszystkieNieruchomosci = (WszystkieNieruchomosci)serializer.Deserialize(reader);
                    if(!wszystkieNieruchomosci.listaNieruchomosci.Count.Equals(0))
                    {
                        int liczba_znakow = wszystkieNieruchomosci.listaNieruchomosci[wszystkieNieruchomosci.listaNieruchomosci.Count - 1].IdNieruchomosci.IndexOf("/");
                        string id_ostatnie = wszystkieNieruchomosci.listaNieruchomosci[wszystkieNieruchomosci.listaNieruchomosci.Count - 1].IdNieruchomosci.Substring(0, liczba_znakow);
                        int numer_pom;
                        int.TryParse(id_ostatnie, out numer_pom);
                        Nieruchomosc.Numer = numer_pom;
                    }
                }
                return wszystkieNieruchomosci;
            }
            return null;
        }



        /// <summary>
        /// Filtrowanie listy po wskazanym przedziale cenowym
        /// </summary>
        /// <param name="cenaDolna">
        /// Dolny przedzial ceny
        /// </param>
        /// <param name="cenaGorna">
        /// Gorny przedzial ceny
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujCena(double cenaDolna, double cenaGorna)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach(Nieruchomosc n in listaNieruchomosci)
            {
                if(n.Cena >= cenaDolna && n.Cena <= cenaGorna)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanej ilosci pokojow
        /// </summary>
        /// <param name="ilosc">
        /// Ilosc pokojow
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujIloscPokojow(int ilosc)
        {
            return listaNieruchomosci.FindAll(il => il.LiczbaPokojow.Equals(ilosc));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanej miejscowosci
        /// </summary>
        /// <param name="miejscowosc">
        /// Miejscowosc nieruchomosci
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujMiejscowosc(string miejscowosc)
        {
            return listaNieruchomosci.FindAll(m => m.Miejscowosc.Equals(miejscowosc));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanym przedziale metrazu danej nieruchomosci
        /// </summary>
        /// <param name="powierzchniaDolna">
        /// Dolny zakres szukanego metrazu
        /// </param>
        /// <param name="powierzchniaGorna">
        /// Gorny zakres szukanego metrazu
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujPowierzchnia(double powierzchniaDolna, double powierzchniaGorna)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.Powierzchnia >= powierzchniaDolna && n.Powierzchnia <= powierzchniaGorna)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanym typie nieruchomosci
        /// </summary>
        /// <param name="typ">
        /// Obiekt typu Nieruchomosc.TypNieruchomosci
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujTypNieruchomosci(Nieruchomosc.TypNieruchomosci typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypNieruchomosci1.Equals(typ));
        }

        /// <summary>
        ///  Filtrowanie listy List(Nieruchomosc) po wskazanym typie transakcji
        /// </summary>
        /// <param name="typ">
        /// Obiekt typu Nieruchomosc.TypTransakcji
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujTypTransakcji(Nieruchomosc.TypTransakcji typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypTransakcji1.Equals(typ));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanym standardzie nieruchomosci
        /// </summary>
        /// <param name="typ">
        /// Obiekt typu Nieruchomosc.Standard
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujStandard(Nieruchomosc.Standard typ)
        {
            return listaNieruchomosci.FindAll(t => t.Standard1.Equals(typ));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanym rynku nieruchomosci
        /// </summary>
        /// <param name="typ">
        /// Obiekt typu Nieruchomosc.Rynek
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujRynek(Nieruchomosc.Rynek typ)
        {
            return listaNieruchomosci.FindAll(r => r.Rynek1.Equals(typ));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) po wskazanym rodzaju kuchni
        /// </summary>
        /// <param name="typ">
        /// Obiekt typu Nieruchomosc.RodzajKuchni
        /// </param>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujRodzajKuchni(Nieruchomosc.RodzajKuchni typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypNieruchomosci1.Equals(typ));
        }

        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) w zaleznosci od tego czy w nieruchomosci jest balkon
        /// </summary>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujBalkon()
        { 
            return listaNieruchomosci.FindAll(t => t.Balkon.Equals(true));
        }
        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) w zaleznosci od tego czy w nieruchomosci jest parking
        /// </summary>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujParking()
        {
            return listaNieruchomosci.FindAll(t => t.Parking.Equals(true));
        }
        /// <summary>
        /// Filtrowanie listy List(Nieruchomosc) w zaleznosci od tego czy nieruchomosc jest umeblowana
        /// </summary>
        /// <returns>
        /// Zwraca odfiltrowana liste typu List(Nieruchomosc)
        /// </returns>
        public List<Nieruchomosc> filtrujUmeblowane()
        {
            return listaNieruchomosci.FindAll(t => t.Umeblowane.Equals(true));
        }

        /// <summary>
        /// Sortowanie listy nieruchomosci po cenie rosnaco
        /// </summary>
        public void SortujPoCenaRosnaco()
        {
            listaNieruchomosci.Sort();
        }

        /// <summary>
        /// Sortowanie listy nieruchomosci po cenie malejaco
        /// </summary>
        public void SortujPoCenaMalejaco()
        {
             listaNieruchomosci.Sort((x, y) => x.Cena.CompareTo(y.Cena));
             ListaNieruchomosci.Reverse();
        }
    }
}
