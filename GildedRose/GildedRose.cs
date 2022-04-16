using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                UpdateItem(item);
            }

        }
        private void UpdateItem(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            ChangeQuality(item);
        }

        private void ChangeQuality(Item item)
        {
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50) 
            {
                item.Quality += 1;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality += 1;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality += 1;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 1)
            {
                item.Quality = 0;
            }
            if (item.Name == "Conjured Mana Cake" && item.Quality < 0)
            {
                item.Quality -= 2;
            }
            if (item.Name == "Conjured Mana Cake" && item.SellIn <= 0 && item.Quality < 0)
            {
                item.Quality -= 2;
            }
            if ((item.Name != "Conjured Mana Cake" || item.Name != "Aged Brie" || item.Name != "Backstage passes to a TAFKAL80ETC concert" || item.Name != "Sulfuras, Hand of Ragnaros") && item.Quality < 0)
            {
                item.Quality -= 1;
            }
            if ((item.Name != "Conjured Mana Cake" || item.Name != "Aged Brie" || item.Name != "Backstage passes to a TAFKAL80ETC concert" || item.Name != "Sulfuras, Hand of Ragnaros") && item.Quality < 0 && item.SellIn < 1)
            {
                item.Quality -= 1;
            }
        }
    }
}
