namespace BeginnerTasks.Models;

public class Type
{
    public required int TypeId { get; set; }
    public string TypeText { get; set; }
    
    public virtual ICollection<QuoteText> Quotes { get; set; }
}