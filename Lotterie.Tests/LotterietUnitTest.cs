using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterie.Tests
{
    public class LotterietUnitTest
    {
        [Fact]
        public void Lotteri_SkapaDict_ReturnDict()
        {
            // Arrange 
            Lotteri lotteri = new Lotteri();

            // Act

            // Assert

            Assert.IsType<Dictionary<int, int[]>>(lotteri.SkapaDict()); // kollar om lotteri.SkapaDict() returnera en 
                                                                        // Dictionary<int, int[]
        }
        [Fact]
        public void Lotteri_RaderaRader_NotRightDay()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var dictonary = new Dictionary<int, int[]>()
            {
                { 1, new int[] {1,2,3,4 } },
                { 2, new int[] {1,2,3,4 } },
                { 3, new int[] {1,2,3,4 } },
            };
            bool isTrue = false;
            Lotteri lotteri = new Lotteri();

            // Act
            lotteri.RaderaLottoRader(dictonary, isTrue);
            string output = sw.ToString();
            // Assert
            Assert.Equal("Det är inte fredag!\r\n", output);
        }
        [Fact]
        public void Lotteri_RaderaRader_RightDay()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var dictonary = new Dictionary<int, int[]>()
            {
                { 1, new int[] {1,2,3,4 } },
                { 2, new int[] {1,2,3,4 } },
                { 3, new int[] {1,2,3,4 } },
            };
            bool isTrue = true;
            Lotteri lotteri = new Lotteri();

            // Act
            lotteri.RaderaLottoRader(dictonary, isTrue);
            string output = sw.ToString();
            // Assert
            Assert.Equal("Raderna är raderade!\r\n", output);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Lottorad_SkapaLottoRad_ReturnDict(int num)
        {
            // Arrange 
            Lottorad lottorad = new Lottorad();

            // Act

            // Assert

            Assert.IsType<Dictionary<int, int[]>>(lottorad.SkapaLottoRad(num)); // kollar om lottorad.SkapaLottoRad(num) returnera en 
                                                                                // Dictionary<int, int[]
        }
        [Fact]
        public void Lotteri_SkapaDragning_ReturnTrue()
        {
            // Arrange
            Lotteri lotteri = new Lotteri();

            // Act

            // Asssert 
            Assert.True(lotteri.SkapaDragning());
        }
    }
}
