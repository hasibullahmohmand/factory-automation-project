namespace FactoryProject.Models;

public class ResultPersonalDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string identifier { get; set; } = string.Empty;
    public int age;

    private string gender{ get; set; }=string.Empty;

    private DateTime date;

    private string shift{ get; set; }=string.Empty;

    
    public ResultDepartmentDto? department;
}