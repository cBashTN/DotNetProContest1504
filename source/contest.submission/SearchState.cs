using System.Collections.Generic;

namespace contest.submission
{
    public class SearchState
    {
        public decimal ActualMax { get; set; }
        public decimal ActualMin { get; set; }
        public int ActualMaxIndex { get; set; }
        public int ActualMinIndex { get; set; }
        public int LastIndex { get; set; }
        public decimal ActualEstimatedFigure { get; set; }

        public List<decimal> AskedFigures { get; set; }


        public SearchState()
        {
            Initialize();
        }

        void Initialize()
        {
            ActualMax = decimal.MaxValue;
            ActualMin = decimal.MinValue;

            ActualMaxIndex = 128;
            ActualMinIndex = 0;
            LastIndex = 0;
        }

        public void AddNewAskedFigure()
        {
            AskedFigures.Add(ActualEstimatedFigure);
        }
    }
}
