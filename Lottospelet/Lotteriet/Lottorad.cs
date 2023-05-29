using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Lotteriet
{
    public class Lottorad : ILottorad
    {
        private Dictionary<int, int[]> LottoDict { get; set; } = new Dictionary<int, int[]>();
        private static Random random = new Random();
        public Dictionary<int, int[]> SkapaLottoRad(int användarID)
        {
            int[] array;
            while (true)
            {
                array = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    int tal1 = random.Next(1, 51);
                    array[i] = tal1;
                }
                //Console.WriteLine("1 {0}", String.Join(", ", array));

                if (KontrolleraLottoRad(array, LottoDict)) // om LottoDict inte är tom så kontrolleras den nyskapade int arrayen mot de som finns för att kolla så att det inte blir dubletter 
                {
                    break;
                }
            }
            // nu läggs index som användarID, vid färdigt program så ska den ta användarID från användaren IKonto.användarID
            LottoDict.Add(användarID, array);
            return LottoDict;
        }

        private bool KontrolleraLottoRad(int[] array, Dictionary<int, int[]> dictionary)
        {
            bool isTrue = true;
            if (dictionary.Count == 0) // kontrollerar om LottoDict är tom, är den det blir isTrue true, 
            {
                isTrue = true;
            }
            else
            {
                for (int i = 1; i < dictionary.Count + 1; i++)
                {
                    if (array.SequenceEqual(dictionary[1] as int[]))
                    {
                        isTrue = false;
                    }
                }
                if (isTrue == false)
                    Console.WriteLine("det blev falskt");
            }       // skrivs ut ifall det skulle bli dubbleter,         
            return isTrue;
        }
    }
}
