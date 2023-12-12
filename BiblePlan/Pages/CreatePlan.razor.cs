using Microsoft.JSInterop;
using BiblePlan.Domain;
using BiblePlan.Factories;
using BiblePlan.Services;

namespace BiblePlan.Pages
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

        private ReadingFactory readingFactory = new ReadingFactory();
        private async Task Generate()
        {
            var readings = await readingFactory.GenerateReadings(plan);
            for (int i = 0; i<readings.Count; i++)
            {
                readings[i].ToReadToday.LogThis("Testing", Result.Success);
            }

            JSRuntime.InvokeVoidAsync("console.log", $"The number of readings = {readings.Count()}");
            StateHasChanged();
        }
    }
}