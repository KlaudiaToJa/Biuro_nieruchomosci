using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    public class WszystkieNieruchomosci
    {
        List<Nieruchomosc> listaNieruchomosci;

        public List<Nieruchomosc> ListaNieruchomosci { get => listaNieruchomosci; set => listaNieruchomosci = value; }
        public Nieruchomosc SelectedItem { get; set; }

        public WszystkieNieruchomosci()
        {
            ListaNieruchomosci = new List<Nieruchomosc>();
        }

        public void DodajNieruchomosc(Nieruchomosc n)
        {
            ListaNieruchomosci.Add(n);
        }

        public void UsunNieruchomosc(string idUsuwanej)
        {
            // znalezienie nieruchomosci z podanym id:
            int index = ListaNieruchomosci.FindIndex(item => item.IdNieruchomosci == idUsuwanej);
            if (index >= 0) // jesli taki element istnieje
            {
                ListaNieruchomosci.RemoveAt(index);
            }
        }

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WszystkieNieruchomosci)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static WszystkieNieruchomosci OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WszystkieNieruchomosci));
                return (WszystkieNieruchomosci)serializer.Deserialize(reader);
            }
        }

        // opcje do filtrowania nieruchomosci to filtrowanie po: cenie, ilosci pokojow, miejscowosc, powierzchni, typie nieruchomosci
        // typie transakcji, standardzie, rynku, rodzaju kuchni, i bool parking, balkon, umeblowanie

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

        public List<Nieruchomosc> filtrujIloscPokojow(int ilosc)
        {
            return listaNieruchomosci.FindAll(il => il.LiczbaPokojow.Equals(ilosc));
        }

        public List<Nieruchomosc> filtrujMiejscowosc(string miejscowosc)
        {
            return listaNieruchomosci.FindAll(m => m.Miejscowosc.Equals(miejscowosc));
        }

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

        public List<Nieruchomosc> filtrujTypNieruchomosci(Nieruchomosc.TypNieruchomosci typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypNieruchomosci1.Equals(typ));
        }

        public List<Nieruchomosc> filtrujTypTransakcji(Nieruchomosc.TypTransakcji typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypTransakcji1.Equals(typ));
        }

        public List<Nieruchomosc> filtrujStandard(Nieruchomosc.Standard typ)
        {
            return listaNieruchomosci.FindAll(t => t.Standard1.Equals(typ));
        }

        public List<Nieruchomosc> filtrujRynek(Nieruchomosc.Rynek typ)
        {
            return listaNieruchomosci.FindAll(r => r.Rynek1.Equals(typ));
        }

        public List<Nieruchomosc> filtrujRodzajKuchni(Nieruchomosc.RodzajKuchni typ)
        {
            return listaNieruchomosci.FindAll(t => t.TypNieruchomosci1.Equals(typ));
        }

        public List<Nieruchomosc> filtrujBalkon()
        { 
            return listaNieruchomosci.FindAll(t => t.Balkon.Equals(true));
        }

        public List<Nieruchomosc> filtrujParking()
        {
            return listaNieruchomosci.FindAll(t => t.Parking.Equals(true));
        }

        public List<Nieruchomosc> filtrujUmeblowane()
        {
            return listaNieruchomosci.FindAll(t => t.Umeblowane.Equals(true));
        }

        public void SortujPoCenaRosnaco()
        {
            listaNieruchomosci.Sort();
            
        }

        public void SortujPoCenaMalejaco()
        {
             listaNieruchomosci.Sort((x, y) => x.Cena.CompareTo(y.Cena));
             ListaNieruchomosci.Reverse();
        }

        /*
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Nieruchomosc n in ListaNieruchomosci)
            {
                s.AppendLine(n.ToString());
            }
            return s.ToString();
        }
        */
    }
}
