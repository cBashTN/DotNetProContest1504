using contest.submission.contract;

namespace contest.submission
{
    public abstract class SearchStrategy
    {
        public abstract SearchState Search(SearchState searchState, Rating actualRating);
    }
}