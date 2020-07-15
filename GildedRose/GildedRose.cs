﻿using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        private int BackstageQualityIncrease(int sellIn)
        {
            if (sellIn > 10)
            {
                return 1;
            }

            if (sellIn > 5)
            {
                return 2;
            }

            if (sellIn > 0)
            {
                return 3;
            }

            return -50;
        }
        
        private int BrieQualityIncrease(int sellIn)
        {
            return sellIn <= 0 ? 2 : 1;
        }

        private int GenericQualityDecrease(int sellIn)
        {
            return sellIn <= 0 ? 2 : 1;
        }

        private int CheckBounds(int quality)
        {
            if (quality > 50)
            {
                return 50;
            }
            return quality < 0 ? 0 : quality;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.Quality += BackstageQualityIncrease(item.SellIn);
                        item.Quality = CheckBounds(item.Quality);
                        item.SellIn--;
                        break;
                    case "Aged Brie":
                        item.Quality += BrieQualityIncrease(item.SellIn);
                        item.Quality = CheckBounds(item.Quality);
                        item.SellIn--;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        item.Quality -= GenericQualityDecrease(item.SellIn);
                        item.Quality = CheckBounds(item.Quality);
                        item.SellIn--;
                        break;
                }
            }
        }
    }
}
