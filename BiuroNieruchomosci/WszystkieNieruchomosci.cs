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

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Nieruchomosc n in ListaNieruchomosci)
            {
                s.AppendLine(n.ToString());
            }
            return s.ToString();
        }
    }
}
