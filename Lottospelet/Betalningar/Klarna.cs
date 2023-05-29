using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Betalningar
{
    public class Klarna : Betalning
    {
        public override decimal Summa { get; } = 400;

        public override void BetalMetod()
        {
            Console.WriteLine($"\tVald betalmetod är Klarna med summa {Summa:C}");
        }
    }
}
