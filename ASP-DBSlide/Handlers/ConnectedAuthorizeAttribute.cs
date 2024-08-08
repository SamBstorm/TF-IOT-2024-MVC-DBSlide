using BLL_DBSlide.Entities;
using BLL_DBSlide.Entities.Enums;
using Common_DBSlide.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_DBSlide.Handlers
{
    public class ConnectedAuthorizeAttribute : CustomAuthorizeAttribute
    {
        private string[] _roles;

        public ConnectedAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            User? user = GetUser(context);
            if (user is not null) {
                if (_roles.Count() == 0) return;
                IUserRepository<User, Role> _service = context.HttpContext.RequestServices.GetRequiredService<IUserRepository<User,Role>>();
                IEnumerable<Role> roles = _service.GetRoles(user.User_Id);
                foreach (string role in _roles) {
                    if (roles.Contains(Enum.Parse<Role>(role))) return;
                }
            }
            context.Result = new RedirectToActionResult("Login", "Auth", null);

        }
    }
}
