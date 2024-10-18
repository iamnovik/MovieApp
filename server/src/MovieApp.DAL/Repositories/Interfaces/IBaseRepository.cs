namespace MovieApp.DAL.Repositories.Interfaces;

public interface IBaseRepository
{
    Task<string> ApiGetQuery(string query);
}