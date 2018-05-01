using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Train
    {
        private List<Domino> dominos;
        private int engineValue;

        public Train()
        {
            dominos = new List<Domino>();
            dominos.Add(new Domino(12, 12));
        }

        public Train(int engineValue)
        {
            dominos = new List<Domino>();
            dominos.Add(new Domino(engineValue, engineValue));
        }

        public int Count => dominos.Count;

        public int EngineValue
        {
            get => dominos.First().Side2;
        }

        public bool IsEmpty => (dominos.Count == 0) ? true : false;
        public Domino LastDomino => dominos.Last();
        public int PlayableValue => dominos.Last().Side2;
        public Domino this[int i] => dominos[i];

        public void Add(Domino d) => this.dominos.Add(d);

        //public bool IsPlayable(Domino d, out bool mustFlip) =>
        //    (d.Side1 == this.PlayableValue) ? true : (d.Side2 == this.PlayableValue) ? mustFlip = true;

        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == this.PlayableValue || d.Side1 == 0)
            {
                mustFlip = false;
                return true;
            }
            else if (d.Side2 == this.PlayableValue || d.Side2 == 0)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }

        public void Play(Domino d)
        {
            bool needsFlip;
            if(IsPlayable(d, out needsFlip))
            {
                if (needsFlip)
                {
                    d.Flip();
                    dominos.Add(d);
                }
                else
                {
                    dominos.Add(d);
                }
            }
            else
            {
                throw new Exception("Param Domino d is not a playable domino, flipped or otherwise." +
                    " Please pass a playable domino");
            }
        }

        public string Show(int number) => this[number].ToString();

        public override string ToString()
        {
            string retString = "";
            int cardNum = 0;

            foreach (Domino d in dominos)
            {
                retString += String.Format("Domino{0}: {1}", cardNum, d.ToString()) + "/n";
                cardNum++;
            }

            return retString;
        }

    }
}
