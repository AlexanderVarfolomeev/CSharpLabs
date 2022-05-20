namespace OperatorModel
{
    public class OperatorChild : Operator
    {
        public OperatorChild(string name, decimal oneMinutePrice, double area, bool pay) 
            : base (name,  oneMinutePrice,  area)
        {
            PayForConnection = pay;
        }
        public bool PayForConnection { get; set; }

        public override double Quality()
        {
            return PayForConnection ? 0.7 * base.Quality() : 1.5 * base.Quality();
        }

        public override string ToString()
        {
            return base.ToString() + $", плата за каждое соедение: {PayForConnection}";
        }
    }
}