namespace Lottospelet.Interfaces
{
    public interface IexternalIDTjänst
    {
        bool Authenticate(string username, string password);
    }
}