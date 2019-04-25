using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<IItemWrapper> ItemWrappers;
        public GildedRose(IList<Item> Items)
        {
            ItemWrappers = new List<IItemWrapper>();
            for (var i = 0; i < Items.Count; i++)
            {
                ItemWrappers.Add(ItemWrapperFactory.Create(Items[i]));
                
            }
        }

        public void UpdateQuality()
        {
            foreach (var itemWrapper in ItemWrappers)
            {
                itemWrapper.ProcessItem();
            }
        }


    }
}
