using Lottospelet.Betalningar;

namespace Lottospelet.Interfaces
{
    public interface ISpel
    {
        bool LoggaIn(string namn, string lösenord);
        Dictionary<IKonto, Betalning> SkapaKonto(string namn, string lösenord, string konto);
    }
}