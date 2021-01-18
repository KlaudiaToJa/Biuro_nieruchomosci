using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


//WYRZUCILAM ZBIOROWOSC, SPRAWDZCIE MOZE CZY DA SIE JAKOS Z NIĄ ZEBY DZIALALO (Klaudia)


namespace BiuroNieruchomosci
{
    [Serializable]
    public class Pracownicy
    {
        List<Pracownik> _listaPracownikow = new List<Pracownik>();

        public List<Pracownik> ListaPracownikow { get => _listaPracownikow; set => _listaPracownikow = value; }

        public Pracownicy()
        {

        }

        public void DodajPracownika(Pracownik p)
        {
            ListaPracownikow.Add(p);
        }

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

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pracownicy)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

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

        public void SortujNazwiskaImiona()
        {
            ListaPracownikow.Sort();
        }

        public void SortujMiejscowosciami()
        {
            ListaPracownikow.Sort((x, y) => x.Miejscowosc.CompareTo(y.Miejscowosc));
        }
    }
}
