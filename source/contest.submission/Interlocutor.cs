using contest.submission.contract;

namespace contest.submission
{
    public class Interlocutor
    {
        private readonly SearchState _searchState = new SearchState();
        private SearchStrategy _sortstrategy = new IsItZeroSearch();

        public void SetSearchStrategy(SearchStrategy strategy)
        {
            _sortstrategy = strategy;
        }

        public void SearchFigure(Rating actualRating)
        {
            _sortstrategy.Search(_searchState, actualRating);
        }

        public decimal FoundFigure()
        {
            return _searchState.ActualEstimatedFigure;
        }
    }
}