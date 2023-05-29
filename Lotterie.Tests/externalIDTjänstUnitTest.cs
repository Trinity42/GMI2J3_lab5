using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterie.Tests
{
    public class externalIDTjänstUnitTest
    {
        [Theory]
        [InlineData("LifeSux", "BraLösenOrd")]
        public void externalIDTjänst_Authenticat_ReturnTrue(string username, string password)
        {

            //Arrange
            externalIDTjänst externalIDTjänst = new externalIDTjänst();

            //Act
            bool result = externalIDTjänst.Authenticate(username, password);

            //Assert
            Assert.True(result);
        }
        [Theory]
        [InlineData("LifeNotSux", "BraLösenOrd")]
        public void externalIDTjänst_Authenticat_ReturnFalse(string username, string password)
        {

            //Arrange
            externalIDTjänst externalIDTjänst = new externalIDTjänst();

            //Act
            bool result = externalIDTjänst.Authenticate(username, password);

            //Assert
            Assert.False(result);
        }
    }
}
