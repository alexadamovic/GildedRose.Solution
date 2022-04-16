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

        [Fact]
        public void regularItem_sellInDecreasesWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 3, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void regularItem_qualityDecreasesWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 3, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void regularItem_qualityDecreasesByTwoAfterSellInReachesZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = -1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void QualityIsNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "name", SellIn = 3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_QualityIncreasesWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_QualityNeverMoreThanFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }
    }
}
