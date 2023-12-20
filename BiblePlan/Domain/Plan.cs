namespace BiblePlan.Domain
{
    public class Plan
    {
        public string Name { get; set; } = "Morning";
        public List<string> Books { get; set; } = new List<string>();
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(14);
        public string StartTime { get; set; } = "6:00 AM";
        public List<string> ReadingDays { get; set; } = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    }
}
