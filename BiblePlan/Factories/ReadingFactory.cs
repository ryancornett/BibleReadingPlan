using BiblePlan.Domain;
using BiblePlan.Services;

namespace BiblePlan.Factories;

public class ReadingFactory
{
    private List<int> _chapterLengths = new List<int>();
    private int _totalLength;
    private double _totalDays;
    private double _averageDailyWordCount;
    private int _totalChapters;
    private ReadingLogic _logic = new ReadingLogic();

    public async Task GenerateReadingPlanData(Plan plan)
    {
        _totalLength = await TotalPlanLength(plan);
        TimeSpan totalDaysAsync = await DaysInPlan(plan);
        _totalDays = totalDaysAsync.TotalDays;
        _averageDailyWordCount = await AverageDailyWordCount(_totalDays, _totalLength);
        _totalChapters = await TotalChapters(plan);
    }

    public List<Reading> readings = new List<Reading>();

    // workingBook needs to be tied to bookTitlesInPlan, not Books.Titles
    // Why does the plan return one more chapter than exists?
    // Why does the factory not add chapters to previously created daily readings?

    public async Task<List<Reading>> GenerateReadings(Plan plan)
    {
        readings.Clear();
        GenerateReadingPlanData(plan);
        int day = 0;
        int daysRemaining = (int)_totalDays;
        int planLength = (int)_totalDays;
        int averageWordCount = (int)_averageDailyWordCount;
        int runningCount = _totalLength;
        var bookTitlesInPlan = plan.Books;
        var numberOfBooksInPlan = bookTitlesInPlan.Count();
        int workingBook = 0;
        int workingChapter = 0;
        int chaptersRemaining = _totalChapters;

        day.LogThis($"Days remaining: {daysRemaining}, Average word count: {averageWordCount}, Number of books in plan: {numberOfBooksInPlan}", Result.Unknown);

        while (daysRemaining > 0)
        {
            day++;
            int wordCount = 0;
            var reading = new Reading();
            readings.Add(reading);
            if (workingBook >= numberOfBooksInPlan) { break; }
            int chaptersInBook = Books.BooksWithNumberOfChapters[bookTitlesInPlan[workingBook]];
            if (workingChapter >= chaptersInBook)
            {
                workingBook++;
                workingChapter = 0;
            }
 
            reading.ToReadToday = $"Day {day}: {bookTitlesInPlan[workingBook]} {workingChapter + 1}";
            var currentBookWordCounts = Books.BooksWithChapterWordCounts[bookTitlesInPlan[workingBook]];
            wordCount = currentBookWordCounts[workingChapter];

            while (wordCount < (runningCount / daysRemaining) && daysRemaining != chaptersRemaining);
            {
                workingChapter++;
                if (workingChapter >= chaptersInBook)
                {
                    workingBook++;
                    workingChapter = 0;
                }
                if (workingBook >= numberOfBooksInPlan) { break; }
                else
                {
                    if (workingBook >= numberOfBooksInPlan) { break; }
                    reading.ToReadToday += workingChapter == 0 ? $", {bookTitlesInPlan[workingBook]} {workingChapter + 1}" : $", {workingChapter + 1}";
                    if (workingBook < numberOfBooksInPlan)
                    {
                        currentBookWordCounts = Books.BooksWithChapterWordCounts[bookTitlesInPlan[workingBook]];
                        try
                        {
                            wordCount += currentBookWordCounts[workingChapter];
                        }
                        catch (Exception e)
                        {
                            e.LogThis($"{e} is the exception on word count = {wordCount} and working book {bookTitlesInPlan[workingBook]} in working chapter {workingChapter}", Result.Failure);
                        }
                    }
                }
            }
            runningCount -= wordCount;
            workingChapter++;
            if (workingChapter >= chaptersInBook)
            {
                workingBook++;
                workingChapter = 0;
            }
            daysRemaining--;

        }

        readings.LogThis($"Log ID 8675309: Number of readings = {readings.Count} - ", Result.Unknown);
        return readings;
    }

    public async Task<TimeSpan> DaysInPlan(Plan plan)
    {
        return plan.EndDate.Date - plan.StartDate.Date;
    }

    public async Task<int> TotalPlanLength(Plan plan)
    {
        int total = 0;
        foreach (var book in plan.Books)
        {
            int runningTotal = 0;
            var list = Books.BooksWithChapterWordCounts[book];
            foreach (var num in list)
            {
                runningTotal += num;
                _chapterLengths.Add(num);
            }
            total += runningTotal;
        }
        return total;
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
