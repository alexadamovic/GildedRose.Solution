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
            Assert.Equal("name", Items[0].Name);
        }

        [Fact]
        public void constructsItemWithSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Assert.Equal(3, Items[0].SellIn);
        }

        [Fact]
        public void constructsItemWithQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 0, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            Assert.Equal(3, Items[0].Quality);
        }
    }
}
