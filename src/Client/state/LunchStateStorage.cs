using LtuLunch.Client.services;

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
            SetLunchEpoch(DateTime.Now, DateTime.Now.AddDays(1)-DateTime.Now);
        });
    }
    
    
    private IList<Lunch> LocalLunchCache { get; set; }
    
    public List<Lunch> CurrentLunchEpoch { get; private set; }

    public void SetLunchEpoch(DateTime epochStart, TimeSpan epochDuration)
    {
        CurrentLunchEpoch = LocalLunchCache
            .Where(x => DateTime.Compare(x.When.ToDateTime(x.Resturant.OpensWhen), epochStart) >= 0)
            .Where(x => DateTime.Compare(x.When.ToDateTime(x.Resturant.OpensWhen), DateTime.Now + epochDuration) < 0)
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