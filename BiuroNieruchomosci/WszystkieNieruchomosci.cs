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
        // typie transakcji, standardzie, rynku, rodzaju kuchni

        // czy dodawac szukanie bool jak parking balkon etc.?

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
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.LiczbaPokojow == ilosc)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        public List<Nieruchomosc> filtrujMiejscowosc(string miejscowosc)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.Miejscowosc.ToUpper() == miejscowosc.ToUpper())
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
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
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.TypNieruchomosci1 == typ)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        public List<Nieruchomosc> filtrujTypTransakcji(Nieruchomosc.TypTransakcji typ)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.TypTransakcji1 == typ)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        public List<Nieruchomosc> filtrujStandard(Nieruchomosc.Standard typ)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.Standard1 == typ)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        public List<Nieruchomosc> filtrujRynek(Nieruchomosc.Rynek typ)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.Rynek1 == typ)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
        }

        public List<Nieruchomosc> filtrujRodzajKuchni(Nieruchomosc.RodzajKuchni typ)
        {
            List<Nieruchomosc> nowaLista = new List<Nieruchomosc>();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                if (n.RodzajKuchni1 == typ)
                {
                    nowaLista.Add(n);
                }
            }
            return nowaLista;
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
