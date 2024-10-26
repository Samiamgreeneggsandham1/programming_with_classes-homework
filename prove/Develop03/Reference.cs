using System;

public class Reference
{
    private string bookName;
    private int startChapter;
    private int startVerse;
    private int? endVerse;

    private Reference(string bookName, int startChapter, int startVerse, int? endVerse = null)
    {
        this.bookName = bookName;
        this.startChapter = startChapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public static Reference CreateFromUserInput()
    {
        Console.Write("Enter the book name: ");
        string bookName = Console.ReadLine();

        Console.Write("Enter the starting chapter: ");
        int startChapter = int.Parse(Console.ReadLine());

        Console.Write("Enter the starting verse: ");
        int startVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter the ending verse (or press Enter to skip): ");
        string endVerseInput = Console.ReadLine();
        int? endVerse = string.IsNullOrWhiteSpace(endVerseInput) ? (int?)null : int.Parse(endVerseInput);

        return new Reference(bookName, startChapter, startVerse, endVerse);
    }

    public string GetReferenceText()
    {
        return endVerse.HasValue
            ? $"{bookName} {startChapter}:{startVerse}-{endVerse}"
            : $"{bookName} {startChapter}:{startVerse}";
    }
}
