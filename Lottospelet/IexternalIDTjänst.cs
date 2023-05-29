namespace Lottospelet
{
	public interface IexternalIDTjänst
	{
		bool Authenticate(string username, string password);
	}
}