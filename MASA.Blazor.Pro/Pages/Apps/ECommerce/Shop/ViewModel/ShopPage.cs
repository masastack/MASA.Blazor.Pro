namespace MASA.Blazor.Pro.Pages;

public class ShopPage
{
    public ShopPage(List<ShopDataItem> datas)
    {
        Datas = datas;
    }

    public List<ShopDataItem> Datas { get; set; }

    private IEnumerable<ShopDataItem> GetFilterDatas()
    {
        IEnumerable<ShopDataItem> datas = Datas;

        if (MultiRange is not null)
        {
            datas = MultiRange.RangeType switch
            {
                RangeType.All => datas,
                RangeType.Range => datas.Where(d => d.Price >= MultiRange.LeftNumber && d.Price <= MultiRange.RightNumber),
                RangeType.Less => datas.Where(d => d.Price < MultiRange.LeftNumber),
                RangeType.LessEqual => datas.Where(d => d.Price <= MultiRange.LeftNumber),
                RangeType.More => datas.Where(d => d.Price > MultiRange.LeftNumber),
                RangeType.MoreEqual => datas.Where(d => d.Price >= MultiRange.LeftNumber),
                _ => datas
            };
        }
        if (Category is not null)
        {
            datas = datas.Where(d => d.Category == Category);
        }
        if (Brand is not null)
        {
            datas = datas.Where(d => d.Brand == Brand);
        }
        if (SortType is not null)
        {
            if (SortType == "Lowest")
            {
                datas = datas.OrderBy(d => d.Price);
            }
            else if (SortType == "Highest")
            {
                datas = datas.OrderByDescending(d => d.Price);
            }
        }
        if (Search is not null)
        {
            datas = datas.Where(d => d.Name.ToUpper().Contains(Search.ToUpper()));
        }

        if (datas.Count() < (PageIndex - 1) * PageSize) PageIndex = 1;

        return datas;
    }

    public List<ShopDataItem> GetPageDatas()
    {
        return GetFilterDatas().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
    }

    public int CurrentCount => GetFilterDatas().Count();

    public int PageIndex { get; set; } = 1;

    public int PageSize { get; set; } = 6;

    public int PageCount => (int)Math.Ceiling(CurrentCount / (double)PageSize);

    public MultiRange? MultiRange { get; set; }

    public string? Category { get; set; }

    public string? Brand { get; set; }

    public StringNumber SortType { get; set; } = "Featured";

    public string? Search { get; set; }

    public ShopDataItem GetDetailItem(string guid)
    {
        return Datas.FirstOrDefault(a => a.Id == Guid.Parse(guid)) ?? Datas.First();
    }

    public List<RelatedProduct> GetRelatedProducts()
    {
        return new List<RelatedProduct>
            {
                new(){Name="GA406B 温热管线饮水机",Brand="Lonsid",ImgUrl="https://img-cdn.lonsid.co/image/1593360117.jpg",Price=9999,Rating=5 },
                new(){Name="G1管线饮水机",Brand="Lonsid",ImgUrl="https://img-cdn.lonsid.co/image/1593360094.jpg",Price=9999,Rating=5 },
                new(){Name="GA406K 速热管线饮水机",Brand="Lonsid",ImgUrl="https://img-cdn.lonsid.co/image/1555404598.jpg",Price=9999,Rating=5 },
                new(){Name="GT3桌面即热饮水机",Brand="Lonsid",ImgUrl="https://img-cdn.lonsid.co/image/1560130226.jpg",Price=9999,Rating=5 },
                new(){Name="GR320RB冷热型饮水机",Brand="Lonsid",ImgUrl="https://img-cdn.lonsid.co/image/1603728000ddBMgnpYFmMWTlAl3bAX179.jpg",Price=9999,Rating=5 }
            };
    }
}

