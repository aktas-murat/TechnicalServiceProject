namespace TechnicalServiceProject.Models.Role
{
    public static class Roles
    {
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";
        public static readonly string Passive = "Passsive";

        public static List<string> RoleList = new List<string>()
        {
            Admin, User, Passive
        };
    }
}
