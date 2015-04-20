using System;

namespace contest.submission.contract
{
    public enum Rating { ToLow, ToHigh, Exactly, Start };

    public interface IDnp1504Solution
    {
      void Process(Rating rating);
      event Action<decimal> SendResult;
    }
}
