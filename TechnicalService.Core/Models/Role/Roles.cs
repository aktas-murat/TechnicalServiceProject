namespace TechnicalService.Core.Role
{
    public static class Roles
    {
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";
        public static readonly string Passive = "Passsive";
        public static readonly string Operator = "Operator";
        public static readonly string Technician = "Technician";

        public static List<string> RoleList = new List<string>()
        {
            Admin, User, Passive, Operator, Technician
        };
    }
}
