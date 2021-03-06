﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {
        private int side1;
        private int side2;

        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        public Domino(int p1, int p2)
        {
            Side1 = p1;
            Side2 = p2;
        }

        // notice that I didn't do an auto implemented property because of the validation in the setter - p 390
        public int Side1
        {
            get
            {
                return side1;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side1 = value;
                else
                    throw new ArgumentException("Value must be between 0 and 13.");
            }
        }


        public int Side2
        {
            get
            {
                return side2;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side2 = value;
                else
                    throw new ArgumentException("Value must be between 0 and 13.");
            }
        }

        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        /* This is how I would have done this in 233N
        public int Score
        {
            get
            {
                return side1 + side2;
            }
        }
        */

        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        public int Score => side1 + side2;

        /* ditto for the first version of this method and the next one
        public bool IsDouble()
        {
            if (side1 == side2)
                return true;
            else
                return false;
        }
        */
        public bool IsDouble() => (side1 == side2) ? true : false;

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        // could you do this one using a lambda expression?
        /*
        public string Filename
        {
            get 
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }
        */

        public string Filename => String.Format("d{0}{1}.png", side1, side2);

        // could you overload the == and != operators?
        public override bool operator ==(Domino d1, Domino d2) => 
            (d1.Side1 == d2.Side1 && d1.Side2 == d2.Side2) ? true : false;

        public override bool operator !=(Domino d1, Domino d2) =>
            (d1.Side1 != d2.Side1 || d1.Side2 != d2.Side2) ? true : false;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Domino d = (Domino)obj;
                if (d.Side1 == this.Side1 && d.Side2 == this.Side2)
                    return true;
                else
                    return false;
            }
        }

        //public override bool Equals(object obj) => (obj == null) ? false : ()

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    public class Train
    {
        private List<Domino> dominos;
        private int engineValue;

        public int Count => dominos.Count;

        public int EngineValue
        {
            get { this.engineValue; }
            set { this.engineValue = value; }
        }

        public bool IsEmpty => (dominos.Count == 0) ? true : false;
        public Domino LastDomino => dominos.Last;
        public int PlayableValue => dominos.Last.Side2;
        public Domino this[int i] => dominos[i];

        public void Add(Domino d) => this.dominos.Add(d);

        //public bool IsPlayable(Domino d, out bool mustFlip) =>
        //    (d.Side1 == this.PlayableValue) ? true : (d.Side2 == this.PlayableValue) ? mustFlip = true;

        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if(d.Side1 == this.PlayableValue)
            {
                mustFlip = false;
                return true;
            }
            else if(d.Side2 == this.PlayableValue)
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
            string retString;
            int cardNum;

            foreach(Domino d in dominos)
            {
                retString += String.Format("Domino{0}: {1}", cardNum, d.ToString()) + "/n";
            }
        }

     }
}
