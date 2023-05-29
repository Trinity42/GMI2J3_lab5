using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Betalningar
{
    public abstract class Betalning
    {
        public abstract decimal Summa { get; }
        public abstract void BetalMetod();
    }
}
