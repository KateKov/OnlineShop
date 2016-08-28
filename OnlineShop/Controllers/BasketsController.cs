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
    public class BasketsController : Controller
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IRepository<Basket> _basketsRepository;
        private readonly IRepository<OrderProduct> _orderProducts;
        private readonly OnlineShopContext _context;
        private readonly Basket _basket;
        public BasketsController()
        {
            _context = new OnlineShopContext();
            _productsRepository = new Repository<Product>(_context);
            _orderProducts = new Repository<OrderProduct>(_context);
            _basketsRepository = new Repository<Basket>(_context);
            _basket = (_basketsRepository.GetAll().ToList().Count!=0)?_basketsRepository.GetAll().First():new Basket() { Id= Guid.NewGuid()};
        }
        [HttpPost]
        public ActionResult AddToBasket(ProductViewModel product)
        {
            OrderProduct orderProduct;
            var orderbuf = _basket.OrderProducts.Where(x => x.Product == _productsRepository.Get(product.Id)).ToList();
            if (orderbuf.Count != 0)
            {
                orderProduct = orderbuf.First();
                orderProduct.Count += product.OrderCount;
                _orderProducts.Update(orderProduct);
            }
            else
            {
                orderProduct = new OrderProduct() { Id = Guid.NewGuid(), Product = _productsRepository.Get(product.Id), Count = product.OrderCount };
                _orderProducts.Create(orderProduct);
            }
            
            _basket.OrderProducts.Add(orderProduct);

            if (_basketsRepository.Get(_basket.Id) != null) {
                _basketsRepository.Update(_basket); }
            else { _basketsRepository.Create(_basket); }
     
            return RedirectToAction("Index");

        }
        // GET: Basket
        public ActionResult Index()
        {
            
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach(var item in _basket.OrderProducts.ToList())
            {

                Product product = item.Product;
                ProductViewModel viewModelProduct = Mapper.Map<Product, ProductViewModel>(product);
                orderViewModels.Add(new OrderViewModel() { Count = item.Count, Product = viewModelProduct, Summ=OrderModel.Summ(viewModelProduct, item.Count) });
            }
            BasketViewModel basket = new BasketViewModel() { Orders = orderViewModels };
            _basket.Summ = basket.Summ;
            _basketsRepository.Update(_basket);
            return View(basket);
        }
    }
}