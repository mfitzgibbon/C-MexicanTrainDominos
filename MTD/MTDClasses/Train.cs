﻿using System;
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
            get => this.engineValue;
            set => this.engineValue = value;
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
            if (d.Side1 == this.PlayableValue)
            {
                mustFlip = false;
                return true;
            }
            else if (d.Side2 == this.PlayableValue)
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

        public void Play(Domino d) => this.dominos.Remove(d);
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