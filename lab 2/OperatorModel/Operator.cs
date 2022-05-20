namespace OperatorModel
{
    public class Operator
    {
        public Operator()
        {
            Name = "";
            OneMinutePrice = 0;
            Area = 0;
        }

        public Operator(string name, decimal oneMinutePrice, double area)
        {
            Name = name;
            OneMinutePrice = oneMinutePrice;
            Area = area;
        }

        public string Name { get; set; }
        public decimal OneMinutePrice { get; set; }
        public double Area { get; set; }

        public virtual double Quality() => 100 * Area / (double)OneMinutePrice;

        public override string ToString()
        {
            return $"{Name}, цена за минуту разговора: {OneMinutePrice}, площадь покрытия: {Area}.";
        }
    }
}