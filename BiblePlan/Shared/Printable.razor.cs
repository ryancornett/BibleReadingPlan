using Microsoft.JSInterop;
using BiblePlan.Domain;
using BiblePlan.Services;

namespace BiblePlan.Shared
{
    public partial class Printable
    {
        private string title;
        public List<string> dates;
        private List<Reading> readings;
        public List<string> days;
        protected override Task OnInitializedAsync()
        {
            title = PrintService.Name;
            dates = PrintService.Dates;
            readings = PrintService.Readings;
            days = PrintService.Days;
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("printPage");
        }

        private List<List<TableRowData>> GetTableItems()
        {
            var count = dates.Count;
            var tableItems = new List<List<TableRowData>>();
            for (int i = 0; i < count; i += days.Count)
            {
                var rowItems = new List<TableRowData>();
                for (int j = 0; j < days.Count && i + j < count; j++)
                {
                    var rowData = new TableRowData();
                    if (i + j < dates.Count)
                    {
                        rowData.DateString = dates[i + j];
                    }

                    if (i + j < readings.Count)
                    {
                        rowData.SelectedReading = readings[i + j].ToReadToday;
                    }

                    rowItems.Add(rowData);
                }

                tableItems.Add(rowItems);
            }

            return tableItems;
        }

        public class TableRowData
        {
            public string DateString { get; set; }
            public string SelectedReading { get; set; }
        }
    }
}