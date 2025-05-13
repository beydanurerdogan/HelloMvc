using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OgrenciDBContext _context;

        public OgrenciController(OgrenciDBContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            return View("Anasayfa");
        }

        public ViewResult OgrenciListe()
        {
            var ogrenciListesi = _context.Ogrenci.ToList();
            return View(ogrenciListesi);
        }

        [HttpGet]
        public ViewResult OgrenciDetay(int id)
        {
            var ogrenci = _context.Ogrenci.Find(id);
            return View(ogrenci);
        }
        [HttpPost]
        public JsonResult OgrenciDetay(Ogrenci ogrenci)
        {
            try
            {
                _context.Entry(ogrenci).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true, redirectUrl = Url.Action("OgrenciListe", "Ogrenci") });
            }
            catch
            {
                return Json(new { success = false });
            }
        }



        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ViewResult OgrenciEkle(Ogrenci ogrenci)
        {
            int sonuc = 0;

            if (ogrenci != null)
            {
                _context.Ogrenci.Add(ogrenci);
                sonuc = _context.SaveChanges();
            }

            TempData["sonuc"] = sonuc > 0;
            return View();
        }

        public IActionResult OgrenciSil(int id)
        {
            var ogrenci = _context.Ogrenci.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenci.Remove(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction("OgrenciListe");
        }
    }
}


//Controller'dan View'e veri taşıma
//1-ViewData: Key-Value Collection. Key'ler mutlaka tekil olmalıdır.Key'ler string, Value'lar object'dir. Type-safe değildir.!
//2-ViewBag: Arka planda ViewData dictionary'sini kullanır. Bu durumda daha önce ViewData'larda kullanılan key'ler kullanılamaz.
//ViewBag'ler dynamic yapılardır ve içindeki türler RunTime sırasında tespit edilir. 
//3-Model:
//4-TempData**:

//Not: Generic olmayan collection'ların tip güvenliği olmaz.