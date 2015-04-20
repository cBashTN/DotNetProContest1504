using contest.submission.contract;

namespace contest.submission
{
    public class IsItZeroSearch : SearchStrategy
    {
        public override SearchState Search(SearchState searchState, Rating actualRating)
        {
            searchState.ActualEstimatedFigure = 0;
            return searchState;
        }
    }
}