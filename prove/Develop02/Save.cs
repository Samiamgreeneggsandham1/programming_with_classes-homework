using System;
using System.IO;

public class Save
{
    public void SaveEntriesToFile(string fileName, JournalPrompts journalPrompts)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false))
        {
            foreach (var entry in journalPrompts.GetEntries())
            {
                writer.WriteLine(entry.ToString());
            }
        }

        Console.WriteLine($"Entries saved to {fileName}");
    }
}