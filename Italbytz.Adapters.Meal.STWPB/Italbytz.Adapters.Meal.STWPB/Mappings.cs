using System;
using System.Globalization;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.STWPB
{
    public static class Mappings
    {
        public static Meal ToMeal(this Infrastructure.STWPB.Meal self)
        {
            var name = self.NameDe ?? self.NameEn;            
            var category = self.Category switch
            {
                Infrastructure.STWPB.Category.None => Category.None,
                Infrastructure.STWPB.Category.Dessert => Category.Dessert,
                Infrastructure.STWPB.Category.DessertCounter => Category.Dessert,
                Infrastructure.STWPB.Category.Dish => Category.Dish,
                Infrastructure.STWPB.Category.DishDefault => Category.Dish,
                Infrastructure.STWPB.Category.DishGrill => Category.Dish,
                Infrastructure.STWPB.Category.Empty => Category.None,
                Infrastructure.STWPB.Category.Sidedish => Category.Sidedish,
                Infrastructure.STWPB.Category.Soups => Category.Soup,
                _ => Category.None,
            };

            var allergens = Allergens.None;
            var additives = Additives.None;

            foreach (var allergen in self.Allergens)
            {
                switch (allergen)
                {
                    case Infrastructure.STWPB.AllergenEnum.Z1: additives |= Additives.FoodColoring; break;
                    case Infrastructure.STWPB.AllergenEnum.Z2: additives |= Additives.Preservatives; break;
                    case Infrastructure.STWPB.AllergenEnum.Z3: additives |= Additives.Antioxidants; break;
                    case Infrastructure.STWPB.AllergenEnum.Z4: additives |= Additives.FlavorEnhancer; break;
                    case Infrastructure.STWPB.AllergenEnum.Z5: additives |= Additives.Phosphate; break;
                    case Infrastructure.STWPB.AllergenEnum.Z6: additives |= Additives.Sulphureted; break;
                    case Infrastructure.STWPB.AllergenEnum.Z7: additives |= Additives.Waxed; break;
                    case Infrastructure.STWPB.AllergenEnum.Z8: additives |= Additives.Blackend; break;
                    case Infrastructure.STWPB.AllergenEnum.Z9: additives |= Additives.Sweetener; break;
                    case Infrastructure.STWPB.AllergenEnum.Z10: additives |= Additives.Phenylalanine; break;
                    case Infrastructure.STWPB.AllergenEnum.Z11: additives |= Additives.Taurine; break;
                    case Infrastructure.STWPB.AllergenEnum.Z12: additives |= Additives.NitritePicklingSalt; break;
                    case Infrastructure.STWPB.AllergenEnum.Z13: additives |= Additives.Caffeinated; break;
                    case Infrastructure.STWPB.AllergenEnum.Z14: additives |= Additives.Quinine; break;
                    case Infrastructure.STWPB.AllergenEnum.Z15: additives |= Additives.MilkProtein; break;
                    case Infrastructure.STWPB.AllergenEnum.A1: allergens |= Allergens.Gluten; 
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A2: allergens |= Allergens.Shellfish; 
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A3:
                        allergens |= Allergens.Eggs;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A4:
                        allergens |= Allergens.Fish;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A5:
                        allergens |= Allergens.Peanuts;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A6:
                        allergens |= Allergens.Soy;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A7:
                        allergens |= Allergens.Milk;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A8:
                        allergens |= Allergens.Nuts;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A9:
                        allergens |= Allergens.Celery;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A10:
                        allergens |= Allergens.Mustard;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A11:
                        allergens |= Allergens.Sesame;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A12:
                        allergens |= Allergens.Sulfur;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A13:
                        allergens |= Allergens.Lupine;
                        break;
                    case Infrastructure.STWPB.AllergenEnum.A14:
                        allergens |= Allergens.Mollusk;
                        break;
                    default:
                        break;
                }
            }

            var meal = new Meal()
            {
                Name = name,
                Image = self.Image,
                Category = category,
                Additives = additives,
                Allergens = allergens,
                Price = new Price()
                {
                    Others = self.PriceGuests,
                    Employees = self.PriceWorkers,
                    Students = self.PriceStudents,
                    Pupils = null
                }
            };

            return meal;
        }

    }
}
