namespace BiblePlan.Domain;

public class ReadingLogic
{

    public async Task<TimeSpan> DaysInPlan(Plan plan)
    {
        TimeSpan timeDifference = plan.EndDate.Date - plan.StartDate.Date;
        return timeDifference + TimeSpan.FromDays(1);
    }

    public async Task<int> TotalNumberOfDays(TimeSpan span)
    {
        return (int)span.TotalDays;
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

    public async Task<int> TotalPlanLength(Plan plan)
    {
        int total = 0;
        foreach (var book in plan.Books)
        {
            int runningTotal = 0;
            var list = Books.BooksWithChapterWordCounts[book];
            foreach (var num in list) { runningTotal += num; }
            total += runningTotal;
        }
        return total;
    }
}