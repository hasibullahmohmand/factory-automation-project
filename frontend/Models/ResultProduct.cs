namespace BlazorApp1.Models
{
    public class ResultProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public ResultCategory Category { get; set; }
    }
}
