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
    public class HandTests
    {
        Domino domino12;
        Hand defaultHand;
        Boneyard defaultBoneyard;
        Hand overloadedHand;
        Domino domino6;

        [SetUp]
        public void SetUpAllTests()
        {
            domino12 = new Domino(12, 12);
            domino6 = new Domino(6, 6);
            defaultHand = new Hand();
            defaultBoneyard = new Boneyard();
        }

        [Test]
        public void HandOverloadedConstructors()
        {
            try
            {

                overloadedHand = new Hand(defaultBoneyard, 1);
            } catch (ArgumentException)
            {
                Assert.Pass("The constructor threw the proper exception");
            }

            try
            {
                overloadedHand = new Hand(defaultBoneyard, 9);
            } catch (ArgumentException)
            {
                Assert.Pass("The constructor threw the proper exception");
            }

            try
            {
                overloadedHand = new Hand(defaultBoneyard, 4);
                Assert.Pass("overloadedHand did not throw an exception");
            } catch (Exception)
            {
                Assert.Fail("overloaded hand should not throw an exception");
            }
        }

        [Test]
        public void HandDominoHasAndGets()
        {
           defaultHand.Add(domino12);

            Assert.True(defaultHand.HasDomino(domino12.Side1));
            Assert.True(defaultHand.HasDoubleDomino(domino12.Side1));

            Assert.IsNotNull(defaultHand.GetDomino(domino12.Side1));
            Assert.IsNull(defaultHand.GetDoubleDomino(-1));
        }

        [Test]
        public void HandDominoIndexers()
        {
            try
            {
                defaultHand.IndexOfDomino(-1);
            }catch(Exception)
            {
                Assert.Pass("Method threw the proper exception");
            }

            try
            {
                defaultHand.IndexOfDoubleDomino(-1);
            }catch(Exception)
            {
                Assert.Pass("Method threw the proper exception");
            }

            try
            {
                Domino d = defaultHand.GetDoubleDomino(12);
                defaultHand.IndexOfHighDouble();
            }catch(Exception)
            {
                Assert.Pass("Method threw the expected exception");
            }
        }

    }
}
