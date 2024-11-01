namespace MovieApp.DAL.ApiQueryParameters;

public static class ApiRequestParameters
{
    public static class DateFilters
    {
        public static string GetMinDate()
        {
            return DateTime.UtcNow.AddDays(-10).ToString("yyyy-MM-dd");
        }

        public static string GetMaxDate()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd"); 
        }
    }

    // Параметры для постраничной навигации
    public static class Pagination
    {
        public const string DefaultPage = "1";
        public const int DefaultPageSize = 20; 

        public static string GetPage(int pageNumber)
        {
            return pageNumber.ToString();
        }
    }

    // Параметры для сортировки фильмов
    public static class SortOptions
    {
        public const string SortByPopularityDesc = "popularity.desc"; 
        public const string SortByReleaseDateDesc = "release_date.desc";
    }
    
    public static class MovieApi
    {
        public const string DiscoverMovieEndpoint = "discover/movie";
        public const string IncludeAdult = "true";
        public const string IncludeVideo = "false";
        public const string Language = "en-US";
    }
}
