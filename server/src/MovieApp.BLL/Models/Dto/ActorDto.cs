namespace MovieApp.BLL.Models.Dto;

public class ActorDto
{
    public int Id { get; set; }             
    public string Name { get; set; } = null!;
    public string Birthday { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public bool Adult { get; set; }         
    public List<string> Also_Known_As { get; set; } = null!;
    public string Profile_Path { get; set; } = null!;
    public double Popularity { get; set; }  
    public int Gender { get; set; }         
}
