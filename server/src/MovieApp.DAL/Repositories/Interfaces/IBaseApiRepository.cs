namespace MovieApp.DAL.Repositories.Interfaces;

public interface IBaseApiRepository
{
    Task<string> ApiGetQuery(string query);
}