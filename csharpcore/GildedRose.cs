using System.Collections.Generic;
using System.Linq;
namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        IList<ItemWrapper> WrappedItems;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            WrappedItems =
                Items
                    .Select(x => new ItemWrapper(x)).ToList();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    ItemQualityDecrement(i);

                    ItemSellInDecrement(i);

                    if (Items[i].SellIn < 0)
                        ExpiredItemUpdate(i);
                }
            }
        }
        private void ExpiredItemUpdate(int i)
        {
            if (Items[i].Name != "Aged Brie")
            {
                updateNonBrieExpiredItem(i);
            }
            else
            {
                updateExpiredBrie(i);
            }
        }
        private void updateExpiredBrie(int i)
        {
            if (Items[i].Quality < 50)
            {
                WrappedItems[i].UpdateItemQuality(1);
            }
        }
        private void updateItemQualityGreaterThanZero(int i)
        {
            if (Items[i].Quality > 0)
            {
                WrappedItems[i].UpdateItemQuality(-1);
            }
        }
        private void updateNonBrieExpiredItem(int i)
        {
            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                updateItemQualityGreaterThanZero(i);
            }
            else
            {
                Items[i].Quality = 0;
            }
        }
        private void UpdateQualityNonExpiredRegularItem(int i)
        {
            if (Items[i].Quality > 0)
            {
                WrappedItems[i].UpdateItemQuality(-1);
            }
        }
        private void UpdateQualityExceptionItems(int i )
        {
            if (Items[i].Quality < 50)
            {
                WrappedItems[i].UpdateItemQuality(1);
                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].SellIn < 11)
                    {
                        if (Items[i].Quality < 50)
                        {
                            WrappedItems[i].UpdateItemQuality(1);
                        }
                    }
                    if (Items[i].SellIn < 6)
                    {
                        if (Items[i].Quality < 50)
                        {
                            WrappedItems[i].UpdateItemQuality(1);
                        }
                    }
                }
            }
        }
        private void ItemSellInDecrement(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
        private void ItemQualityDecrement(int i)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
            UpdateQualityNonExpiredRegularItem(i);
            }
            else
            {
                UpdateQualityExceptionItems(i);
            }
        }
    }
}
