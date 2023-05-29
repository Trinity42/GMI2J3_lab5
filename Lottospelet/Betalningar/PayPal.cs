using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Betalningar
{
    public class PayPal : Betalning
    {
        public override decimal Summa { get; } = 100;
        public override void BetalMetod()
        {
            Console.WriteLine($"\tVald betalmetod är PayPal med summa {Summa:C}");
        }
    }
}
