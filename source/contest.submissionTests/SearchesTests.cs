using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contest.submission;
using contest.submission.contract;
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

            Assert.AreEqual(interviewee.FoundFigure(), 0);
        }

        [TestMethod()]
        public void DummyBinarySearch_Plus_Test()
        {
            var interviewee = new Interlocutor();

            interviewee.SetSearchStrategy(new DummyBinarySearch());
            interviewee.SearchFigure(Rating.ToLow);

            Assert.AreEqual(interviewee.FoundFigure(), Decimal.MaxValue/2m);
        }

        [TestMethod()]
        public void DummyBinarySearch_Minus_Test()
        {
            var interviewee = new Interlocutor();

            interviewee.SetSearchStrategy(new DummyBinarySearch());
            interviewee.SearchFigure(Rating.ToHigh);

            Assert.AreEqual(interviewee.FoundFigure(), -1* Decimal.MaxValue / 2m);
        }

    }
}
