namespace sushi_go.Models
{
    public class RollProductModel
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Ingredienst { get; set; } = [];
        public int Weight { get; set; }
        public int Pieces { get; set; }
        public int Price { get; set; }
    }
}
