using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.Helper
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext is HttpContext httpContext)
            {
                var userIdFromSession = httpContext.Session.GetInt32("userId");

                if (userIdFromSession == null)
                {
                    context.HttpContext.Response.Redirect("/Login");
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
