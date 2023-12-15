using System.Text;

namespace BiblePlan.Services
{
    public class DownloadService
    {
        public async Task<byte[]> GenerateCsv(string csvData)
        {
            byte[] csvBytes;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    await writer.WriteAsync(csvData);
                }

                csvBytes = memoryStream.ToArray();
            }

            return csvBytes;
        }

        public byte[] GenerateICal(string eventData)
        {
            string icalData = $"BEGIN:VCALENDAR\nVERSION:2.0\n{eventData}END:VCALENDAR";

            byte[] icalBytes = Encoding.UTF8.GetBytes(icalData);

            return icalBytes;
        }
    }
}
