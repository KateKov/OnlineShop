using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.Infrastracture;
using OnlineShop.Models;
using AutoMapper;
using OnlineShop.Helpers;
using static OnlineShop.Controllers.SortProduct;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IRepository<Brand> _brandsRepository;
        private readonly IRepository<Color> _colorsRepository;
        private readonly OnlineShopContext _context;
        private readonly List<CheckBox> colorsSet;

        public ProductsController()
        {
            _context = new OnlineShopContext();
            _productsRepository = new Repository<Product>(_context);
            _brandsRepository = new Repository<Brand>(_context);
            _colorsRepository = new Repository<Color>(_context);
            colorsSet = new List<CheckBox>();
            _colorsRepository.GetAll().ToList().ForEach(x => colorsSet.Add(new CheckBox { Text = x.CssColor }));
        }
        public CatalogViewModel GetPageInfo(IEnumerable<ProductViewModel> viewModelProducts, int page)
        {
            int pageSize = 9;
            IEnumerable<ProductViewModel> productsPerPages = viewModelProducts.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = viewModelProducts.ToList().Count };
            return new CatalogViewModel() { PageInfo=pageInfo, Products=productsPerPages };
        }
        [HttpGet]
        public ActionResult Index(string subcategory="Футболки и поло", string catalog="Для женщин", int page=1)
        {
           
            var products = GetProductsBySubcategory(catalog, subcategory);
            IEnumerable<ProductViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            CatalogViewModel catalogPerPage = GetPageInfo(viewModelProducts, page);
            CatalogViewModel catalogViewModel = new CatalogViewModel() { Products = catalogPerPage.Products, Colors=colorsSet, PageInfo=catalogPerPage.PageInfo, Subcategory=subcategory, Catalog= catalog };

            return View(catalogViewModel);
        }
        [Authorize(Roles="admin")]
        [HttpGet]
        public ActionResult ProductInfo(string id)
        {
            var product=_productsRepository.Get(Guid.Parse(id));
            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            productViewModel.OrderCount = 1;
            if(product==null)
            {
                return HttpNotFound();
            }
            return View(productViewModel);
        }
       
        [HttpPost]
        public ActionResult ProductFilter(CatalogViewModel catalogWithFilter, int page=1)
        {

            List<Product> chosenProducts = SortProducts(catalogWithFilter.Sort, GetProductsBySubcategory(catalogWithFilter.Catalog, catalogWithFilter.Subcategory));
            if (!IsNotChecked(catalogWithFilter))
            {
                if (catalogWithFilter.DiscountRange.Where(x => x.Checked).ToList().Count!=0)
                {
                    List<Product> buf = new List<Product>();
                    catalogWithFilter.DiscountRange.ForEach(x => buf.AddRange(GetByDiscount(x, chosenProducts)));
                    chosenProducts = buf;

                }

                if (catalogWithFilter.PriceRange.Where(x => x.Checked).ToList().Count != 0)
                {
                    List<Product> buf = new List<Product>();
                    catalogWithFilter.PriceRange.ForEach(x => buf.AddRange(GetByPrice(x, chosenProducts)));
                    chosenProducts = buf;
                }
                if (catalogWithFilter.Popularity.Where(x => x.Checked).ToList().Count != 0)
                {
                    List<Product> buf = new List<Product>();
                    catalogWithFilter.Popularity.ForEach(x => buf.AddRange(GetByPopularity(x, chosenProducts)));
                    chosenProducts = buf;
                }
                if (catalogWithFilter.Colors.Where(x => x.Checked).ToList().Count != 0)
                {
                    List<Product> buf = new List<Product>();
                    catalogWithFilter.Colors.ForEach(x => buf.AddRange(GetByColor(x, chosenProducts)));
                    chosenProducts = buf;
                }
            }
            
            IEnumerable<ProductViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(chosenProducts);
            CatalogViewModel catalogPerPage = GetPageInfo(viewModelProducts, page);
            CatalogViewModel catalog = new CatalogViewModel() { Products = catalogPerPage.Products, PageInfo = catalogPerPage.PageInfo, DiscountRange =catalogWithFilter.DiscountRange, Catalog=catalogWithFilter.Catalog, Colors=catalogWithFilter.Colors, Popularity=catalogWithFilter.Popularity, PriceRange=catalogWithFilter.PriceRange, Subcategory=catalogWithFilter.Subcategory };
            return PartialView(catalog);

        }
        private List<Product> SortProducts(Sort sortby, List<Product> products)
        {
            switch(sortby)
            {
                case Sort.популярности:
                    products = products.OrderBy(m => m.Popularity).ToList();
                    break;
                case Sort.новизне:
                    products = products.OrderBy(m => m.DateOfAddition).ToList();
                    break;
                case Sort.имени:
                    products = products.OrderBy(m => m.Title).ToList();
                    break;
            }
            return products;
        }
        private List<Product> GetProductsBySubcategory(string catalog, string subcategory)
        {
            return _productsRepository.GetAll().Where(p => p.Subcategory.Category.Catalog.Title == catalog).Where(p => p.Subcategory.Title == subcategory).OrderBy(p=>p.Popularity).ToList();
        }
        private bool IsNotChecked(CatalogViewModel catalogViewModel)
        {
            if (catalogViewModel.DiscountRange.Where(x => x.Checked).ToList().Count==0&& catalogViewModel.PriceRange.Where(x => x.Checked).ToList().Count==0&& catalogViewModel.Popularity.Where(x => x.Checked).ToList().Count == 0 && catalogViewModel.Colors.Where(x => x.Checked).ToList().Count == 0)
            {
                return true;
            }
            return false;
        }
        private List<Product> GetByColor(CheckBox color, List<Product> products)
        {
            List<Product> chosenProducts = new List<Product>();
            if (color.Checked)
            {
                chosenProducts = products.Where(x => x.Color.CssColor==color.Text).ToList();
                
            }
            return chosenProducts;

        }
        private List<Product> GetByPopularity(CheckBox popularity, List<Product> products)
        {
            List<Product> chosenProducts = new List<Product>();
            if (popularity.Checked)
            {
                switch (popularity.Text)
                {
                    case "2.png":
                        chosenProducts = products.Where(x => x.Popularity <= 2).ToList();
                        break;
                    case "3.png":
                        chosenProducts = products.Where(x => x.Popularity > 2 && x.Popularity<= 3).ToList();
                        break;
                    case "4.png":
                        chosenProducts = products.Where(x => x.Popularity > 3 && x.Popularity <= 4).ToList();
                        break;
                    case "5.png":
                        chosenProducts = products.Where(x => x.Popularity > 4 && x.Popularity <= 5).ToList();
                        break;
                   
                }
            }
            return chosenProducts;
        }
        private List<Product> GetByPrice(CheckBox price, List<Product> products)
        {
            List<Product> chosenProducts = new List<Product>();
            if (price.Checked)
            {
                switch (price.Text)
                {
                    case "0-100 грн":
                        chosenProducts = products.Where(x => x.Price <= 100).ToList();
                        break;
                    case "100-250 грн":
                        chosenProducts = products.Where(x => x.Price > 100 && x.Price <= 250).ToList();
                        break;
                    case "250-500 грн":
                        chosenProducts = products.Where(x => x.Price > 250 && x.Price <= 500).ToList();
                        break;
                    case "500-750 грн":
                        chosenProducts = products.Where(x => x.Price> 500 && x.Price <= 750).ToList();
                        break;
                    case "750-1000 грн":
                        chosenProducts = products.Where(x => x.Price > 750 && x.Price <= 1000).ToList();
                        break;
                    case "Больше 1000 грн":
                        chosenProducts = products.Where(x => x.Price > 1000).ToList();
                        break;
                }
               
            }
            return chosenProducts;
        }
        private List<Product> GetByDiscount(CheckBox discount, List<Product> products)
        {
            List<Product> chosenProducts = new List<Product>();
            if (discount.Checked)
            {
                switch (discount.Text)
                {
                    case "0-10%":
                        chosenProducts = products.Where(x => x.Discount <= 10).ToList();
                        break;
                    case "10-30%":
                        chosenProducts = products.Where(x => x.Discount > 10 && x.Discount <= 30).ToList();
                        break;
                    case "30-50%":
                        chosenProducts = products.Where(x => x.Discount > 30 && x.Discount <= 50).ToList();
                        break;
                    case "50-75%":
                        chosenProducts = products.Where(x => x.Discount > 50 && x.Discount <= 75).ToList();
                        break;
                }
            }
            return chosenProducts;

        }
    }
}
