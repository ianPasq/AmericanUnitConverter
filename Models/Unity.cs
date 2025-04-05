namespace AmuricaUnity.Models
{
    public class Unit
    {
        public int Index { get; }
        public string Name { get; }
        public double Multiplier { get; }
        public double Divisor { get; }

        public Unit(int index, string name, string formulaToBase, string formulaFromBase)
        {
            Index = index;
            Name = name;
            Multiplier = ParseFormula(formulaToBase);
            Divisor = ParseFormula(formulaFromBase);
            
        }

        private static double ParseFormula(string formula)
        {
            if (formula == "iv") return 1;
            return formula.Contains('*') 
                ? double.Parse(formula.Split('*')[1]) 
                : 1 / double.Parse(formula.Split('/')[1]);
        }
    }
}


