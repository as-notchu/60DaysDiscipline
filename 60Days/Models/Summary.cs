namespace _60Days.Models;

public class Summary
{
    public Guid Id { get; set; }
    
    public Guid DayDataId { get; set; }
    
    public DateTime Time { get; set; }
    
    public string Content { get; set; }
}