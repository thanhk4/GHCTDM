using GHCTDM.Models;
using Microsoft.AspNetCore.Mvc;

namespace GHCTDM.Controllers
{
    public class UserController : Controller
    {
        GhctdmSd18302Context context;
        public UserController()
        {
            context = new GhctdmSd18302Context();
        }

        public IActionResult Index()
        {
            var dta = context.users.ToList();
            return View(dta);
        }
        public IActionResult Create()
        {
         
            return View();
        }
        [HttpPost]  
        public IActionResult Create(User user)
        {
            var giohang = new GioHang()
            {
                Id = user.Id,
                Status = 1
            };

          context.users.Add(user);
            context.GioHangs.Add(giohang);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            var Usse = context.users.FirstOrDefault(x => x.Name == name && x.Pass == password);
            if (Usse != null)
            {
                //return Content("Error");
                //TempData["login"] = Usse.Name;
                // Lưu trữ thông tin đăng nhập vào Seession
                HttpContext.Session.SetString("User", Usse.Id.ToString());
                return RedirectToAction("Index", "SanPham");
            }
            else return Content("Thất bại");

        }
    }
}
