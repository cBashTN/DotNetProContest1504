using contest.submission.contract;

namespace contest.submission.Strategies
{
    public class SimpleBinarySearch : SearchStrategy
    {
        private static decimal ActualEstimatedFigure(SearchState searchState)
        {
            return decimal.Divide(searchState.ActualMax, 2m) + decimal.Divide(searchState.ActualMin, 2m);
        }

        public override SearchState Search(SearchState searchState, Rating actualRating)
        {
            if (actualRating == Rating.Start)
            {
                searchState.ActualMax = decimal.MaxValue;
                searchState.ActualMin = decimal.MinValue;
            }
            else
            {
                if (actualRating == Rating.ToHigh) searchState.ActualMax = ActualEstimatedFigure(searchState);
                if (actualRating == Rating.ToLow) searchState.ActualMin = ActualEstimatedFigure(searchState);
            }
            searchState.ActualEstimatedFigure = ActualEstimatedFigure(searchState);
            return searchState;
        }
    }
}