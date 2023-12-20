using BiblePlan.Services;

namespace BiblePlan.Domain;

public class SelectedDates
{
    private Plan _plan;
    private List<string> _readingDays;
    private int _daysInPlan;
    private ReadingLogic _logic = new ReadingLogic();
    private List<string> _calendarFeed = new List<string>();

    public SelectedDates(Plan plan)
    {
        _readingDays = plan.ReadingDays;
        _plan = plan;
    }

    public async Task<List<string>> GetDates()
    {
        await GetTotalDays(_plan);
        var date = _plan.StartDate.Date;

        for (int i = 0; i < _daysInPlan; i++)
        {
            foreach (var day in _readingDays)
            {
                
                if (date.DayOfWeek.ToString().ToLower() == day.ToLower())
                {
                    _calendarFeed.Add(date.ToShortDateString());
                }
            }
            date = date.AddDays(1);
        }
        return _calendarFeed;
    }

    private async Task GetTotalDays(Plan plan)
    {
        var range = await _logic.DaysInPlan(plan);
        _daysInPlan = await _logic.TotalNumberOfDays(range);
    }
}
