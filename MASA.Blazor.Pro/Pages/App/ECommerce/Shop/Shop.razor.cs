namespace MASA.Blazor.Pro.Pages.App.ECommerce.Shop
{
    public partial class Shop : ProCompontentBase
    {
        private readonly List<MultiRange> _multiRanges = new List<MultiRange>
        {
            new(RangeType.All,"All",0),
            new(RangeType.LessEqual,"<= $10",10),
            new(RangeType.Range,"$10 - $100",10,100),
            new(RangeType.Range,"$100 - $500",100,500),
            new(RangeType.MoreEqual,">=$500",500),
        };
        private readonly List<string> _categories = new()
        {
            "饮水机",
            "纯水机",
            "商务机",
            "胶囊机",
            "空净系列",
            "中央处理设备",
            "Cell Phones",
            //"Audio", "Appliances",
            //"Computers & Tablets", "Health, Fitness & Beauty", "Office & School Supplies","TV & Home Theater",
        };
        private readonly List<string> _brands = new()
        {
            "LONSID",
            "Apple"
        };
        private readonly ShopPage _shopData = new(ShopService.GetGoodsList());

        [Inject]
        public NavigationManager Nav { get; set; } = default!;

        public override string Name => "App-eCommerce-Shop";

        protected override void OnInitialized()
        {
            _shopData.MultiRange = _multiRanges[0];
        }

        private void NavigateToDetails(Guid id)
        {
            Nav.NavigateTo($"app/ecommerce/details/{id}");
        }

        private void NavigateToOrder()
        {
            Nav.NavigateTo($"app/ecommerce/order");
        }
    }
}
