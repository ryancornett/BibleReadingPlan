using BiblePlan.Domain;

namespace BiblePlan.Factories
{
    public class TextFileFactory
    {
        public async Task<(List<Reading>, List<string>)> GenerateCalendar(Plan plan)
        {
            ReadingFactory factory = new ReadingFactory();
            return await factory.GenerateReadings(plan);
        }
    }
}