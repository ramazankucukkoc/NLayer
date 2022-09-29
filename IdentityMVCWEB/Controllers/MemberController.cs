using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMVCWEB.Controllers
{
    [Authorize]
    public class MemberController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
