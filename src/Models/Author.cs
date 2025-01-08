namespace BeginnerTasks.Models;

public class Author
{
    public int AutorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<QuoteText> Quotes { get; set; }
}