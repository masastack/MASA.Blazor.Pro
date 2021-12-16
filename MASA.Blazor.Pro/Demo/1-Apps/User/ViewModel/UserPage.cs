using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Demo
{
    public class UserPage
    {
        public UserPage(List<UserData> datas)
        {
            UserDatas = new List<UserData>();
            UserDatas.AddRange(datas);
        }

        public List<UserData> UserDatas { get; set; }

        public string? Role { get; set; }

        public string? Plan { get; set; }

        public string? Status { get; set; }

        public string? Search { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int PageCount => (int)Math.Ceiling(CurrentCount / (double)PageSize);

        public int CurrentCount => GetFilterDatas().Count();

        private IEnumerable<UserData> GetFilterDatas()
        {
            IEnumerable<UserData> datas = UserDatas;
            
            if(Search is not null)
            {
                datas = datas.Where(d => d.FullName.Contains(Search) || d.Email?.Contains(Search)==true);
            }

            if(Role is not null)
            {
                datas = datas.Where(d => d.Role==Role);
            }

            if (Plan is not null)
            {
                datas = datas.Where(d => d.Plan == Plan);
            }

            if (Status is not null)
            {
                datas = datas.Where(d => d.Status == Status);
            }

            if(datas.Count()<(PageIndex-1)* PageSize) PageIndex = 1;

            return datas;
        }

        public List<UserData> GetPageDatas()
        {
            return GetFilterDatas().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
