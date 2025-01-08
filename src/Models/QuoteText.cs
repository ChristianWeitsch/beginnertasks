namespace BeginnerTasks.Models;

public class QuoteText
{
    public required int QuoteTextId { get; set; }
    public string Text { get; set; }
    public required int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public required int TypeId { get; set; }
    public virtual Type QuoteType { get; set; }
}