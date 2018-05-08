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
    public class TrainTests
    {
        Domino engineDomino;
        Domino dummyDomino;
        Domino unplayableDomino;
        Train defaultTrain;
        Train sixEngineTrain;
        Boneyard boneyard12;

        [SetUp]
        public void SetUpTrainTests()
        {
            engineDomino = new Domino(6, 6);
            dummyDomino = new Domino(6, 12);
            unplayableDomino = new Domino(1, 1);
            defaultTrain = new Train();
            sixEngineTrain = new Train(6);
            boneyard12 = new Boneyard();
        }

        [Test]
        public void TrainGetters()
        {
            dummyDomino = defaultTrain[0];
            Assert.AreEqual(defaultTrain.Count, 1);
            Assert.IsFalse(defaultTrain.IsEmpty);
            Assert.AreEqual(dummyDomino, defaultTrain.LastDomino);
            Assert.AreEqual(6, defaultTrain.PlayableValue);
        }

        [Test]
        public void TrainSetters()
        {
            defaultTrain.EngineValue = 0;
            Assert.AreEqual(defaultTrain.EngineValue, 0);
        }

        [Test]
        public void TrainAddMethod()
        {
            try
            {
                defaultTrain.Add(dummyDomino);
            }
            catch (Exception e)
            {
                Assert.Fail("The method threw an exception with the message: " +
                    e.Message);
            }
        }

        [Test]
        public void TrainIsPlayable()
        {
            bool mustFlip;
            try
            {
                Assert.IsTrue(defaultTrain.IsPlayable(dummyDomino, out mustFlip));
                Assert.IsFalse(defaultTrain.IsPlayable(unplayableDomino, out mustFlip));
            }
            catch (Exception e)
            {
                Assert.Fail("Method threw an exception with the message "
                    + e.Message);
            }
        }

        [Test]
        public void TrainPlay()
        {
            bool mustFlip;
            try
            {
                Assert.IsTrue(defaultTrain.IsPlayable(dummyDomino, out mustFlip));
                Assert.IsFalse(defaultTrain.IsPlayable(unplayableDomino, out mustFlip));
                defaultTrain.Play(unplayableDomino);
            }
            catch (ArgumentException)
            {
                Assert.Pass("Method threw the proper exception");
            }
        }

        [Test]
        public void TrainShow()
        {
            Assert.AreEqual(defaultTrain.Show(0), engineDomino.ToString());
        }
    }
}
