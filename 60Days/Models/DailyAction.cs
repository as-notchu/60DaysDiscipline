using _60Days.Models.Enum;

namespace _60Days.Models;

public class DailyAction
{
    public Guid Id { get; set; }
    public Guid DayDataId { get; set; }

    public DateTime Time { get; set; }

    public ActionType Type { get; set; } // PriorityTaskDone, UsefulActivity, etc.

    public string Description { get; set; }
}