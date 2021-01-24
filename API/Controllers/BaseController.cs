using Core.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController: ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}