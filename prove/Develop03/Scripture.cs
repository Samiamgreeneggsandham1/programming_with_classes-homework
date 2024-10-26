using System;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(wordText => new Word(wordText)).ToList();
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        var visibleWords = words.Where(word => !word.IsHidden()).ToList();
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }

    public bool IsFullyHidden()
    {
        return words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", words.Select(word => word.GetDisplayText()));
        return $"{reference.GetReferenceText()}\n{scriptureText}";
    }
}