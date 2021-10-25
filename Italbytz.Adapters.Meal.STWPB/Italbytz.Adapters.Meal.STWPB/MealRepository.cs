using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Italbytz.Infrastructure.STWPB;
using Italbytz.Ports.Common;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.STWPB
{
    public class MealRepository : IDataSource<int, IMeal>
    {
        private readonly string _language;
        private readonly string _id;

        public MealRepository(string id, string language)
        {
            _id = id;
            _language = language;
        }

        public Task<Result<IMeal>> Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<IMeal>>> RetrieveAll()
        {
            try
            {
                var api = new MensaAPI(_id, _language);
                var meals = await api.GetTodaysHammMeals();                
                return new Result<List<IMeal>>(meals.Select((meal) => (IMeal)meal.ToMeal()).ToList());
            }
            catch (System.Exception ex)
            {
                return new Result<List<IMeal>>(ex);
            }

        }

    }
}
