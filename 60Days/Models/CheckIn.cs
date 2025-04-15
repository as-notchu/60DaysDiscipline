using _60Days.Models.Enum;

namespace _60Days.Models;

public class CheckIn
{
    public Guid Id { get; set; }
    
    public Guid DayDataId { get; set; }
    
    public DateTime Time { get; set; }
    
    public bool OnTime { get; set; }
    
    public PartOfTheDay PartOfTheDay { get; set; }
}