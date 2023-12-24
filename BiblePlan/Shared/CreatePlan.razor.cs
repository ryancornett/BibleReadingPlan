using BiblePlan.Domain;
using BiblePlan.Factories;
using BiblePlan.Services;
using Microsoft.JSInterop;
using System.Text;
using System.Text.RegularExpressions;

namespace BiblePlan.Shared
{
    public partial class CreatePlan
    {
        protected override Task OnInitializedAsync()
        {
            /*PrintService.Dates.Clear();
            PrintService.Name = string.Empty;
            PrintService.Readings.Clear();
            PrintService.Days.Clear();*/
            return base.OnInitializedAsync();
        }

        private Plan plan = new Plan();
        private bool selectOldTestament = false;
        private bool selectNewTestament = false;
        private List<int> OTDisplayRanges = new List<int>() { 0,7,7,7,14,7,21,7,28,7,35,4 };
        private List<int> NTDisplayRanges = new List<int>() { 0,6,6,6,12,6,18,6,24,3 };

        private void ToggleBook(string selectedBook)
        {
            if (plan.Books.Contains(selectedBook))
            {
                plan.Books.Remove(selectedBook);
            }
            else
            {
                plan.Books.Add(selectedBook);
            }
        }

        private void ToggleOldTestament()
        {
            selectOldTestament = !selectOldTestament;
            if (selectOldTestament)
            {
                foreach (var book in Books.OldTestament)
                {
                    if (!plan.Books.Contains(book))
                    {
                        plan.Books.Add(book);
                    }
                }
            }
            else
            {
                foreach (var book in Books.OldTestament)
                {
                    if (plan.Books.Contains(book))
                    {
                        plan.Books.Remove(book);
                    }
                }
            }
        }

        private void ToggleNewTestament()
        {
            selectNewTestament = !selectNewTestament;
            if (selectNewTestament)
            {
                foreach (var book in Books.NewTestament)
                {
                    if (!plan.Books.Contains(book))
                    {
                        plan.Books.Add(book);
                    }
                }
            }
            else
            {
                foreach (var book in Books.NewTestament)
                {
                    if (plan.Books.Contains(book))
                    {
                        plan.Books.Remove(book);
                    }
                }
            }
        }

        private void ToggleReadingDay(string selectedDay)
        {
            if (plan.ReadingDays.Contains(selectedDay))
            {
                plan.ReadingDays.Remove(selectedDay);
            }
            else
            {
                plan.ReadingDays.Add(selectedDay);
            }
        }

        private string oldClass = "collapsible";
        private string newClass = "collapsible";
        private string plusOpen = "my-1 plus-open_close oi oi-plus";
        private string minusClose = "my-1 plus-open_close oi oi-minus";
        private string openCloseOld = "my-1 plus-open_close oi oi-plus";
        private string openCloseNew = "my-1 plus-open_close oi oi-plus";

        private void ShowTestament(int t)
        {
            if (t == 1 && openCloseOld == plusOpen)
            {
                openCloseOld = minusClose;
                oldClass = "collapsible.active";
                StateHasChanged();
            }
            else if (t == 1 && openCloseOld ==minusClose)
            {
                openCloseOld = plusOpen;
                oldClass = "collapsible";
                StateHasChanged();
            }
            if (t == 2 && openCloseNew == plusOpen)
            {
                openCloseNew = minusClose;
                newClass = "collapsible.active";
                StateHasChanged();
            }
            else if (t == 2 && openCloseNew == minusClose)
            {
                openCloseNew = plusOpen;
                newClass = "collapsible";
                StateHasChanged();
            }
        }

        private bool showAlert = false;
        private string alertMessage = string.Empty;
        private CommaSeparatedFactory csvFactory = new CommaSeparatedFactory();
        private CalFileFactory calFileFactory = new CalFileFactory();
        private TextFileFactory textFileFactory = new TextFileFactory();
        private DownloadService downloadService = new DownloadService();
        private bool isLoading = false;

        private async Task DownloadCsv()
        {
            if (await PlanIsValid())
            {
                isLoading = true;

                try
                {
                    string csvData = await csvFactory.GenerateCalendar(plan);
                    byte[] csvBytes = await downloadService.GenerateRaw(csvData);
                    string fileName = $"{plan.Name}.csv";
                    string base64 = Convert.ToBase64String(csvBytes);
                    string downloadLink = $"data:text/csv;charset=utf-8;base64,{base64}";
                    await JSRuntime.InvokeVoidAsync("downloadFile", downloadLink, fileName);
                    plan = new Plan();
                }

                catch (Exception ex)
                {
                    await ShowAlert("An error occured. Please try again");
                }

                await Task.Delay(2000);
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task DownloadiCalFile()
        {
            if (await PlanIsValid())
            {
                isLoading = true;

                try
                {
                    string iCalData = await calFileFactory.GenerateCalendar(plan);
                    byte[] icalBytes = downloadService.GenerateICal(iCalData);
                    string fileName = $"{plan.Name}.ics";
                    string base64 = Convert.ToBase64String(icalBytes);
                    string downloadLink = $"data:text/calendar;charset=utf-8;base64,{base64}";
                    await JSRuntime.InvokeVoidAsync("downloadFile", downloadLink, fileName);
                    plan = new Plan();
                }
                catch (Exception ex)
                {
                    await ShowAlert("An error occured. Please try again");
                }
                
                await Task.Delay(2000);
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task DownloadTextFile()
        {
            if (await PlanIsValid())
            {
                isLoading = true;

                try
                {
                    var textData = await textFileFactory.GenerateCalendar(plan);
                    PrintService.Name = plan.Name;
                    PrintService.Days = plan.ReadingDays;
                    PrintService.Readings = textData.Item1;
                    PrintService.Dates = textData.Item2;
                    NavigationManager.NavigateTo("/print", true);
                }
                catch (Exception ex)
                {
                    await ShowAlert("An error occured. Please try again");
                }

                await Task.Delay(2000);
                isLoading = false;
                StateHasChanged();
            }
        }

        private void ResetPlan()
        {
            plan = new Plan();
        }

        private ReadingLogic logic = new ReadingLogic();

        private static string pattern = "[a-zA-Z0-9_-]{1,50}$";
        private async Task<bool> PlanIsValid()
        {
            var chapters = await logic.TotalChapters(plan);
            var days = await logic.DaysInPlan(plan);
            bool isPlanNameValid = Regex.IsMatch(plan.Name, pattern);

            if (!isPlanNameValid)
            {
                await ShowAlert("Name must contain letters, numbers, hyphens, or underscores only and 1-50 characters.");
                return false;
            }
            if (plan.Books.Count == 0)
            {
                await ShowAlert("You need to add some books first!");
                return false;
            }
            if (days.TotalDays > chapters)
            {
                await ShowAlert("Don't you need to add more books?");
                return false;
            }
            if (days.TotalDays < 14)
            {
                await ShowAlert("That's a mighty short plan ya got there!");
                return false;
            }
            if (days.TotalDays > 732)
            {
                await ShowAlert("Let's try a shorter plan, okay?");
                return false;
            }
            if (plan.ReadingDays.Count == 0)
            {
                await ShowAlert("You selected no reading days. Are you trying to get me to divide by zero?");
                return false;
            }
            else { return true; }
            
        }
        private async Task ShowAlert(string message)
        {
            alertMessage = message;
            showAlert = true;
            StateHasChanged();
            await Task.Delay(2700);
            showAlert = false;
            StateHasChanged();
        }
    }
}