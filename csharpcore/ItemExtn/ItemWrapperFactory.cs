namespace csharpcore{
    public static class ItemWrapperFactory{
        public static IItemWrapper Create(Item item){
            switch(item.Name){
                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryItem(item);
                    break;
                default:
                    return new ItemWrapper(item);
                    break;
            }       
        }   
    }
}