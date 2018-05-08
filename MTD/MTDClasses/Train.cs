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

        public int Count => dominos.Count;

        public int EngineValue
        {
            get => engineValue;
            set => this.engineValue = value;
        }

        public bool IsEmpty => (dominos.Count == 0) ? true : false;
        public Domino LastDomino => dominos.Last();
        public int PlayableValue => dominos.Last().Side2;
        public Domino this[int i] => dominos[i];

        public Train()
        {
            dominos = new List<Domino>();

            engineValue = 6;

            dominos.Add(new Domino(12, 12));
        }

        public Train(int engVal)
        {
            dominos = new List<Domino>();

            engineValue = engVal;

            dominos.Add(new Domino(engVal, engVal));
        }

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
            bool mustFlip;
            if (IsPlayable(d, out mustFlip))
            {
                if (!mustFlip)
                {
                    this.dominos.Add(d);
                }
                else
                {
                    d.Flip();
                    this.dominos.Add(d);
                }

            }
            else
            {
                throw new ArgumentException("This domino is not playable");
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
