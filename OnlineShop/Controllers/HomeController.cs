using AutoMapper;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Infrastracture;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly OnlineShopContext _context;

        public HomeController()
        {
            _context = new OnlineShopContext();
            _productsRepository = new Repository<Product>(_context);
        }
        public ActionResult Index()
        {
            var products = _productsRepository.GetAll().Where(x=>x.Amount>0).OrderByDescending(m => m.Popularity).Take(8).ToList();
            IEnumerable<ProductViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            
            return View(viewModelProducts);
        }
        [HttpPost]
        public ActionResult ProductSearch(string name)
        {
            var products = _productsRepository.GetAll().Where(a => (a.Title.Contains(name)||a.Collection.Name.Contains(name)||a.Collection.Brand.Name.Contains(name))).ToList();
            IEnumerable<ProductViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
           
            return PartialView(viewModelProducts);
        }

    }
}