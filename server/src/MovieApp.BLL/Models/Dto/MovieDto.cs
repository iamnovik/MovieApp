namespace MovieApp.BLL.Models.Dto;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string Poster_Path { get; set; } = null!;
    public double Vote_Average { get; set; }
    public int Vote_Count { get; set; }
    public string Release_Date { get; set; } = null!;
}