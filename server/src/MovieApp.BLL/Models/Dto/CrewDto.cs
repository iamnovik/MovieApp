namespace MovieApp.BLL.Models.Dto;

public class CrewDto
{
    public int Id { get; set; }             
    public bool Adult { get; set; }          
    public int Gender { get; set; }          
    public string Name { get; set; } = null!;
    public string Original_Name { get; set; } = null!;
    public string Known_For_Department { get; set; } = null!;
    public double Popularity { get; set; }   
    public string Profile_Path { get; set; } = null!;
    public string Credit_Id { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string Job { get; set; } = null!;
}
