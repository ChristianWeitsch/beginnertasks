namespace BeginnerTasks.Models;

public class Quote
{
   
    public Quote(int id, string name, string quoteText, string type)
    {
        Id = id;
        Name = name;
        QuoteText = quoteText;
        Type = type;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string QuoteText { get; set; }
    public string Type { get; set; }
}