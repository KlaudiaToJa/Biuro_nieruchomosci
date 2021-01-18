using BiuroNieruchomosci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestImieKonstruktorKlienta()
        {
            Klient klient = new Klient("Jan", "Kowalski", "96090908011", "");
            Assert.AreEqual("Jan", klient.Imie);
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void TestWujatkuNumeruTel()
        {
            Klient klient = new Klient("Jan", "Kowalski", "", "", "Wroclaw", "6", "", "123451267890");
          
        }
    }
}
