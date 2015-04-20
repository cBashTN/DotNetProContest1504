using System;
using contest.submission.contract;

namespace contest.submission
{
    [Serializable]
    public class Solution : IDnp1504Solution
    {
        private decimal _actualMax;
        private decimal _actualMin;

        private decimal ActualEstimatedFigure
        {
            get{ return decimal.Divide(_actualMax, 2m) + decimal.Divide(_actualMin, 2m);}
        }

        public void Process(Rating rating)
        {
            if (rating == Rating.Start)
            {
                _actualMax = decimal.MaxValue;
                _actualMin = decimal.MinValue;
            }
            else
            {
                if (rating == Rating.ToHigh) _actualMax = ActualEstimatedFigure;
                if (rating == Rating.ToLow)  _actualMin = ActualEstimatedFigure;
            }
            SendResult(ActualEstimatedFigure);
        }

        public event Action<decimal> SendResult;
    }
}
