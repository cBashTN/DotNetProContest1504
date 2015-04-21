using contest.submission.contract;

namespace contest.submission.Strategies
{
    public class SimpleBinaryMinusSearch : SearchStrategy
    {
        private static decimal ActualEstimatedFigure(SearchState searchState)
        {
            return decimal.Divide(searchState.ActualMax, 2m) + decimal.Divide(searchState.ActualMin, 2m);
        }

        public override SearchState Search(SearchState searchState, Rating actualRating)
        {
            if (actualRating == Rating.ToLow) searchState.ActualMax = ActualEstimatedFigure(searchState);
            if (actualRating == Rating.ToHigh) searchState.ActualMin = ActualEstimatedFigure(searchState);

            searchState.ActualEstimatedFigure = ActualEstimatedFigure(searchState);

            return searchState;
        }
    }
}