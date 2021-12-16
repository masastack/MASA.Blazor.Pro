namespace MASA.Blazor.Pro.Demo
{
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

            return datas;
        }

        public List<ShopDataItem> GetPageDatas()
        {
            return GetFilterDatas().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }

        public int CurrentCount => GetFilterDatas().Count();

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 9;

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
    }
}
