using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    public class BoneyardTests
    {
        Domino dummyDomino;
        Boneyard boneyard12;
        Boneyard boneyard6;
        Boneyard emptyBoneyard;

        [SetUp]
        public void SetUpAllTests()
        {
            dummyDomino = new Domino(12, 12);
            boneyard12 = new Boneyard();
            boneyard6 = new Boneyard(6);
            emptyBoneyard = new Boneyard(-1);
        }

        [Test]
        public void TestTesterBoneyard()
        {
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }


        [Test]
        public void BoneyardGetters()
        {
            Assert.AreEqual(91, boneyard12.DominosRemaining);
            Assert.AreEqual(12, boneyard12[0].Side1);
        }

        [Test]
        public void BoneyardSetters()
        {
            Assert.AreEqual(dummyDomino, boneyard12[0]);
            boneyard12[9] = dummyDomino;
            Assert.AreEqual(dummyDomino, boneyard12[9]);
        }

        [Test]
        public void BoneyardDraw()
        {
            Domino d1 = boneyard12[boneyard12.DominosRemaining - 1];
            Domino d2 = boneyard12.Draw();
            Assert.AreEqual(d1, d2);
            
            try
            {
                d1 = boneyard12[91];
                Assert.Fail("The indexer did not throw the expected exception");
            }
            catch(ArgumentOutOfRangeException)
            {
                Assert.Pass("The indexer threw the expexted exception");
            }
        }

        [Test]
        public void BoneyardIsEmpty()
        {
            Assert.IsTrue(emptyBoneyard.IsEmpty());
        }

        [Test]
        public void BoneyardShuffle()
        {
            Boneyard cloneBoneyard = boneyard12;
            Domino d1 = cloneBoneyard[12];
            Assert.AreEqual(cloneBoneyard[12].ToString(), d1.ToString());
            cloneBoneyard.Shuffle();
            Assert.AreNotEqual(cloneBoneyard[12].ToString(), d1.ToString());
        }

        [Test]
        public void BoneyardToString()
        {

        }
    }
}

