using BiblePlan.Domain;
using BiblePlan.Services;

namespace BiblePlan.Factories;

public class ReadingFactory
{
    private int _runningCount;
    private int _totalDays;
    private double _averageDailyWordCount;
    private int _chaptersRemaining;
    private ReadingLogic _logic = new ReadingLogic();
    public SelectedDates? SelectedDates;
    public List<string>? dates;
    public async Task GetPlanData(Plan plan)
    {
        SelectedDates = new SelectedDates(plan);
        dates = await SelectedDates.GetDates();
        _runningCount = await _logic.TotalPlanLength(plan);
        _totalDays = dates.Count();
        _averageDailyWordCount = await _logic.AverageDailyWordCount(_totalDays, _runningCount);
        _chaptersRemaining = await _logic.TotalChapters(plan);
    }

    private List<Reading> readings = new List<Reading>();

    public async Task<(List<Reading>? Readings, List<string>? Dates)> GenerateReadings(Plan plan)
    {
        readings.Clear();
        await GetPlanData(plan);
        int day = 0;
        int daysRemaining = _totalDays;
        var bookTitlesInPlan = plan.Books;
        var numberOfBooksInPlan = bookTitlesInPlan.Count();
        int workingBook = 0;
        int workingChapter = 0;

        while (daysRemaining > 0)
        {
            day++;
            int wordCount;
            var reading = new Reading();
            readings.Add(reading);
            if (workingBook > numberOfBooksInPlan) { break; }
            int chaptersInBook = Books.BooksWithNumberOfChapters[bookTitlesInPlan[workingBook]];
            if (workingChapter >= chaptersInBook)
            {
                workingBook++;
                chaptersInBook = Books.BooksWithNumberOfChapters[bookTitlesInPlan[workingBook]];
                workingChapter = 0;
            }
 
            reading.ToReadToday = (bookTitlesInPlan[workingBook] == "Psalms" ? $"Psalm {workingChapter + 1}" : $"{bookTitlesInPlan[workingBook]} {workingChapter + 1}");
            var currentBookWordCounts = Books.BooksWithChapterWordCounts[bookTitlesInPlan[workingBook]];
            wordCount = currentBookWordCounts[workingChapter];

            while (wordCount < (_runningCount / daysRemaining) - 100)
            {
                if (daysRemaining == _chaptersRemaining) { break; }
                workingChapter++;
                _chaptersRemaining--;
                if (workingChapter >= chaptersInBook)
                {
                    workingBook++;
                    chaptersInBook = Books.BooksWithNumberOfChapters[bookTitlesInPlan[workingBook]];
                    workingChapter = 0;
                }
                if (workingBook > numberOfBooksInPlan) { break; }
                else
                {
                    reading.ToReadToday += workingChapter == 0 ? $", {bookTitlesInPlan[workingBook]} {workingChapter + 1}" : $", {workingChapter + 1}";
                    if (workingBook <= numberOfBooksInPlan)
                    {
                        currentBookWordCounts = Books.BooksWithChapterWordCounts[bookTitlesInPlan[workingBook]];
                        try
                        {
                            wordCount += currentBookWordCounts[workingChapter];
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                    }
                }
            }
            _runningCount -= wordCount;
            workingChapter++;
            _chaptersRemaining--;
            if (workingChapter >= chaptersInBook)
            {
                workingBook++;
                workingChapter = 0;
            }
            daysRemaining--;
        }

        return (Readings: readings, Dates: dates);
    }
}
