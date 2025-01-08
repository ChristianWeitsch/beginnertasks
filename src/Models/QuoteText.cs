namespace BeginnerTasks.Models;

public class QuoteText
{
    public int QuoteTextId { get; set; }
    public string Text { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int TypeId { get; set; }
    public virtual Type QuoteType { get; set; }
}