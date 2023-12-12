using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public class CommaSeparatedFactory : ICalendarFactory
    {
        public async Task<string> GenerateCalendar(List<Reading> reading)
        {
            var csv = string.Empty;
            return csv;
        }
    }
}
