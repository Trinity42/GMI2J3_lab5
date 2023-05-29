using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottospelet.Interfaces;

namespace Lottospelet
{
    public class Spel : ISpel
    {
        private static string AnvändarNamn { get; set; }
        private static string Lösenord { get; set; }
        private static string KontoTyp { get; set; }

        private static int Räknare = 0;

        IexternalIDTjänst _iexternalIDTjänst;

        public Spel(IexternalIDTjänst iexternalIDTjänst)
        {
            _iexternalIDTjänst = iexternalIDTjänst;
        }
        public Spel()
        {

        }

        public bool LoggaIn(string namn, string lösenord)
        {
            if (_iexternalIDTjänst.Authenticate(namn, lösenord))
                return true;
            else return false;
        }
        public Dictionary<IKonto, Betalning> SkapaKonto(string namn, string lösenord, string konto)
        {
            Dictionary<IKonto, Betalning> skapa = new Dictionary<IKonto, Betalning>();
            AnvändarNamn = namn;
            Lösenord = lösenord;
            KontoTyp = konto;
            string[] array = new string[3];
            array[0] = AnvändarNamn;
            array[1] = Lösenord;
            array[2] = KontoTyp;
            if (KontoTyp.ToLower() == "spelare")
            {
                Räknare++;
                int num = Räknare;
                string fulltNamn = "Anna Svensson";
                int ålder = 23;
                string epost = "r.r@du.se";
                IKonto konto1 = new Spelare(fulltNamn, ålder, epost, num);
                Betalning betalning = new Klarna();
                skapa.Add(konto1, betalning);
                return skapa;
            }
            else if (KontoTyp.ToLower() == "prenumerant")
            {
                Räknare++;
                int num = Räknare;
                string fulltNamn = "Hanna Hansson";
                int ålder = 67;
                string epost = "p.r@du.se";
                IKonto konto1 = new Prenumerant(fulltNamn, ålder, epost, num);
                Betalning betalning = new PayPal();
                skapa.Add(konto1, betalning);
                return skapa;
            }
            return null;
        }
        public static Dictionary<int, int[]> SkapaLottorad()
        {
            Lotteri lotteri = new Lotteri();
            Dictionary<int, int[]> LottoDict = lotteri.SkapaDict();
            return LottoDict;
        }
        public static void LoggaUt()
        {
            Console.WriteLine("Här ska användaren logga ut");
        }
        public static void RaderaKonto()
        {
            Console.WriteLine("Här ska användaren kunna radera sitt konto");
        }
        public static void SkrivUt(Dictionary<IKonto, Betalning> item)
        {

            {
                foreach (KeyValuePair<IKonto, Betalning> author in item)
                {
                    string namn = author.Key.Namn;
                    int ålder = author.Key.Ålder;
                    string email = author.Key.EmailAdress;
                    int id = author.Key.AnvändarID;
                    Console.WriteLine("\n\tNamn: {0}. Ålder: {1}. Emailadress: {2}. AnvändarID: {3}", namn, ålder, email, id);
                    author.Value.BetalMetod();
                    Console.WriteLine("\t{0}", PensionärsRabatt.RabattEllerInte(author.Key));
                    Console.WriteLine("\t{0}", author.Key.NyRad(author.Key.Namn));
                    Console.WriteLine("\tDenna användare är: {0}", author.Key);
                }
            }
        }
        public static void SkrivUt(Dictionary<int, int[]> LottoDict)
        {
            Console.WriteLine("Skriver ut:");
            if (LottoDict.Count == 0) // kollar om Lottodict är tom, är den det så skrivs texten ut
            {
                Console.WriteLine("Det finns inga lottorader!");
            }
            else
            {
                foreach (KeyValuePair<int, int[]> lotter in LottoDict)
                {
                    Console.Write("Key: {0}  \tValue: ", lotter.Key);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("{0}, ", lotter.Value[i]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
