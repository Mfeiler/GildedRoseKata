
namespace csharpcore
{
    public class ItemWrapper : IItemWrapper
    {
        protected Item _item {get;set;}

       public ItemWrapper (Item item){
            _item = item;
        }

        public void ProcessItem(){
            UpdateCurrentItemQuality();

            UpdateItemSellIn();

            
            UpdateExpiredItemQuality();
        }
        private void UpdateCurrentItemQuality()
        {
            if (_item.Name != "Aged Brie" && _item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (_item.Quality > 0)
                {
                    if (_item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        UpdateItemQuality(-1);
                    }
                }
            }
            else
            {
                if (_item.Quality < 50)
                {
                    _item.Quality = _item.Quality + 1;

                    if (_item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (_item.SellIn < 11)
                        {
                            if (_item.Quality < 50)
                            {
                                _item.Quality = _item.Quality + 1;
                            }
                        }

                        if (_item.SellIn < 6)
                        {
                            if (_item.Quality < 50)
                            {
                                _item.Quality = _item.Quality + 1;
                            }
                        }
                    }
                }
            }
        }
        private void UpdateExpiredItemQuality()
        {
            if (_item.SellIn < 0)
            {
                if (_item.Name != "Aged Brie")
                {
                    if (_item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (_item.Quality > 0)
                        {
                            if (_item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                UpdateItemQuality( -1);
                            }
                        }
                    }
                    else
                    {
                        _item.Quality = _item.Quality - _item.Quality;
                    }
                }
                else
                {
                    if (_item.Quality < 50)
                    {
                        _item.Quality = _item.Quality + 1;
                    }
                }
            }
        }
        protected virtual void UpdateItemSellIn()
        {
            _item.SellIn = _item.SellIn - 1;
        }
        private void UpdateItemQuality(int changeVal)
        {
            _item.Quality = _item.Quality + changeVal;
        }

    }
}