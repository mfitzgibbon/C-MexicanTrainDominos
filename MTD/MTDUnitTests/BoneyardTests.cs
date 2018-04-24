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

        [SetUp]
        public void SetUpAllTests()
        {
            dummyDomino = new Domino(12, 12);
            boneyard12 = new Boneyard();
            boneyard6 = new Boneyard(6);
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
            Assert.AreEqual(92, boneyard12.DominosRemaining);
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
        public void BoneyardMethods()
        {
            Assert.
        }
    }
}

