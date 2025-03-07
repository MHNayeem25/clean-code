namespace hamaraBasket.Tests
{
    public class DomainFactory
    {
        public DomainFactory()
        {

        }
        public IList<Item> CreateBasket(string name, int SellIn, int Quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = SellIn, Quality = Quality } };

            return Items;
        }

        public void UpdateQuality(IList<Item> Items)
        {
            HamaraBasket app = new HamaraBasket(Items);
            app.UpdateQuality();
        }
    }
}
