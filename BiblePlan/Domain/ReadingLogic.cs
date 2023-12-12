namespace BiblePlan.Domain;

public class ReadingLogic
{
    public async Task<TimeSpan> DaysInPlan(Plan plan)
    {
        return plan.EndDate.Date - plan.StartDate.Date;
    }

    public async Task<double> AverageDailyWordCount(double daysInPlan, int totalCount)
    {
        return totalCount / daysInPlan;
    }

    public async Task<int> TotalChapters(Plan plan)
    {
        int total = 0;
        foreach (var book in plan.Books)
        {
            var count = Books.BooksWithNumberOfChapters[book];
            total += count;
        }
        return total;
    }
}
