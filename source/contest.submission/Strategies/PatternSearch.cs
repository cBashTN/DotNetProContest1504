using contest.submission.contract;

namespace contest.submission.Strategies
{
    public class PatternSearch : SearchStrategy
    {
        public override SearchState Search(SearchState searchState, Rating actualRating)
        {
            var pos   = PatternSearchHelper.GetPatternPosition(searchState.ActualEstimatedFigure);
            var digit = PatternSearchHelper.GetPatternDigit(searchState.ActualEstimatedFigure);

            decimal dec = searchState.ActualEstimatedFigure;


            //todo
            //change rest of the digits to this digit

            return searchState;
        }
    }
}