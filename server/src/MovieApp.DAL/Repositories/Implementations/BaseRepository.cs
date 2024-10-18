using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class BaseRepository(HttpClient httpClient) : IBaseRepository
{
    public async Task<string> ApiGetQuery(string query)
    {
        var response = await httpClient.GetAsync(query);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to fetch latest movies");

        return await response.Content.ReadAsStringAsync();
    }
}