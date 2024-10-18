namespace MovieApp.BLL.Models.Dto;

public class ActorSearchDto
{
    public int Id { get; set; }             
    public string Name { get; set; } = null!;
    public string Original_Name { get; set; } = null!;
    public bool Adult { get; set; }         
    public string Profile_Path { get; set; } = null!;
    public double Popularity { get; set; }  
    public int Gender { get; set; }
    public string Known_For_Department { get; set; } = null!;
}