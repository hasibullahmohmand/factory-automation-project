using FactoryProject.Models.ProductDtos;
using FactoryProject.Models.UserDtos;

namespace FactoryProject.Models;

public class ResultCartDto
{
    public int id{ get; set; }
    public int quantity{ get; set; }
    public DateTime createdAt{ get; set; }
    public ResultProductDto? product{ get; set; }
    public ResultUserDto? user { get; set; }
    public bool active { get; set; }

}