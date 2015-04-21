using contest.submission.contract;

namespace contest.submission.Strategies
{
    public class CleverBinaryMinusSearch : SearchStrategy
    {
        public override SearchState Search(SearchState searchState, Rating actualRating)
        {
            if (actualRating == Rating.ToLow)
            {
                searchState.ActualMax = searchState.ActualEstimatedFigure; 
                searchState.ActualMaxIndex = searchState.LastIndex;
                searchState.LastIndex = (searchState.ActualMaxIndex + searchState.ActualMinIndex) / 2;
                searchState.ActualEstimatedFigure =  -1 * CleverBinarySearchTable.Table[searchState.LastIndex];
            }
            else
            {
                searchState.ActualMin = searchState.ActualEstimatedFigure;
                searchState.ActualMinIndex = searchState.LastIndex;
                searchState.LastIndex = (searchState.ActualMaxIndex + searchState.ActualMinIndex) / 2;
                searchState.ActualEstimatedFigure =  -1 * CleverBinarySearchTable.Table[searchState.LastIndex];
            }
            searchState.AddNewAskedFigure();

            return searchState;
        }
    }
}