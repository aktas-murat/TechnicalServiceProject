namespace TechnicalService.Web.ViewModels.Account
{
    public class UserRoleChangeViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }
        public string UserName { get; set; }

        public IEnumerable<string> Role { get; set; }
    }
}
