namespace MovieApp.BLL.Models.Dto;

public class CastDto
{
    public int Id { get; set; }             
    public bool Adult { get; set; }          
    public string Name { get; set; } = null!;
    public string Original_Name { get; set; } = null!;
    public string Known_For_Department { get; set; } = null!;
    public double Popularity { get; set; }  
    public string Profile_Path { get; set; } = null!;
    public int Cast_Id { get; set; }          
    public string Character { get; set; } = null!;
    public string Credit_Id { get; set; } = null!;
    public int Order { get; set; }           
}