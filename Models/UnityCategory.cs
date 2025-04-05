namespace AmuricaUnity.Models
{
    public class UnitCategory
    {
        public string Name { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
}