using System;
using contest.submission.contract;
using contest.submission.Strategies;

namespace contest.submission
{
    [Serializable]
    public class Solution : IDnp1504Solution
    {
        private readonly Interlocutor _interviewee = new Interlocutor();

        private int _askedCount = 0;
        private bool _isMinusFigure;

        public void Process(Rating rating)
        {
            if (_askedCount==1)
            {
                _isMinusFigure = (rating == Rating.ToHigh);
            }
            

            if (_isMinusFigure)
            {
                if (_askedCount <= 7)
                {
                    _interviewee.SetSearchStrategy(new CleverBinaryMinusSearch());
                }
                else
                {
                    _interviewee.SetSearchStrategy(new SimpleBinaryMinusSearch());
                }
            }
            else
            {
                if (_askedCount <= 7)
                {
                    _interviewee.SetSearchStrategy(new CleverBinarySearch());
                }
                else
                {
                    _interviewee.SetSearchStrategy(new SimpleBinarySearch());
                }
            }

            _interviewee.SearchFigure(rating);
           
            SendResult(_interviewee.FoundFigure());
            _askedCount++;

        }

        public event Action<decimal> SendResult;
    }
}