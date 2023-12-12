namespace BiblePlan.Domain
{
    public class Plan
    {
        public string Name { get; set; } = "Evening";
        public List<string> Books { get; set; } = new List<string>();
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);
        public string StartTime { get; set; } = "6:00 AM";
        public List<string> ReadingDays { get; set; } = new List<string>(); // Days of the week to add a reading
    }
}
