using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public class CalFileFactory : ICalendarFactory
    {
        public async Task<string> GenerateCalendar(List<Reading> reading)
        {
            var iCal = string.Empty;
            return iCal;
        }
    }
}
