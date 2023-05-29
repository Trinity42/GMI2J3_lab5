namespace Lottospelet.Personprocess
{
	public interface IPersonProcessor
	{
		IKonto CreatePerson(string firstName, string lastName, string email, string kontotyp, int age, string lottorad);
		List<IKonto> LoadPeople();
		void SavePerson(IKonto person);
	}
}