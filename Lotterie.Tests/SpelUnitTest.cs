using Lottospelet.DataBas;
using Lottospelet.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterie.Tests
{
    public class SpelUnitTest
    {
        [Fact]
        public void Spel_SkapaKonto_ValidCall()
        {
            using (var mock = AutoMock.GetLoose()) //IDesposable
            {
                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.LoadData<IKonto>("select * from Person"))
                    .Returns(GetSamplePeople());

                var cls = mock.Create<PersonProcessor>();
                var expected = GetSamplePeople();

                var actual = cls.LoadPeople();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].Namn, actual[i].Namn);
                    Assert.Equal(expected[i].EmailAdress, actual[i].EmailAdress);
                }
            }
        }
        [Fact]
        public void Spel_validCall()
        {
            using (var mock = AutoMock.GetLoose()) //IDesposable
            {
                IKonto person = new Spelare("Sarha Hansson", 42, "a.a@du.se", 1);

                string sql = "insert into Person (FirstName, LastName, Email, Age, LottoRad, KontoTyp) " +
                "values (@FirstName, @LastName, @Email, @Age, @LottoRad, @KontoTyp)";
                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.SaveData(person, sql));

                var cls = mock.Create<PersonProcessor>();
                cls.SavePerson(person);

                mock.Mock<ISqliteDataAccess>()
                    .Verify(x => x.SaveData(person, sql), Times.Exactly(1));
            }
        }
        [Fact]
        public void PersonProcessor_CreatePerson_RetutnIKonto()
        {
            // Arrange
            SqliteDataAccess sqliteDataAccess = new SqliteDataAccess();
            PersonProcessor person = new PersonProcessor(sqliteDataAccess);

            // Act
            IKonto konto = person.CreatePerson("Sarah", "Connor", "saco@du.se", "spelare", 42, "12234345");

            Assert.IsAssignableFrom<IKonto>(konto);
        }
        [Fact]
        public void Spel_SkapaKonto_spelare_ReturnDict()
        {
            // Arrange
            Spel spel = new Spel();

            // Act            

            // Assert
            Assert.IsType<Dictionary<IKonto, Betalning>>(spel.SkapaKonto("Margaret Hamilton", "BraLösenOrd", "spelare"));
        }
        [Fact]
        public void Spel_SkapaKonto_prenumerant_ReturnDict()
        {
            // Arrange
            Spel spel = new Spel();

            // Act            

            // Assert
            Assert.IsType<Dictionary<IKonto, Betalning>>(spel.SkapaKonto("Margaret Hamilton", "BraLösenOrd", "prenumerant"));
        }

        private List<IKonto> GetSamplePeople()
        {
            List<IKonto> konto = new List<IKonto>()
            {
                new Spelare("Sarha Hansson", 42, "a.a@du.se", 1),
                new Prenumerant("Gustav Hnsson", 72, "a.b@du.se", 2)
            };

            return konto;
        }
    }
}
