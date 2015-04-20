using System;
using contest.submission.contract;

namespace contest.submission
{
    [Serializable]
    public class Solution : IDnp1504Solution
    {
        private readonly Interlocutor _interviewee = new Interlocutor();
        private bool _isFirstTime = true;

        public void Process(Rating rating)
        {
            if (_isFirstTime)
            {
                _isFirstTime = false;

                // Check if its zero
                _interviewee.SetSearchStrategy(new IsItZeroSearch());
                _interviewee.SearchFigure(rating);
                SendResult(_interviewee.FoundFigure());

                //After initial question it's wise to change the strategy
                _interviewee.SetSearchStrategy(new DummyBinarySearch());
            }
            else
            {
                _interviewee.SearchFigure(rating);
                SendResult(_interviewee.FoundFigure());
            }
        }

        public event Action<decimal> SendResult;
    }
}