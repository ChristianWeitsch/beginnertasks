namespace BeginnerTasks.Models;

public class Type
{
    public int TypeId { get; set; }
    public string TypeText { get; set; }
    public virtual ICollection<QuoteText> Quotes { get; set; }
}