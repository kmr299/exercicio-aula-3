using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public abstract class BaseController : Controller
    {
        protected int GetLoggedUserId()
        {
            if (User.Identity.IsAuthenticated)
                return Convert.ToInt32(User.Identity.Name);
            return 0;
        }
    }
}
