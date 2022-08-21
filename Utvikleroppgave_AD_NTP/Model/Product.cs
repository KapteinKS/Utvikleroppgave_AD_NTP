namespace Utvikleroppgave_AD_NTP.Model
{
    public class Product
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public bool Priority { get; set; }
        public Product(string name, string unit, int amount, bool priority)
        {
            Name = name;
            Unit = unit;
            Amount = amount;
            Priority = priority;
        }
        public Product() { }
    }
}
