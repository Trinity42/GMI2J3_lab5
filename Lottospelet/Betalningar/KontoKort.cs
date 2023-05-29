using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Betalningar
{
    public class KontoKort : Betalning
    {
        public override decimal Summa { get; } = 200;
        public override void BetalMetod()
        {
            Console.WriteLine($"\tVald betalmetod är KontoKort med summa {Summa:C}");
        }
    }
}
