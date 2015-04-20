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
    public class SolutionTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var solution = new Solution();

            for (int i = 0; i < 100; i++)
            {
                solution.Process(Rating.Exactly);
            }

        }

    }
}
