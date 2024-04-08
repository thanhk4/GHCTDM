using GHCTDM.Models;
using Microsoft.AspNetCore.Mvc;

namespace GHCTDM.Controllers
{
    public class GioHangCTController : Controller
    {
        GhctdmSd18302Context context;
        public GioHangCTController()
        {
            context = new();
        }

        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("User");
            if(login == null)
                return RedirectToAction("Login","User");
            else
            {
                var all = context.GioHangCts.Where(x => x.IdGH == Guid.Parse(login)).ToList();
                return View(all);
            }
           
        
        }
    }
}
