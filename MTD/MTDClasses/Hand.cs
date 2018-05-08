using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Hand
    {
        private List<Domino> handOfDominos;

        public int Count => handOfDominos.Count;
        public bool IsEmpty => (handOfDominos.Count == 0) ? true : false;
        public int Score
        {
            get
            {
                int score = 0;
                foreach(Domino d in handOfDominos)
                {
                    score += d.Score;
                }
                return score;
            }
        }
        public Domino this[int index]
        {
            get
            {
                return handOfDominos[index];
            }
        }

        #region constructors
        public Hand()
        {
            handOfDominos = new List<Domino>();

            Boneyard by = new Boneyard();

            for (int i = 0; i < 15; i++)
            {
                handOfDominos.Add(by.Draw());
            }
        }

        public Hand(Boneyard by, int numPlayers)
        {
            handOfDominos = new List<Domino>();

            if (numPlayers == 1)
                throw new ArgumentException("numPlayers must be greater than 1");
            else if (numPlayers == 2 || numPlayers == 3)
            {
                for (int i = 0; i < 16; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }
            else if (numPlayers == 4)
            {
                for (int i = 0; i < 15; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }
            else if (numPlayers == 5)
            {
                for (int i = 0; i < 14; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }
            else if (numPlayers == 6)
            {
                for (int i = 0; i < 12; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }
            else if (numPlayers == 7)
            {
                for (int i = 0; i < 10; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }
            else if (numPlayers == 8)
            {
                for (int i = 0; i < 9; i++)
                {
                    handOfDominos.Add(by.Draw());
                }
            }else
            {
                throw new ArgumentException("numPlayers cannot be greater than 8");
            }
        }
        #endregion

        public void Add(Domino d) => this.handOfDominos.Add(d);
        public void Draw(Boneyard by) => this.Add(by.Draw());

        public Domino GetDomino(int pipValue)
        {
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == pipValue || d.Side2 == pipValue)
                {
                    handOfDominos.Remove(d);
                    return d;
                }
            }

            return null;
        }

        public Domino GetDoubleDomino(int pipValue)
        {
            foreach(Domino d in handOfDominos)
            {
                if(d.Side1 == pipValue && d.Side2 == pipValue)
                {
                    handOfDominos.Remove(d);
                    return d;
                }
            }

            return null;
        }

        public bool HasDomino(int pipValue)
        {
            foreach(Domino d in handOfDominos)
            {
                if (d.Side1 == pipValue || d.Side2 == pipValue)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasDoubleDomino(int pipValue)
        {
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == pipValue && d.Side2 == pipValue)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOfDomino(int pipValue)
        {
            Domino d = GetDomino(pipValue);
            if (d != null)
            {
                return handOfDominos.IndexOf(d);
            }
            else
                throw new Exception("No dominos of that value in hand");
        }

        public int IndexOfDoubleDomino(int pipValue)
        {
            Domino d = GetDoubleDomino(pipValue);
            if (d != null)
            {
                return handOfDominos.IndexOf(d);
            }
            else
                throw new Exception("No double dominos of that value in hand");
        }

        public int IndexOfHighDouble()
        {
            Domino d = GetDoubleDomino(12);
            if (d != null)
            {
                return handOfDominos.IndexOf(d);
            }
            else
                throw new Exception("The high double is not in this hand");
        }
    }
}
