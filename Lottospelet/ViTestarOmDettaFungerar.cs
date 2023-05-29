using Lottospelet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet
{
	public class ViTestarOmDettaFungerar : IViTestarOmDettaFungerar
	{
		IexternalIDTjänst _externalIDTjänst;
		public ViTestarOmDettaFungerar(IexternalIDTjänst externalIDTjänst)
		{
			_externalIDTjänst = externalIDTjänst;
		}
		public void EnMetod()
		{
			Spel spel = new Spel();
			Dictionary<IKonto, Betalning> output = spel.SkapaKonto("LifeSux", "BraLösenOrd", "Spelare");
			Dictionary<IKonto, Betalning> output1 = spel.SkapaKonto("BeAfraid", "MerBraLösenord", "Prenumerant");

			Spel spelet = new Spel(_externalIDTjänst);
			Spel.SkrivUt(output);
			Spel.SkrivUt(output1);

			Console.WriteLine("\n\tInloggning: {0}", spelet.LoggaIn("LifeSux", "BraLösenOrd") ? "Lyckades" : "Misslyckades");

			Dictionary<int, int[]> LottoDict = Spel.SkapaLottorad();
			Spel.SkrivUt(LottoDict);
			Console.ReadLine();
			Lotteri lotteri = new Lotteri();
			DateTime day = DateTime.Now;
			string dag = day.ToString("dddd");
			bool isTrue = false;
			if (dag == "fredag") isTrue = true;
			lotteri.RaderaLottoRader(LottoDict, isTrue);
			Console.ReadLine();
			Spel.SkrivUt(LottoDict);
		}


	}
}
