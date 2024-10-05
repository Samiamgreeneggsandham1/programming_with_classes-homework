using System;

public class Load
{
    public void LoadEntriesFromFile(string fileName, JournalPrompts journalPrompts)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(new[] { " - " }, 2, StringSplitOptions.None);

                        if (parts.Length == 2)
                        {
                            string dateStr = parts[0].Replace("Date: ", "").Trim();
                            string prompt = parts[1];

                            string response = reader.ReadLine();

                            if (!string.IsNullOrEmpty(response))
                            {
                                journalPrompts.AddEntry(dateStr, prompt, response);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing line: {line}\n{ex.Message}");
                    }
                }
                Console.WriteLine("Entries successfully loaded from file.\n");
            }
        }
        else
        {
            Console.WriteLine($"File {fileName} does not exist.");
        }
    }
}