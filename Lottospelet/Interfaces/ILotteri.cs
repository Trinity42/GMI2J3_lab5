namespace Lottospelet.Interfaces
{
    public interface ILotteri
    {
        Dictionary<int, int[]> RaderaLottoRader(Dictionary<int, int[]> keyValuePairs, bool isItTime);
        Dictionary<int, int[]> SkapaDict();
        bool SkapaDragning();
    }
}