using System.Collections.Generic;

namespace csharpcore
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
                ItemQualityDecrement(i);
                ItemSellInDecrement(i);
                ExpiredItemUpdate(i);
            }
        }

        private void ExpiredItemUpdate(int i)
        {
            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                UpdateItemQuality(i, -1);
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = 0;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        UpdateItemQuality(i, 1);
                    }
                }
            }
        }

        private void ItemSellInDecrement(int i)
        {
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private void ItemQualityDecrement(int i)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        UpdateItemQuality(i, -1);
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    UpdateItemQuality(i, 1);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                UpdateItemQuality(i, 1);
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                UpdateItemQuality(i, 1);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateItemQuality(int i, int changeVal)
        {
            Items[i].Quality = Items[i].Quality + changeVal;
        }
    }
}
