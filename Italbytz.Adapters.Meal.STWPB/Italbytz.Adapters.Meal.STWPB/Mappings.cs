using System;
using System.Globalization;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.STWPB
{
    public static class Mappings
    {
        public static Meal ToMeal(this Italbytz.Infrastructure.STWPB.Meal self)
        {
            var name = self.NameDe ?? self.NameEn;            
            var category = self.Category switch
            {
                Italbytz.Infrastructure.STWPB.Category.None => Category.None,
                Italbytz.Infrastructure.STWPB.Category.Dessert => Category.Dessert,
                Italbytz.Infrastructure.STWPB.Category.DessertCounter => Category.Dessert,
                Italbytz.Infrastructure.STWPB.Category.Dish => Category.Dish,
                Italbytz.Infrastructure.STWPB.Category.DishDefault => Category.Dish,
                Italbytz.Infrastructure.STWPB.Category.DishGrill => Category.Dish,
                Italbytz.Infrastructure.STWPB.Category.Empty => Category.None,
                Italbytz.Infrastructure.STWPB.Category.Sidedish => Category.Sidedish,
                Italbytz.Infrastructure.STWPB.Category.Soups => Category.Soup,
                _ => Category.None,
            };

            var allergens = Allergens.None;
            var additives = Additives.None;

            foreach (var allergen in self.Allergens)
            {
                switch (allergen)
                {
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z1: additives |= Additives.FoodColoring; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z2: additives |= Additives.Preservatives; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z3: additives |= Additives.Antioxidants; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z4: additives |= Additives.FlavorEnhancer; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z5: additives |= Additives.Phosphate; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z6: additives |= Additives.Sulphureted; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z7: additives |= Additives.Waxed; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z8: additives |= Additives.Blackend; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z9: additives |= Additives.Sweetener; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z10: additives |= Additives.Phenylalanine; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z11: additives |= Additives.Taurine; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z12: additives |= Additives.NitritePicklingSalt; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z13: additives |= Additives.Caffeinated; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z14: additives |= Additives.Quinine; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.Z15: additives |= Additives.MilkProtein; break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A1: allergens |= Allergens.Gluten; 
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A2: allergens |= Allergens.Shellfish; 
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A3:
                        allergens |= Allergens.Eggs;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A4:
                        allergens |= Allergens.Fish;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A5:
                        allergens |= Allergens.Peanuts;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A6:
                        allergens |= Allergens.Soy;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A7:
                        allergens |= Allergens.Milk;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A8:
                        allergens |= Allergens.Nuts;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A9:
                        allergens |= Allergens.Celery;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A10:
                        allergens |= Allergens.Mustard;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A11:
                        allergens |= Allergens.Sesame;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A12:
                        allergens |= Allergens.Sulfur;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A13:
                        allergens |= Allergens.Lupine;
                        break;
                    case Italbytz.Infrastructure.STWPB.AllergenEnum.A14:
                        allergens |= Allergens.Mollusk;
                        break;
                    default:
                        break;
                }
            }

            var cultureInfo = CultureInfo.GetCultureInfo("de-DE");
            var price = String.Format(cultureInfo, "{0:C} / {1:C} / {2:C}", self.PriceStudents, self.PriceWorkers, self.PriceGuests);

            var meal = new Meal()
            {
                Name = name,
                Image = self.Image,
                Category = category,
                Additives = additives,
                Allergens = allergens,
                Price = price
            };

            return meal;
        }

    }
}
