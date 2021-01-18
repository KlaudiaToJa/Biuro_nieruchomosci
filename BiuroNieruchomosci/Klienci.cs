using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;


//WYRZUCONE DZIEDZIECZENIE PO ZBIOROWOSC BO NIE DZIALALO JAK POWINNO


namespace BiuroNieruchomosci
{
    [Serializable]
    public class Klienci 
    {
        List<Klient> _listaKlientow = new List<Klient>();

        public Klienci() 
        {
            
        }

        public List<Klient> ListaKlientow { get => _listaKlientow; set => _listaKlientow = value; }

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klienci)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static Klienci OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klienci));
                return (Klienci)serializer.Deserialize(reader);
            }
        }

        public void DodajKlienta(Klient k)
        {
            ListaKlientow.Add(k);
        }

        public void UsunKlienta(string pesel)
        {
            Klient klient = new Klient();
            foreach (Klient item in _listaKlientow)
            {
                if (item.PESEL.Equals(pesel))
                {
                    klient = item;
                    break;
                }
            }
            ListaKlientow.Remove(klient);
        }

        public bool CzyJestWBazie(string pesel)
        {
            foreach (Osoba k in ListaKlientow)
            {
                if (k.PESEL == pesel)
                {
                    return true;
                }
            }
            return false;
        }
        public void WyczyscListe()
        {
            ListaKlientow.Clear();
        }

        /*public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach(Osoba k in ListaKlientow)
            {
                s.AppendLine(k.ToString());
            }
            return s.ToString();
        }*/
    }
}
