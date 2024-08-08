using BLL_DBSlide.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ASP_DBSlide.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public abstract void OnAuthorization(AuthorizationFilterContext context);

        protected User? GetUser(AuthorizationFilterContext context)
        {
            return JsonSerializer.Deserialize<User?>(context.HttpContext.Session.GetString("CurrentUser") ?? "null");
        }

        protected void SetUser(AuthorizationFilterContext context, User user)
        {
            context.HttpContext.Session.SetString("CurrentUser",JsonSerializer.Serialize<User>(user));
        }
    }
}
