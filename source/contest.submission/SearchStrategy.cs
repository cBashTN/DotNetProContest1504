using contest.submission.contract;

namespace contest.submission
{
    internal abstract class SearchStrategy
    {
        public abstract SearchState Search(SearchState searchState, Rating actualRating);
    }
}