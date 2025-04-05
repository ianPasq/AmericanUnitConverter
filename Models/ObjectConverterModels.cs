namespace AmuricaUnity.Models
{
    public class ObjectCategory
    {
        public string Name { get; set; } = string.Empty;
        public List<ObjectUnit> Units { get; set; } = new List<ObjectUnit>();
        public List<ObjectItem> Objects { get; set; } = new List<ObjectItem>();
    }

    public class ObjectUnit
    {
        public string Name { get; set; } = string.Empty;
        public double Multiplier { get; set; }
        public double Divisor { get; set; }
    }

    public class ObjectItem
    {
        public string Name { get; set; } = string.Empty;
        public double BaseValue { get; set; } 
    }
}