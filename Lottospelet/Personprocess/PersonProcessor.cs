using Lottospelet.DataBas;
using Lottospelet.Interfaces;
using Lottospelet.Spelarna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Personprocess
{
	public class PersonProcessor : IPersonProcessor
	{
		ISqliteDataAccess _database;

		public PersonProcessor(ISqliteDataAccess database)
		{
			_database = database;
		}
        
        public IKonto CreatePerson(string firstName, string lastName, string email, string kontotyp, int age, string lottorad)
		{
			string fullname = $"{firstName} {lastName}";
			IKonto output;
			if (kontotyp.ToLower() == "prenumerant")
				output = new Prenumerant(fullname, age, email, 1);
			else if (kontotyp.ToLower() == "spelare")
				output = new Spelare(fullname, age, email, 2);
			else
				output = new Spelare(fullname, age, email, 2);

			return output;
		}

		private bool isValidAge(int age)
		{
			bool isAge = false;
			if (age >= 18) isAge = true;
			return isAge;
		}

		public List<IKonto> LoadPeople()
		{
			string sql = "select * from Person";

			var output = _database.LoadData<IKonto>(sql);

			return output;
		}

		public void SavePerson(IKonto person)
		{
			string sql = "insert into Person (FirstName, LastName, Email, Age, LottoRad, KontoTyp) " +
				"values (@FirstName, @LastName, @Email, @Age, @LottoRad, @KontoTyp)";

			//sql = sql.Replace("@FirstName", $"'{person.FirstName}'");
			//sql = sql.Replace("@LastName", $"'{person.LastName}'");
			//sql = sql.Replace("@Email", $"{person.Email}");            
			//sql = sql.Replace("@Age", $"{person.Age}");
			//sql = sql.Replace("@LottoRad", $"{person.LottoRad}");
			//sql = sql.Replace("@KontoTyp", $"{person.KontoTyp}");

			_database.SaveData(person, sql);
		}

		//public void RaderaLottoRad(IKonto person)
		//{
		//    string sql = "update Person set FirstName = @FirstName, LastName = @LastName" +
		//        ", HeightInInches = @HeightInInches where Id = @Id";

		//    _database.UpdateData(person, sql);
		//}

		//private bool ValidateName(string name)
		//{
		//    bool output = true;
		//    char[] invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

		//    if (name.Length < 2)
		//    {
		//        output = false;
		//    }

		//    if (name.IndexOfAny(invalidCharacters) >= 0)
		//    {
		//        output = false;
		//    }

		//    return output;
		//}
		//private bool IsValidEmail(string email)
		//{
		//    // Define the regular expression pattern for email validation
		//    string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

		//    // Check if the email matches the pattern
		//    bool isValid = Regex.IsMatch(email, pattern);

		//    return isValid;
		//}
	}
}
