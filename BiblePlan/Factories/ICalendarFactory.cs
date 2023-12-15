using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public interface ICalendarFactory
    {
        public Task<string> GenerateCalendar(Plan plan);
    }
}
