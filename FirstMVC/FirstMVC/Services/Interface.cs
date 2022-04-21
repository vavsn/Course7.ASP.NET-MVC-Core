using FirstMVC.Models;

namespace FirstMVC.Services;

public interface IOfficeDayInfo
{
    IEnumerable<OfficeDayInfoModel> GetAll();

    OfficeDayInfoModel? GetByDay(int day);

    bool Edit(OfficeDayInfoModel item);
}
