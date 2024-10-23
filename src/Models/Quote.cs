namespace BeginnerTasks.Models;

public class Quote
{
    public Quote()
    {
    }
    public Quote(int id, string text, string author, string category)
    {
        Id = id;
        Text = text;
        Author = author;
        Category = category;
    }

    public int Id { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
}