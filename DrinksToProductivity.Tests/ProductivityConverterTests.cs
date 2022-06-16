namespace DrinksToProductivity.Tests
{
    public class Tests
    {

        [SetUp]
        public void SetUp() => industry = new Industry() { Name = "Contoso", Productivity = 1.0f };
        private Industry industry;

        [Test]
        public void DrinkShouldBeValid() => Assert.That(new AlcoholicDrink() { Name = "Wine", AlcoholContentPercentage = 12 }.AlcoholContentPercentage, Is.EqualTo(12));

        [Test]
        public void IndustryShouldHaveSomeActivity() => Assert.That(new Industry() { Name = "Contoso", Productivity = 1.0f }.Productivity, Is.Not.EqualTo(0.0f));

        [Test]
        public void AlcoholicDrinkConverterShouldBringInChange()
        {
            var initialProductivity = industry.Productivity;
            var converter = new DrinkToBusinessConverter( industry);
            converter.Convert(new AlcoholicDrink() { Name = "Wine", AlcoholContentPercentage = 12 });
            Assert.That(industry.Productivity, Is.GreaterThan(initialProductivity));
        }

        [Test]
        public void NonAlcoholicDrinkConverterShouldBringInChange()
        {
            var initialProductivity = industry.Productivity;
            var converter = new DrinkToBusinessConverter(industry);
            converter.Convert(new CafenatedDrink() { Name = "Monster", CaffineContentPercentage = 78 });
            Assert.That(industry.Productivity, Is.GreaterThan(initialProductivity));
            Assert.That(industry.Productivity, Is.EqualTo(78));
        }

        [Test]
        public void DrinkConverterShouldBringInChange()
        {
            var initialProductivity = industry.Productivity;
            var converter = new DrinkToBusinessConverter(industry);
            converter.Convert(new Drink() { Name = "SparkleWater", EnergyBooster = 120 });
            Assert.That(industry.Productivity, Is.GreaterThan(initialProductivity));
            Assert.That(industry.Productivity, Is.EqualTo(120));
        }
    }
}