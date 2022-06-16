

namespace DrinksToProductivity
{
    public class DrinkToBusinessConverter
    {
        public DrinkToBusinessConverter(Beverage beverage,Industry industry)
        {
            this.beverage = beverage;
            this.industry = industry;
        }

        private Beverage beverage { get; set; }
        private Industry industry { get; set; }

        public void Convert()
        {
            if (beverage is AlcoholicDrink drink)
                industry.Productivity = industry.Productivity * drink.AlcoholContentPercentage;
            else if (beverage is CafenatedDrink softDrink)
                industry.Productivity = industry.Productivity * softDrink.CaffineContentPercentage;
            else
                industry.Productivity = industry.Productivity * ((Drink)beverage).EnergyBooster;

        }
    }
}
