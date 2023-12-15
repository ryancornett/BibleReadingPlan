using BiblePlan.Domain;
using System.Text;

namespace BiblePlan.Factories
{
    public class CalFileFactory : ICalendarFactory
    {
        public async Task<string> GenerateCalendar(Plan plan)
        {
            ReadingFactory factory = new ReadingFactory();
            var result = await factory.GenerateReadings(plan);
            var dates = result.Dates;
            var readings = result.Readings;
            var iCal = BuildEvents(dates, readings, plan);
            return iCal;
        }

        private string BuildEvents(List<string> dates, List<Reading> readings, Plan plan)
        {
            StringBuilder icalBuilder = new StringBuilder();

            for (int i = 0; i < dates.Count(); i++)
            {
                var startString = $"{dates[i]} {plan.StartTime}";
                DateTime start = DateTime.Parse(startString);
                icalBuilder.AppendLine("BEGIN:VEVENT");
                icalBuilder.AppendLine($"SUMMARY:{readings[i].ToReadToday}");
                icalBuilder.AppendLine($"DTSTART:{start.ToUniversalTime().ToString("yyyyMMddTHHmmssZ")}");
                icalBuilder.AppendLine("END:VEVENT");
            }

            return icalBuilder.ToString();
        }
    }
}
