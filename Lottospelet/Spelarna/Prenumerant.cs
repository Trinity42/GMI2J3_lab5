using Lottospelet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet.Spelarna
{
    public class Prenumerant : IKonto
    {
        public string Namn { get; private set; }
        public int Ålder { get; private set; }
        public string EmailAdress { get; private set; }
        public int AnvändarID { get; private set; }

        public Prenumerant(string namn, int ålder, string emailAdress, int användarID)
        {
            Namn = namn;
            Ålder = ålder;
            EmailAdress = emailAdress;
            AnvändarID = användarID;
        }

        public string NyRad(string namn)
        {
            // Denna metod kommer att automatiskt skapa en ny lottorad efter dragning
            return $"Skapar automatisk ny rad åt {namn} vid dragning";
        }
    }
}
