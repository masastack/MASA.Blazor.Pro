using BlazorComponent;
using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Apps.User
{
    public partial class List
    {
        List<KeyValuePair<string, bool>> Roles = new Dictionary<string, bool>
        {
            { "Admin", false },
            { "Author", false },
            { "Editor", false },
            { "Maintainer", false },
            { "Subscriber", false }
        }.ToList();

        List<KeyValuePair<string, bool>> Plans = new Dictionary<string, bool>
        {
            { "Basic", false },
            { "Company", false },
            { "Enterprise", false },
            { "Team", false }
        }.ToList();

        List<KeyValuePair<string, bool>> Status = new Dictionary<string, bool>
        {
            { "Pending", false },
            { "Active", false },
            { "Inactive", false }
        }.ToList();


        public bool SelectHideDetails = true;

        private List<DataTableHeader<UserData>> Headers = new List<DataTableHeader<UserData>>
        {
           new ()
           {
            Text= "USER",
            Value= nameof(UserData.FullName),
          },
          new (){ Text= "EMAIL", Value= nameof(UserData.Email)},
          new (){ Text= "ROLE", Value= nameof(UserData.Role)},
          new (){ Text= "PLAN", Value= nameof(UserData.Plan)},
          new (){ Text= "STATUS", Value= nameof(UserData.Status)}
        };

        public List<string> SortBy = new()
        {
            nameof(UserData.FullName),
            nameof(UserData.Email),
            nameof(UserData.Role),
            nameof(UserData.Plan),
            nameof(UserData.Status)
        };

        public List<UserData> UserDatas = UserService.UserDatas;

        private string _search;

        public List<bool> SortDesc = new()
        {
           
        };

    }
}
