using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.Helpers
{
    public static class TotalHelper
    {
        public static decimal GetTotal(IEnumerable<BasketItem> items, string property)
        {
            decimal Total = 0;
            if (items is not null)
            {
                foreach (var i in items)
                {
                    if (property == "price")
                    {
                        Total += i.Product.Price;
                    }
                    else
                    {
                        Total += i.Product.Quantity;
                    }
                }
                return Total;
            }
            return Total;
        }
    }
}
