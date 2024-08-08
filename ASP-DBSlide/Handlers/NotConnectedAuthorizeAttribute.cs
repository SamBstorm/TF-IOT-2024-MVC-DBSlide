using BLL_DBSlide.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_DBSlide.Handlers
{  
    public class NotConnectedAuthorizeAttribute : CustomAuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            User? user = GetUser(context);
            if (user is null) return;
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
