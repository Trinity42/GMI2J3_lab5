using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet
{
	public class Application : IApplication
	{
		IViTestarOmDettaFungerar _viTestar;

		public Application(IViTestarOmDettaFungerar viTestar)
		{
			_viTestar = viTestar;

		}

		public void Run()
		{
			IdentifyNextStep();
		}
		//_viTestar.EnMetod();
		private void IdentifyNextStep()
		{
			string selectedAction = "";

			do
			{
				selectedAction = GetActionChoice();

				Console.WriteLine();

				switch (selectedAction)
				{
					case "1":
						_viTestar.EnMetod();
						break;
					case "2":
						Console.WriteLine("Ska lägga till spelare");
						break;
					case "3":
						Dictionary<int, int[]> LottoDict = Spel.SkapaLottorad();
						Lotteri lotteri = new Lotteri();
						DateTime day = DateTime.Now;
						string dag = day.ToString("dddd");
						bool isTrue = false;
						if (dag == "fredag") isTrue = true;
						lotteri.RaderaLottoRader(LottoDict, isTrue);
						Console.WriteLine("Ska radera lottorader för spelare");
						break;
					case "4":
						Console.WriteLine("Tack för besöket!");
						break;
					default:
						Console.WriteLine("Du måste välja 1,2, 3 eller 4");
						break;
				}

				Console.WriteLine("Tryck på retur för att fortsätta");
				Console.ReadLine();

			} while (selectedAction != "4");
		}


		private string GetActionChoice()
		{
			string output = "";
			Console.Clear();
			Console.WriteLine(FiggleFonts.Standard.Render("Lotteriet"));
			Console.WriteLine("Välkommen till spelet\n");
			Console.WriteLine("Meny val".ToUpper());
			Console.WriteLine("1) Skriv ut");
			Console.WriteLine("2) Skapa konto");
			Console.WriteLine("3) Dags för dragning");
			Console.WriteLine("4) Avsluta");
			Console.Write("Vad väljer du: ");
			output = Console.ReadLine();

			return output;
		}
	}
}
