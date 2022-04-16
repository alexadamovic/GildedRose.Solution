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

        [Fact]
        public void sulfuras_SellInDoesNotDecreaseWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void sulfuras_QualityDoesNotDecreaseWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void backstagePasses_QualityIncreasesWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void backstagePasses_QualityIncreasesByTwoWhenTenDaysOrLessWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void backstagePasses_QualityIncreasesByThreeWhenFiveDaysOrLessWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void backstagePasses_QualityDropsToZeroBySellInWithUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
    }
}
