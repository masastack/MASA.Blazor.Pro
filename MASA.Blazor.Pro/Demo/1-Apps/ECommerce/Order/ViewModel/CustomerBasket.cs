namespace MASA.Blazor.Pro.Demo;

public class CustomerBasket
{
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}

public record BasketItem(
    int Id,
    string Name,
    string Company,
    float Score,
    int Qty,
    string Delivery,
    string Offers,
    decimal Price,
    string PictureFileName,
    bool FreeShipping)
{
    public string GetFormatPrice()
    {
        return $"${Price}";
    }

    public string GetPictureUrl()
    {
        return $"./img/eCommerce/product/{PictureFileName}";
    }
}


