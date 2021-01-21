using BiuroNieruchomosci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestImieKonstruktorKlienta()
        {
            Klient klient = new Klient("Jan", "Kowalski", "96090908011", "");
            Assert.AreEqual("Kowalski", klient.Nazwisko);
        }

        /*[TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void TestWujatkuNumeruTel()
        {
            Klient klient = new Klient("Jan", "Kowalski", "", "", "Wroclaw", "6", "m.klo", "");
          
        }*/


        [TestMethod]
        public void testDodajOferte()
        {
            OfertyRazem oferty = new OfertyRazem();
            Oferta oferta = new Oferta();
            oferty.DodajOferte(oferta);
            Assert.AreEqual(1, oferty.ListaOfert.Count);
          

        }

        [TestMethod]
        public void testEqualsKlient()
        {

            Klient k1 = new Klient("Jan", "Kowalski", "12345678912", "");
            Klient k2 = new Klient("Jan", "Kowalski", "11111111111", "");
            Assert.IsTrue(k2.Equals(k1));

        }

        
    }
}
