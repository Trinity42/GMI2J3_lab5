
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterie.Tests
{
    public class BetalningUnitTest
    {
        [Fact]
        public void Klarna_BetalMetod_Valid()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Betalning betalning = new Klarna();

            // Act
            betalning.BetalMetod();
            string output = sw.ToString();

            // Assert
            Assert.Equal("\tVald betalmetod är Klarna med summa 400,00 kr\r\n", output);
            // kollar så att frasen som skrivs ut av betalning är samma som förväntat
        }
        [Fact]
        public void KontoKort_BetalMetod_Valid()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Betalning betalning = new KontoKort();

            // Act
            betalning.BetalMetod();
            string output = sw.ToString();

            // Assert
            Assert.Equal("\tVald betalmetod är KontoKort med summa 200,00 kr\r\n", output);
            // kollar så att frasen som skrivs ut av betalning är samma som förväntat
        }
        [Fact]
        public void PayPal_BetalMetod_Valid()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Betalning betalning = new PayPal();

            // Act
            betalning.BetalMetod();
            string output = sw.ToString();

            // Assert
            Assert.Equal("\tVald betalmetod är PayPal med summa 100,00 kr\r\n", output);
            // kollar så att frasen som skrivs ut av betalning är samma som förväntat
        }
    }
}
