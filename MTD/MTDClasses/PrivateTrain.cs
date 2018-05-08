using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class PrivateTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        public bool IsOpen => isOpen;

        public void Close()
        {
            this.isOpen = false;
        }

        public void Open()
        {
            this.isOpen = true;
        }

        public bool IsPlayable(Domino d, out bool mustFlip, Hand h)
        {
            if (isOpen || h == hand)
            {
                if (IsPlayable(d, out mustFlip))
                {
                    if(h.HasDomino(d.Side1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }

        public void Play(Domino d, Hand h)
        {
            if(IsPlayable(d, out bool mustFlip, h))
            {
                if(!mustFlip)
                    Play(d);
                else
                {
                    d.Flip();
                    Play(d);
                }
            }
        }

        public PrivateTrain()
        {
            dominos = new List<Domino>();
            engineValue = 12;
            hand = new Hand();
            isOpen = false;
        }

        public PrivateTrain(Hand k)
        {
            dominos = new List<Domino>();
            hand = k;
            engineValue = hand[hand.IndexOfDomino(12)].Side1;
            isOpen = false;
        }

        public PrivateTrain(Hand k, int engineValue)
        {
            dominos = new List<Domino>();
            hand = k;
            isOpen = false;
            EngineValue = engineValue;
            hand.Play(hand.GetDoubleDomino(engineValue), this);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
