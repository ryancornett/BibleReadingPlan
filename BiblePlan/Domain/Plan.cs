namespace BiblePlan.Domain
{
    public class Plan
    {
        public string Name { get; set; }
        public List<string> Books { get; set; } = new List<string>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public List<string> ReadingDays { get; set; }

        public Plan()
        {
            Name = "Your_plan_name";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(14);
            StartTime = "6:30 AM";
            ReadingDays = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        }
    }
}
