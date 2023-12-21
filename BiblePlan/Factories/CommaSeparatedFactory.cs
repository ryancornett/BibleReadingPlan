using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public class CommaSeparatedFactory : ICalendarFactory
    {
        public async Task<string> GenerateCalendar(Plan plan)
        {
            ReadingFactory factory = new ReadingFactory();
            var result = await factory.GenerateReadings(plan);
            var dates = result.Dates;
            var readings = result.Readings;

            var csv = "Date,Reading";
            for (int i = 0; i < dates.Count; i++)
            {
                csv += $"\n{dates[i]},\"{readings[i].ToReadToday}\"";
            }
            return csv;
        }
    }
}
