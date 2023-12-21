using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public class TextFileFactory : ICalendarFactory
    {
        public async Task<string> GenerateCalendar(Plan plan)
        {
            ReadingFactory factory = new ReadingFactory();
            var result = await factory.GenerateReadings(plan);
            var dates = result.Dates;
            var readings = result.Readings;

            string txt = $"<center><h2>{plan.Name}\n</h2></center><div class=\"container\">";
            for (int i = 0; i < dates.Count; i++)
            {
                txt += $"<div class=\"pair\"><h4>{dates[i]}</h4><h5 style=\"margin-top:-0.65rem;\">{readings[i].ToReadToday}</h5></div>";
            }
            txt += "</div>";
            return txt;
        }
    }
}
