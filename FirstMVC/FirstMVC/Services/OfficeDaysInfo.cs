using FirstMVC.Models;

namespace FirstMVC.Services;

public class OfficeDaysInfo: IOfficeDayInfo
{
    private readonly List<OfficeDayInfoModel> officeDaysInfo;
    private readonly ILogger<OfficeDaysInfo> _Logger;
    public OfficeDaysInfo(ILogger<OfficeDaysInfo> Logger)
    {
        _Logger = Logger;
        officeDaysInfo = new List<OfficeDayInfoModel>() { };

        for(int i=1; i <=4; i++)
        {
            officeDaysInfo.Add(
                new OfficeDayInfoModel()
                {
                    TimeBeginWork = new TimeSpan(9, 0, 0),
                    TimeEndWork = new TimeSpan(17, 30, 0),
                    TimeBeginLunch = new TimeSpan(12, 0, 0),
                    TimeEndLunch = new TimeSpan(12, 30, 0),
                    Day = i,
                    WeekEnd = false
                }
            );
        }

        officeDaysInfo.Add(
            new OfficeDayInfoModel()
            {
                TimeBeginWork = new TimeSpan(9, 0, 0),
                TimeEndWork = new TimeSpan(16, 30, 0),
                TimeBeginLunch = new TimeSpan(12, 0, 0),
                TimeEndLunch = new TimeSpan(12, 30, 0),
                Day = 5,
                WeekEnd = true
            }
        );
        officeDaysInfo.Add(
            new OfficeDayInfoModel()
            {
                TimeBeginWork = new TimeSpan(10, 0, 0),
                TimeEndWork = new TimeSpan(16, 30, 0),
                TimeBeginLunch = new TimeSpan(12, 0, 0),
                TimeEndLunch = new TimeSpan(12, 30, 0),
                Day = 6,
                WeekEnd = false
            }
        );
        officeDaysInfo.Add(
            new OfficeDayInfoModel()
            {
                TimeBeginWork = new TimeSpan(9, 0, 0),
                TimeEndWork = new TimeSpan(17, 30, 0),
                TimeBeginLunch = new TimeSpan(12, 0, 0),
                TimeEndLunch = new TimeSpan(12, 30, 0),
                Day = 7,
                WeekEnd = true
            }
        );
    }

    public bool Edit(OfficeDayInfoModel item)
    {
        var mem_item = GetByDay(item.Day);
        if (mem_item is null)
            return false;

        mem_item.TimeBeginWork = item.TimeBeginWork;
        mem_item.TimeEndWork = item.TimeEndWork;
        mem_item.TimeBeginLunch = item.TimeBeginLunch;
        mem_item.TimeEndLunch = item.TimeEndLunch;
        mem_item.Day = item.Day;
        mem_item.WeekEnd = item.WeekEnd;

        return true;
    }

    public IEnumerable<OfficeDayInfoModel> GetAll() => officeDaysInfo;

    public OfficeDayInfoModel? GetByDay(int day) => officeDaysInfo.FirstOrDefault(item => item.Day == day);

}

