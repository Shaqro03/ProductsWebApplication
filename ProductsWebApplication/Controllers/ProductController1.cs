using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductsWebApplication.DAL;
using ProductsWebApplication.Models;

using System.Net.WebSockets;

namespace ProductsWebApplication.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController1(ProductDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           var products = _context.Products.ToList();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            if (products != null)
            {
              
                foreach (var product in products)
                {
                    var ProductViewModel = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                    };
                    productList.Add(ProductViewModel);
                }
                return View(productList);
            }
            return View(productList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var _Products = new ProductModel()
                {
                   Name = product.Name,
                   Description = product.Description,
                   Price = product.Price,

                };
                _context.Products.Add(_Products);
                _context.SaveChanges();
              
                return RedirectToAction("Index");
            }
            else
            {            
                return View();
            }
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == Id);
            if (product != null)
            {
                var productView = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                };
                return View(productView);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new ProductModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                };
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == Id);
            if (product != null)
            {
                var productView = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                };
                return View(productView);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel model)
        {
            var product = _context.Products.SingleOrDefault(x=> x.Id == model.Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

    }
}

