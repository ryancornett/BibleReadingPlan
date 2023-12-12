namespace BiblePlan.Domain;

public class ReadingLogic
{
    public int SumOfChapterWordCounts(List<int> indeces, string book)
    {
        int result = 0;
        foreach (var index in indeces)
        {
            var count = Books.BooksWithChapterWordCounts[book][index];
            result += count;
        }
        return result;
    }
}
