

namespace DrinksToProductivity
{
    public class DrinkToBusinessConverter
    {
        public DrinkToBusinessConverter(Industry industry) => this.industry = industry;

        private Industry industry { get; set; }

        public void Convert(Beverage beverage)
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
