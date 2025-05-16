namespace FactoryProject.Models.PersonalDtos;

public class UpdatePersonalDto
{
    public int id{ get; set; }
    public string name { get; set; } = string.Empty;
    public int age { get; set; }
    public int gender { get; set; }
    public DateTime date { get; set; }
    public ResultDepartmentDto? department { get; set; }
    public string identifier { get; set; } = string.Empty;
    public string shift { get; set; } = string.Empty;
    
    
}