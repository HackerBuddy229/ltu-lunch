using System.Text.Json;

namespace LtuLunch.Client.services;

public class LunchUpdateService
{
    private readonly HttpClient _httpClient;

    public LunchUpdateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IList<Lunch>> FetchCurrentLunchOffers()
    {
        

        try
        {
            var result = await _httpClient.GetAsync($"/api/lunch/byDay?year=2021&month=11&date=29"); //TODO: fill in controller uri

            if (!result.IsSuccessStatusCode)
                return new List<Lunch>();

            var lunch = JsonSerializer
                .Deserialize<IList<Lunch>>(await result.Content.ReadAsStreamAsync());

            return lunch;
        }
        catch (IOException e)
        {
            return new List<Lunch>();
        }
    }
}