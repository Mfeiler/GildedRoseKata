

namespace csharpcore
{
    public class ItemWrapper {
        private Item _item;

        public ItemWrapper(Item item){
            this._item = item;
        }
        

        public void UpdateItemQuality(int changeVal)
        {
            _item.Quality = _item.Quality + changeVal;
        }
    }

}