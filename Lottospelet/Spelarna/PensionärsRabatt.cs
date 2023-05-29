using Lottospelet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Spelarna
{
    public class PensionärsRabatt
    {
        private static bool FårPensionärsRabatt(int ålder)
        {
            if (ålder < 66)
                return false;
            else
                return true;
        }
        public static string RabattEllerInte(IKonto konto)
        {
            if (PensionärsRabatt.FårPensionärsRabatt(konto.Ålder))
                return $"{konto.Namn} får pensionärsrabatt";
            else
                return $"{konto.Namn} får inte pensionärsrabatt";
        }
    }
}
