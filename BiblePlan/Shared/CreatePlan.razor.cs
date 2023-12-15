using BiblePlan.Domain;
using BiblePlan.Factories;
using BiblePlan.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.JSInterop;
using MudBlazor;


namespace BiblePlan.Shared
{
    public partial class CreatePlan
    {
        static Plan plan = new Plan();
        private bool selectOldTestament = false;
        private bool selectNewTestament = false;
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

        private void ToggleAllBooks()
        {
            plan.Books.AddRange(Books.BookTitles);
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

        private string showOldTestament = "+";
        private string oldClass = "collapsible";
        private string showNewTestament = "+";
        private string newClass = "collapsible";
        private string openClose = "my-1 plus-open_close";

        private void ShowTestament(int t)
        {
            if (t == 1 && showOldTestament == "+")
            {
                showOldTestament = "-";
                oldClass = "collapsible.active";
                StateHasChanged();
            }
            else if (t == 1 && showOldTestament == "-")
            {
                showOldTestament = "+";
                oldClass = "collapsible";
                StateHasChanged();
            }
            if (t == 2 && showNewTestament == "+")
            {
                showNewTestament = "-";
                newClass = "collapsible.active";
                StateHasChanged();
            }
            else if (t == 2 && showNewTestament == "-")
            {
                showNewTestament = "+";
                newClass = "collapsible";
                StateHasChanged();
            }
        }

        private bool showAlert = false;
        private string alertMessage = string.Empty;
        private CommaSeparatedFactory csvFactory = new CommaSeparatedFactory();
        private CalFileFactory calFileFactory = new CalFileFactory();
        private DownloadService downloadService = new DownloadService();

        private async Task DownloadCsv()
        {
            if (await PlanIsValid())
            {
                string csvData = await csvFactory.GenerateCalendar(plan);

                byte[] csvBytes = await downloadService.GenerateCsv(csvData);

                string fileName = $"{plan.Name}.csv";
                string base64 = Convert.ToBase64String(csvBytes);
                string downloadLink = $"data:text/csv;charset=utf-8;base64,{base64}";

                // Use JavaScript Interop to create a link element and trigger the download
                await JSRuntime.InvokeVoidAsync("downloadFile", downloadLink, fileName);
                plan = new Plan();
                StateHasChanged();
            }
        }

        private async Task DownloadiCalFile()
        {
            if (await PlanIsValid())
            {
                string iCalData = await calFileFactory.GenerateCalendar(plan);

                byte[] icalBytes = downloadService.GenerateICal(iCalData);

                string fileName = $"{plan.Name}.ics";
                string base64 = Convert.ToBase64String(icalBytes);
                string downloadLink = $"data:text/calendar;charset=utf-8;base64,{base64}";

                // Use JavaScript Interop to create a link element and trigger the download
                await JSRuntime.InvokeVoidAsync("downloadFile", downloadLink, fileName);
                plan = new Plan();
                StateHasChanged();
            }
        }

        private ReadingLogic logic = new ReadingLogic();

        private async Task<bool> PlanIsValid()
        {
            var chapters = await logic.TotalChapters(plan);
            var days = await logic.DaysInPlan(plan);
            if (plan.Books.Count == 0)
            {
                ShowAlert("You need to add some books first!");
                return false;
            }
            if (days.TotalDays > chapters)
            {
                ShowAlert("Don't you need to add some more books?");
                return false;
            }
            if (days.TotalDays < 14)
            {
                ShowAlert("That's a mighty short plan ya got there!");
                return false;
            }
            if (days.TotalDays > 732)
            {
                ShowAlert("Let's try a shorter plan, okay?");
                return false;
            }
            else { return true; }
            
        }

        private void ShowAlert(string message)
        {
            alertMessage = message;
            showAlert = true;
            StateHasChanged();
        }
    }
}