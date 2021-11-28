using LtuLunch.Client.services;
using NodaTime;
using NodaTime.Extensions;

namespace LtuLunch.Client.state;

public class LunchStateStorage
{
    private readonly LunchUpdateService _lunchUpdateService;

    public LunchStateStorage(LunchUpdateService lunchUpdateService)
    {
        _lunchUpdateService = lunchUpdateService;

        Task.Run(async () =>
        {
            await RefreshLunchCache();
            SetLunchEpoch(SystemClock.Instance.InUtc().GetCurrentDate(), Period.FromDays(1));
        });
    }
    
    
    private IList<Lunch> LocalLunchCache { get; set; }
    
    public List<Lunch> CurrentLunchEpoch { get; private set; }

    public void SetLunchEpoch(LocalDate epochStart, Period epochDuration)
    {
        CurrentLunchEpoch = LocalLunchCache
            .Where(x => x.When.CompareTo(epochStart) >= 0)
            .Where(x => x.When.CompareTo(epochStart + epochDuration) < 0)
            .ToList();
    }

    public async Task RefreshLunchCache()
    {
        var lunch = await _lunchUpdateService.FetchCurrentLunchOffers();
        if (!lunch.Any())
            return;

        LocalLunchCache = lunch;
    }
}