using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Pages.Apps.User
{
    public partial class List
    {
        public bool _visible;
        public UserPage _userPage = new(UserService.UserDatas);
        private List<int> _pageSizes = new()
        {
            10,25,50,100
        };
        private readonly List<DataTableHeader<UserData>> _headers = new()
        {
            new (){ Text= "USER", Value= nameof(UserData.UserName),CellClass=""},
            new (){ Text= "EMAIL", Value= nameof(UserData.Email)},
            new (){ Text= "ROLE", Value= nameof(UserData.Role)},
            new (){ Text= "PLAN", Value= nameof(UserData.Plan)},
            new (){ Text= "STATUS", Value= nameof(UserData.Status)},
            new (){ Text= "ACTIONS", Value= "Action",Sortable=false}
        };
        private readonly Dictionary<string, string> _roleIconMap = new()
        {
            ["Editor"] = "mdi-pencil,info",
            ["Subscriber"] = "mdi-account,pry",
            ["Admin"] = "mdi-account-edit,error",
            ["Maintainer"] = "mdi-database,sample-green",
            ["Author"] = "mdi-cog,remind",
        };

        public override string Name { get; } = "User-List";

        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/apps/user/view/{id}");
        }

        private void NavigateToEdit(string id)
        {
            Nav.NavigateTo($"/apps/user/edit/{id}");
        }

        private void AddUserData(UserData userData)
        {
            _userPage.UserDatas.Insert(0, userData);
        }
    }
}
