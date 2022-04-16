using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void constructsItemWithName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("name", Items[0].Name);
        }
    }
}
