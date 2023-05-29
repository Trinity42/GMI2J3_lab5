using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Interfaces
{
    public interface IKonto
    {
        string Namn { get; }
        int Ålder { get; }
        string EmailAdress { get; }
        int AnvändarID { get; }
        string NyRad(string namn);
    }
}
