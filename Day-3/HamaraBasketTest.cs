using hamaraBasket.Tests;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        public DomainFactory domainFactory;

        public IList<Item> CreateItem(string name, int SellIn, int Quantity)
        {
            return domainFactory.CreateBasket(name, SellIn, Quantity);
        }

        public void UpdateQuality(IList<Item> Items)
        {
            domainFactory.UpdateQuality(Items);
        }

        [SetUp]
        public void setup()
        {
            domainFactory = new DomainFactory();
        }

        [TestCase("p1", 10, 10)]
        [TestCase("p2", 10, 20)]
        public void ShouldReduceSellInValueByOneEOD(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(SellIn - 1));
        }

        [TestCase("p1", 10, 10)]
        [TestCase("p2", 10, 20)]
        public void ShouldReduceQualityValueByOne(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(Quality - 1));
        }

        [TestCase("p2", 1, 10)]
        public void ShouldReduceQualityTwiceAfterSellInPass(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(Quality -3));
        }

        [TestCase("p2", 2, 1)]
        public void ShouldNotReduceQualityToNegative(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [TestCase("Indian Wine", 2, 1)]
        public void ShouldIncreaseQualityOfIndianWine(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(3));
        }

        [TestCase("Indian Wine", 2, 49)]
        public void ShouldIncreaseQualityOfIndianWineNotMoreThan50(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(50));
        }

        [TestCase("Forest Honey", 2, 49)]
        public void ShouldNotChangeQualityOrQuantityOfForestHoney(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(49));
            Assert.That(Items[0].SellIn, Is.EqualTo(2));
        }
        
        [TestCase("Movie Tickets", 2, 10)]
        public void ShouldIncreaseQualityAsSellInApproachesIncreasesBy3(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(16));
        }
        
        [TestCase("Movie Tickets", 10, 10)]
        public void ShouldIncreaseQualityAsSellInApproachesIncreasesBy2(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(14));
        }

        [TestCase("Movie Tickets", 1, 10)]
        public void ShouldDropQualityToZeroAfterSellIn(string name, int SellIn, int Quality)
        {
            IList<Item> Items = CreateItem(name, SellIn, Quality);
            UpdateQuality(Items);
            UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }
    }
}
