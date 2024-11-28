using DemoEinfacherKalender.Data;
using DemoEinfacherKalender.Models;

namespace DemoEinfacherKalender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new CalendarContext())
                {
                    // Create: Neuer Kalendereintrag
                    var newEntry = new CalendarEntry
                    {
                        Title = "Meeting mit allen Entwicklern",
                        Description = "Daily",
                        StartDate = new DateTime(2024, 12, 1, 9, 0, 0),
                        EndDate = new DateTime(2024, 12, 1, 10, 0, 0)
                    };
                    context.CalendarEntries.Add(newEntry);
                    context.SaveChanges();
                    Console.WriteLine("Neuer Kalendereintrag hinzugefügt!");

                    // Read: Alle Einträge anzeigen
                    Console.WriteLine("Kalendereinträge:");
                    var entries = context.CalendarEntries.OrderBy(e => e.StartDate).ToList();
                    foreach (var entry in entries)
                    {
                        Console.WriteLine($"{entry.Id}: {entry.Title} ({entry.StartDate:g} - {entry.EndDate:g})");
                    }

                    // Update: Einen Eintrag bearbeiten
                    var entryToUpdate = context.CalendarEntries.First();
                    entryToUpdate.Description = "Aktualisierte Besprechung";
                    context.SaveChanges();
                    Console.WriteLine("Eintrag aktualisiert!");

                    // Delete: Einen Eintrag löschen
                    var entryToDelete = context.CalendarEntries.OrderBy(e => e.StartDate).Last();
                    context.CalendarEntries.Remove(entryToDelete);
                    context.SaveChanges();
                    Console.WriteLine("Eintrag gelöscht!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Drücke eine Taste zum Beenden...");
                Console.ReadKey();
            }

        }
    }
}
