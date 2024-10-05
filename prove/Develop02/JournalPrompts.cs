using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Mail;
using System.IO;

public class JournalPrompts
{
    public List<string> _journalPrompts = new List<string>
    {
        "What was the most beautiful thing you witnessed today?",
        "What was the yummiest thing you had today?",
        "Did you smell anything good today?",
        "Did you listen to any good songs today?",
        "Was there anything painful about your day?",
        "If you were to choose an animal to describe your day, what would it be and why?",
        "What was a good idea you had recently?"
    };

    private List<JournalEntry> _journalEntries = new List<JournalEntry>();
    
    Random _random = new Random();

    public string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_journalPrompts.Count);
        return _journalPrompts[randomIndex];
    }

    public void AddEntry(string response, string prompt)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        JournalEntry entry = new JournalEntry(date, prompt, response);
        _journalEntries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_journalEntries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (var entry in _journalEntries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }

    public List<JournalEntry> GetEntries()
    {
        return _journalEntries;
    }

    public void AddEntry(string date, string prompt, string response)
    {
        JournalEntry entry = new JournalEntry(date, prompt, response);
        _journalEntries.Add(entry);
    }
}