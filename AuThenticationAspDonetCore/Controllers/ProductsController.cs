using System.Linq;
using AuThenticationAspDonetCore.Data;
using AuThenticationAspDonetCore.Models;
using AuThenticationAspDonetCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuThenticationAspDonetCore.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
         private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Index()
        {
            var listAllData = _db.Products.ToList();
            ViewData["Message"] = TempData["Message"];
            return View(listAllData);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _db.Categories.Select(i=> new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            
            if (id == null)
            {
                return View(productVm);
            }

            productVm.Product = _db.Products.Find(id);
            
            return View(productVm);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Upsert(ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                if (productVm.Product.Id == 0)
                {
                    _db.Products.Add(productVm.Product);
                    _db.SaveChanges();
                    TempData["Message"] = "Success: Add Successfully";
                    return RedirectToAction(nameof(Index));
                }

                _db.Products.Update(productVm.Product);
                _db.SaveChanges();
                TempData["Message"] = "Success: Update Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewData["Message"] = "Error: Invalid Input, Please Recheck Again";
            productVm.CategoryList = _db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View(productVm);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                ViewData["Message"] = "Error: Id input null";
            }
            var productNeedToDelete = _db.Products.Find(id);
            _db.Products.Remove(productNeedToDelete);
            _db.SaveChanges();
            TempData["Message"] = "Success: Delete Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}