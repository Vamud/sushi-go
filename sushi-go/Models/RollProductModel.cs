namespace sushi_go.Models
{
    public class RollProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; } = [];
        public int Weight { get; set; }
        public int Pieces { get; set; }
        public int Price { get; set; }
    }
}
