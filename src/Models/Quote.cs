namespace BeginnerTasks.Models;

public class Quote
{
   
    public Quote(int id, string type, string location, string category)
    {
        Id = id;
        Type = type;
        Location = location;
        Category = category;
    }

    public int Id { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
}