namespace FactoryProject.Models;

public class ResultPersonalDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string identifier { get; set; } = string.Empty;
    public int age;
    public int gender{ get; set; }
    public  DateTime date;
    public string shift{ get; set; }=string.Empty;
    public ResultDepartmentDto? department;
}