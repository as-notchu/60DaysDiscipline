using _60Days.Models.Enum;

namespace _60Days.Models;

public class DayData
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }

    private int Score { get; set; }

    public Summary Summary { get; set; }
    public List<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
    
    public List<DailyAction> DailyActions { get; set; } = new List<DailyAction>();

    public int GetScore()
    {
        return Score;
    }
    
    public void CalculateScore()
    {
        foreach (var checkIn in CheckIns.Where(checkIn => checkIn.OnTime))
        {
            Score += 2;
        }

        foreach (var actions in DailyActions)
        {
            switch (actions.Type)
            {
                case ActionType.PriorityTask:
                    Score += 4;
                    break;
                case ActionType.UsefulThing:
                    Score += 2;
                    break;
                case ActionType.MightBeUsefulThing:
                    Score += 1;
                    break;
            }
        }
    }
}