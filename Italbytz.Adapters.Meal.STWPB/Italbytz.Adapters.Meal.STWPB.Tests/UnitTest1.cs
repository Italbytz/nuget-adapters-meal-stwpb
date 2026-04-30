using System.Threading.Tasks;
using NUnit.Framework;

namespace Italbytz.Adapters.Meal.STWPB.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestRetrieveAll()
        {
            var secret = "nunkesser-89knHj!85plK";
            var repo = new MealRepository(secret, "de");
            var meals = await repo.RetrieveAll();
            Assert.IsTrue(meals.Count > 0);
        }
    }
}
