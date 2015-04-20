using System;
using contest.submission.contract;
using contest.submission.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace contest.submission.Tests
{
    [TestClass()]
    public class SearchesTests
    {
        [TestMethod()]
        public void IsItZeroSearch_Test()
        {
            var interviewee = new Interlocutor();
            
            interviewee.SetSearchStrategy(new IsItZeroSearch());
            interviewee.SearchFigure(Rating.Start);

            Assert.AreEqual(0, interviewee.FoundFigure());
        }

        [TestMethod()]
        public void DummyBinarySearch_Plus_Test()
        {
            var interviewee = new Interlocutor();

            interviewee.SetSearchStrategy(new SimpleBinarySearch());
            interviewee.SearchFigure(Rating.ToLow);

            Assert.AreEqual(Decimal.MaxValue / 2m, interviewee.FoundFigure());
        }

        [TestMethod()]
        public void DummyBinarySearch_Minus_Test()
        {
            var interviewee = new Interlocutor();

            interviewee.SetSearchStrategy(new SimpleBinarySearch());
            interviewee.SearchFigure(Rating.ToHigh);

            Assert.AreEqual(-1* Decimal.MaxValue / 2m, interviewee.FoundFigure());
        }

        [TestMethod()]
        public void CleverBinarySearch_Test()
        {
            var interviewee = new Interlocutor();

            interviewee.SetSearchStrategy(new CleverBinarySearch());
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[0]); 
            interviewee.SearchFigure(Rating.ToLow);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[64]);
            interviewee.SearchFigure(Rating.ToHigh);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[32]);
            interviewee.SearchFigure(Rating.ToHigh);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[16]);
            interviewee.SearchFigure(Rating.ToHigh);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[8]);
            interviewee.SearchFigure(Rating.ToLow);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[12]);
            interviewee.SearchFigure(Rating.ToHigh);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[10]);
            interviewee.SearchFigure(Rating.ToLow);
            Assert.AreEqual(interviewee.FoundFigure(), CleverBinarySearchTable.Table[11]);
        }

    }
}
