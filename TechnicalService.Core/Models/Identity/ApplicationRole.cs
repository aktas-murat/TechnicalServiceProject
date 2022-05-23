using Microsoft.AspNetCore.Identity;

namespace TechnicalService.Core.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }

        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

    }
}
