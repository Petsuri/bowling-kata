using NUnit.Framework;

namespace BowlingKata.UnitTests
{
    class BowlingGameTests
    {
        [Test]
        public void Throwing_WithGameOfAllThrowsBeingStrike_GivesScoreOf300()
        {
            var sut = new BowlingGameBuilder().Build();

            for(var i = 0; i < 12; i++)
            {
                sut.AddThrow(10);
            }
            var actual = sut.GetScore();

            Assert.AreEqual(300, actual);
        }

        [Test]
        public void AskingScore_WithFourFirstThrowsBeingAStrike_IsExpected()
        {
            var sut = new BowlingGameBuilder().Build();

            sut.AddThrow(10);
            sut.AddThrow(10);
            sut.AddThrow(10);
            sut.AddThrow(10);
            var actual = sut.GetScore();

            Assert.AreEqual(90, actual);
        }

        [Test]
        public void AskingScore_WithThrowingSpares_IsExpected()
        {
            var sut = new BowlingGameBuilder().Build();

            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddThrow(4);
            sut.AddThrow(10);
            var actual = sut.GetScore();

            Assert.AreEqual(49, actual);
        }

        [Test]
        public void Throwing_WithGameWithoutStrikesOrSpares_IsExpected()
        {
            var sut = new BowlingGameBuilder().Build();

            for(var i = 0; i < 10; i++)
            {
                sut.AddThrow(9);
                sut.AddThrow(0);
            }
            var actual = sut.GetScore();

            Assert.AreEqual(90, actual);
        }

        [Test]
        public void Throwing_WithGameFullOfSpares_IsExpected()
        {
            var sut = new BowlingGameBuilder().Build();

            for (var i = 0; i < 10; i++)
            {
                sut.AddThrow(5);
                sut.AddThrow(5);
            }
            sut.AddThrow(5);
            var actual = sut.GetScore();

            Assert.AreEqual(150, actual);
        }
    }
}
