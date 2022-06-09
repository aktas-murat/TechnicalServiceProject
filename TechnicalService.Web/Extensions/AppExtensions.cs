using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace TechnicalService.Web.Extensions
{
    public static class AppExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            //var claims = context.User.Claims.ToList();
            return context.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
        public static string ToFullErrorString(this ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState.Values)
            {
                foreach (var error in entry.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}
