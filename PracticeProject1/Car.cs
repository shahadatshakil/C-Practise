namespace PracticeProject
{
    public class Car
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double TopSpeedKPH { get; set; }
        public int PriceUSD { get; set; }

        public override string ToString()
        {
            return $"{Name}, Top Speed: {TopSpeedKPH}, Price: {PriceUSD}, Brand = {Brand}";
        }
    }
}
