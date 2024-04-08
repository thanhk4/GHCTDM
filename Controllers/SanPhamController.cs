using GHCTDM.Models;
using Microsoft.AspNetCore.Mvc;

namespace GHCTDM.Controllers
{
    public class SanPhamController : Controller
    {
        GhctdmSd18302Context context = new GhctdmSd18302Context();
        public SanPhamController()
        {
           
        }
        public IActionResult Index()
        {
            var dta = context.SanPhams.ToList();
            return View(dta);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham san)
        {
           

            context.SanPhams.Add(san);
       
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(Guid id, int amount)
        {
            var loginDT = HttpContext.Session.GetString("User");
            if (loginDT == null)
            
                return Content("Phai Dang nhap");
            
            else
            {
                Guid UseID = Guid.Parse(loginDT); // lấy ra Id của khách giỏ hàng
                //Lấy ra sản phẩm ID của nó trùng với ID của snar Sản Phẩm đâng được chọn
                var AllCart = context.GioHangCts.FirstOrDefault(x => x.IdSP == id && x.IdGH == UseID);
                if (AllCart != null)
                {
                    AllCart.Amount = AllCart.Amount + amount;
                    context.GioHangCts.Update(AllCart);
                    context.SaveChanges();
                }
                else
                {
                    GioHangCT gioHangCT = new GioHangCT()
                    {
                        Id = Guid.NewGuid(),
                        IdSP = id,
                        Amount = amount,
                        IdGH = UseID

                    };
                    context.GioHangCts.Add(gioHangCT);
                    context.SaveChanges();

                }
                return RedirectToAction("Index");
            }
        }

    }
}
