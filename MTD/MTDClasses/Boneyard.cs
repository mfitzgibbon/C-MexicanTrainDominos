using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Boneyard
    {
        private List<Domino> listOfDominos;

        public int DominosRemaining => listOfDominos.Count;

        public Domino this[int i]
        {
            get => listOfDominos[i];
            set => listOfDominos[i] = value;
        }

        public Boneyard()
        {
            listOfDominos = new List<Domino>();

            int sideA = 12;
            int sideB = 12;

            while (sideA != -1)
            {
                sideB = sideA;
                while(sideB != -1)
                {
                     listOfDominos.Add(new Domino(sideA, sideB));
                     sideB--;
                }
                sideA--;
            }
        }

        public Boneyard(int maxDots)
        {
            listOfDominos = new List<Domino>();

            int sideA = maxDots;
            int sideB = maxDots;

            while(sideA != -1)
            {
                sideB = sideA;
                while(sideB != -1)
                {
                    listOfDominos.Add(new Domino(sideA, sideB));
                    sideB--;
                }
                sideA--;
            }
        }

        public Domino Draw()
        {
            Domino d = listOfDominos.Last();
            listOfDominos.Remove(d);
            return d;
        }

        public bool IsEmpty() => 
            (listOfDominos.Count == 0) ? true : false;

        public void Shuffle()
        {
            Random rng = new Random();

            int n = listOfDominos.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Domino temp = listOfDominos[k];
                listOfDominos[k] = listOfDominos[n];
                listOfDominos[n] = temp;
            }
        }

        public override string ToString()
        {
            string retString = "";
            int cardNum = 0;

            foreach (Domino d in listOfDominos)
            {
                retString += String.Format("Domino({0}): {1}", cardNum, d.ToString()) + Environment.NewLine;
                cardNum++;
            }

            return retString;
        }
    }
}
