using BiblePlan.Domain;

namespace BiblePlan.Services
{
    public class PrintService
    {
        public List<Reading> Readings { get; set; }
        public List<string> Dates { get; set; }
        public string Name { get; set; }
        public List<string> Days { get; set; }
    }
}
