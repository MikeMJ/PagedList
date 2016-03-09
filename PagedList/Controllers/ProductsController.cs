using PagedList.Models;
using PagedList.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Extensions;

namespace PagedList.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index()
        {
            ProductsController pc = new ProductsController();
            IEnumerable<Product> products = GetSampleProducts();
            ProductsViewModel vm = new ProductsViewModel(products.ToPagedList());
            return View(vm);
        } 

        public ActionResult GoToPage(ProductsViewModel vm)
        {
            IEnumerable<Product> products = GetSampleProducts();
            var pagedProducts = products.ToPagedList(vm.PageNumber, vm.PageSize);
            pagedProducts.DisplayPage(vm.PageNumber);
            vm.Products = pagedProducts;
            return View("Index",vm);
        }

        private IEnumerable<Product> GetSampleProducts()
        {
            List<Product> products = new List<Product> { 
                new Product{Category=ProductCategory.Automative, ProductID=1,ProductName="Brake caliper",RetailPrice=120m,WholeSalePrice=105m},
                new Product{Category=ProductCategory.Automative, ProductID=2,ProductName="Windshield Wiper",RetailPrice=15m,WholeSalePrice=12m},
                new Product{Category=ProductCategory.Automative, ProductID=3,ProductName="Crank shaft",RetailPrice=900m,WholeSalePrice=790m},
                new Product{Category=ProductCategory.Automative, ProductID=4,ProductName="Piston ring",RetailPrice=70m,WholeSalePrice=61m},
                new Product{Category=ProductCategory.Clothing, ProductID=5,ProductName="Jacket",RetailPrice=99m,WholeSalePrice=90m},
                new Product{Category=ProductCategory.Clothing, ProductID=6,ProductName="Sweater",RetailPrice=40m,WholeSalePrice=35m},
                new Product{Category=ProductCategory.Clothing, ProductID=7,ProductName="Shorts",RetailPrice=22m,WholeSalePrice=20m},
                new Product{Category=ProductCategory.Footwear, ProductID=8,ProductName="Boots",RetailPrice=130m,WholeSalePrice=125m},
                new Product{Category=ProductCategory.Footwear, ProductID=9,ProductName="Oxfords",RetailPrice=220m,WholeSalePrice=200m},
                new Product{Category=ProductCategory.Jewellery, ProductID=10,ProductName="Gold ring",RetailPrice=430m,WholeSalePrice=400m},
                new Product{Category=ProductCategory.Electronics, ProductID=11,ProductName="Fan cooler",RetailPrice=15m,WholeSalePrice=12m},
                new Product{Category=ProductCategory.Electronics, ProductID=12,ProductName="Wrist band for iOS",RetailPrice=90m,WholeSalePrice=85m},
                new Product{Category=ProductCategory.Electronics, ProductID=13,ProductName="Drawing pad",RetailPrice=87m,WholeSalePrice=83m}

            };
            return products;
        }

    }
}
