namespace FirstMVC.Models;

public class OfficeDayInfoModel
{
    public TimeSpan TimeBeginWork { get; set; }
    public TimeSpan TimeEndWork { get; set; }
    public TimeSpan TimeBeginLunch { get; set; }
    public TimeSpan TimeEndLunch { get; set; }
    public int Day { get; set; }
    public bool WeekEnd { get; set; }
    public string DayOfTheWeek 
    { get 
        {
            var DaysOfTheWeek = new string[] { "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС" };
            return DaysOfTheWeek[Day-1];
        }
    }
}

