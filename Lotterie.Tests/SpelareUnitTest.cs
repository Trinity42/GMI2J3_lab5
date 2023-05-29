using Lottospelet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterie.Tests
{
    public class SpelareUnitTest
    {
        [Fact]
        public void PensionärsRabatt_RabattEllerInte_FårRabatt()
        {
            // Arrange            
            IKonto konto = new Spelare("Namn Namnson", 72, "a.a@du.se", 1);

            // Act            
            string output = PensionärsRabatt.RabattEllerInte(konto);

            // Assert
            Assert.Equal("Namn Namnson får pensionärsrabatt", output);
        }
        [Fact]
        public void PensionärsRabatt_RabattEllerInte_FårInteRabatt()
        {
            // Arrange            
            IKonto konto = new Spelare("Namn Namnson", 42, "a.a@du.se", 1);

            // Act            
            string output = PensionärsRabatt.RabattEllerInte(konto);

            // Assert
            Assert.Equal("Namn Namnson får inte pensionärsrabatt", output);
        }
        [Fact]
        public void Prenumerant_NyRad_ReturnString()
        {
            // Arrange
            IKonto konto = new Prenumerant("Namn Namnson", 42, "a.a@du.se", 1);
            // Act
            string output = konto.NyRad(konto.Namn);
            // Assert
            Assert.Equal("Skapar automatisk ny rad åt Namn Namnson vid dragning", output);
        }
        [Fact]
        public void Spelare_NyRad_ReturnString()
        {
            // Arrange
            IKonto konto = new Spelare("Namn Namnson", 42, "a.a@du.se", 1);
            // Act
            string output = konto.NyRad(konto.Namn);
            // Assert
            Assert.Equal("Skapar ny rad när Namn Namnson väljer det", output);
        }
    }
}
