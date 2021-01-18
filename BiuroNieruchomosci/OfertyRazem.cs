using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class OfertyRazem : IOferuje
    {
        List<Oferta> _listaOfert;
        public List<Oferta> ListaOfert { get => _listaOfert; set => _listaOfert = value; }

        public OfertyRazem()
        {
            
        }

        public void DodajOferte(Oferta o)
        {
            ListaOfert.Add(o);
        }

        public void UsunOferte(string idOferty)
        {
            foreach (Oferta o in ListaOfert)
            {
                if (o.IdOferty == idOferty)
                {
                    ListaOfert.Remove(o);
                }
            }
        }

        public void ZapiszXMLOferty(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OfertyRazem)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static OfertyRazem OdczytajXMLOferty (string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OfertyRazem));
                return (OfertyRazem)serializer.Deserialize(reader);
            }
        }

        public List<Oferta> filtrujImieKlienta(string imie, bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach(Oferta oferta in this._listaOfert)
            {
                if(oferta.Umowa.Klient.Imie.ToUpper() == imie.ToUpper()  && oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                    
                }
            }
            return wyniki;
        }
        

        public List<Oferta> filtrujNazwiskoKlienta(string nazwisko, bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach(Oferta oferta in this._listaOfert)
            {
                if(oferta.Umowa.Klient.Nazwisko.ToUpper() == nazwisko.ToUpper() && oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        public List<Oferta> filtrujDate(string data, bool czyAktywna)
        {
            
            List<Oferta> wyniki = new List<Oferta>();
            DateTime dataFiltr;
            DateTime.TryParseExact(data, new[] { "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataFiltr);
            foreach (Oferta oferta in this._listaOfert)
            {
                if ((oferta.Umowa.DataZawarcia.Year == dataFiltr.Year && oferta.Umowa.DataZawarcia.Month == dataFiltr.Month || oferta.Umowa.DataZawarcia == dataFiltr) && oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            }


            return wyniki;
        }


        public List<Oferta> filtrujImieOpiekuna(string imie, bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach (Oferta oferta in this._listaOfert)
            {
                if (oferta.Umowa.OpiekunKlienta.Imie.ToUpper() == imie.ToUpper() && oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

        public List<Oferta> filtrujNazwiskoOpiekuna(string nazwisko, bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach (Oferta oferta in this._listaOfert)
            {
                if (oferta.Umowa.OpiekunKlienta.Nazwisko.ToUpper() == nazwisko.ToUpper() && oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            }
            return wyniki;
        }

         public List<Oferta> PrzegladajOferty(bool czyAktywna)
        {
            List<Oferta> wyniki = new List<Oferta>();
            foreach(Oferta oferta in this._listaOfert)
                if(oferta.CzyAktywna == czyAktywna)
                {
                    wyniki.Add(oferta);
                }
            return wyniki;
        }
    }
}


