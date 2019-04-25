namespace csharpcore{

    public class LegendaryItem : ItemWrapper{
        public LegendaryItem(Item item):base (item){
        }
        protected override void UpdateItemSellIn(){
            _item.SellIn = _item.SellIn;
        }
    }
}