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
    public class PrivateTrainTests
    {
        PrivateTrain defaultPrivateTrain;
        Hand defaultHand;
        Domino dummyDomino;

        [SetUp]
        public void SetUpAllTests()
        {
            dummyDomino = new Domino(12, 12);
            defaultHand = new Hand();
            defaultPrivateTrain = new PrivateTrain();
        }

        [Test]
        public void PrivTrainIsOpenMethods()
        {
            defaultPrivateTrain.Close();
            Assert.IsFalse(defaultPrivateTrain.IsOpen);
            defaultPrivateTrain.Open();
            Assert.IsTrue(defaultPrivateTrain.IsOpen);
        }

        [Test]
        public void PrivTrainIsPlayable()
        {
            Assert.IsFalse(defaultPrivateTrain.IsPlayable(dummyDomino, out bool mustFlip, defaultHand));
        }
    }
}
