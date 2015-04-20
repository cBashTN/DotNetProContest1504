using System;
using contest.submission.contract;

namespace contest.submission
{
  [Serializable]
  public class Solution : IDnp1504Solution
  {
    decimal estimatedfigure = 0.918237128344444444m;
    public void Process(Rating rating)
    {
      if (rating == Rating.ToHigh) estimatedfigure = estimatedfigure * 0.99m;
      if (rating == Rating.ToLow) estimatedfigure = estimatedfigure * 1.1m;
      
      SendResult(estimatedfigure);
    }

    public event Action<decimal> SendResult;
  }
}
