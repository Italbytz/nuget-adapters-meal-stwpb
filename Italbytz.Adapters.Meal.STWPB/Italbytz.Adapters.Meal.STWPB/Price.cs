using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.STWPB
{
    public class Price : IPrice
    {
        public Price()
        {
        }

        public double? Students { get; set; }
        public double? Employees { get; set; }
        public double? Pupils { get; set; }
        public double? Others { get; set; }
    }
}