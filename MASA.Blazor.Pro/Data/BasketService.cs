using MASA.Blazor.Pro.Demo._1_Apps.ECommerce.Order.ViewModel;

namespace MASA.Blazor.Pro.Data;

public static class BasketService
{
    static BasketService()
    {

    }

    public static CustomerBasket GetUserBasket()
    {
        return new CustomerBasket()
        {
            Items = new List<BasketItem>
            {
                new BasketItem(1,"Apple Watch Series 5","Apple",4,1,"Delivery by Sun, Nov 28","12% off 3 offers Available",339.99m,"1.3b312012.png",true),
                new BasketItem(2,"Google - Google Home - White/Slate fabric","Google",4,1,"Delivery by Wed, Dec 1","16% off 1 offers Available",129.29m,"7.2a004c66.png",true),
                new BasketItem(3,"Apple iPhone 11 (64GB, Black)","Apple",5,1,"Delivery by Thu, Nov 25","8% off 1 offers Available",669.99m,"2.1aba2cea.png",true),
                new BasketItem(4,"Apple iMac 27-inch","Apple",4,1,"Delivery by Mon, Nov 29","3% off 4 offers Available",999.99m,"3.29c766f8.png",true),
                new BasketItem(5,"Apple - MacBook Air® (Latest Model) - 13.3\" Display - Silver","Apple",4,1,"Delivery by Sun, Nov 28","17% off 4 offers Available",999.99m,"5.c5b188e5.png",false)
            }
        };
    }
}

