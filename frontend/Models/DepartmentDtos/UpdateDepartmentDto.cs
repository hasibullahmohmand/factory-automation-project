namespace FactoryProject.Models;

public class UpdateDepartmentDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public decimal salary{ get; set; }
}