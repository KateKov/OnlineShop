using AutoMapper;
using Newtonsoft.Json;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Infrastracture;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Helpers;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
       
        private readonly IRepository<Product> _productsRepository;
        private readonly OnlineShopContext _context;


        public ProductsController()
        {
            _context = new OnlineShopContext();
            _productsRepository = new Repository<Product>(_context);
        }

        public ActionResult Index()
        {
            var products = GetProductsBySubcategory();
            IEnumerable<ProductsTableViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductsTableViewModel>>(products);
            ViewBag.Catalogs = viewModelProducts.Select(x => x.Catalog).Distinct().ToList();
            ViewBag.Categories = viewModelProducts.Select(x => x.Category).Distinct().ToList();
            ViewBag.Brands = viewModelProducts.Select(x => x.Brand).Distinct().ToList();
            ViewBag.Subcategories= viewModelProducts.Select(x => x.Subcategory).Distinct().ToList();
            return View();
        }
        private List<Product> GetProductsBySubcategory()
        {
            return _productsRepository.GetAll().Where(p => p.Amount > 0).OrderBy(p => p.Popularity).ToList();
        }
        private Dictionary<string, string> GetElements(HttpRequestBase httpRequest)
        {
            Dictionary<string, string> elements = new Dictionary<string, string>();
            elements["draw"]=httpRequest.Form.GetValues("draw").FirstOrDefault();
            elements["start"]=httpRequest.Form.GetValues("start").FirstOrDefault();
            elements["length"] = httpRequest.Form.GetValues("length").FirstOrDefault();
            elements["sortColumn"] = httpRequest.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            elements["sortColumnDir"] = httpRequest.Form.GetValues("order[0][dir]").FirstOrDefault();
            elements["titleInput"] = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            elements["catalogInput"] = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();
            elements["categoryInput"] = Request.Form.GetValues("columns[8][search][value]").FirstOrDefault();
            elements["subcategoryInput"] = Request.Form.GetValues("columns[9][search][value]").FirstOrDefault();
            elements["brandInput"] = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
         
            return elements;
        }
        private Dictionary<string, int> GetPageInfo(string length, string start)
        {
            Dictionary<string, int> pageInfo = new Dictionary<string, int>();
            pageInfo["pageSize"]= length != null ? Convert.ToInt32(length) : 0;
            pageInfo["skip"]= start != null ? Convert.ToInt32(start) : 0;
            return pageInfo;
        }

        [HttpPost]
        public ActionResult LoadData(string subcategory = "Футболки и поло", string catalog = "Для женщин")
        {
            Dictionary<string, string> elements = GetElements(Request);
            Dictionary<string, int> pageInfo = GetPageInfo(elements["length"], elements["start"]);
            var products = GetProductsBySubcategory();
            IEnumerable<ProductsTableViewModel> viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductsTableViewModel>>(products);
            viewModelProducts = FilterBy(1, "Title", viewModelProducts, Request);
            viewModelProducts = FilterBy(7, "Catalog", viewModelProducts, Request);
            viewModelProducts = FilterBy(8, "Category", viewModelProducts, Request);
            viewModelProducts = FilterBy(9, "Subcategory", viewModelProducts, Request);
            viewModelProducts = FilterBy(6, "Brand", viewModelProducts, Request);
            if (!(string.IsNullOrEmpty(elements["sortColumn"]) && string.IsNullOrEmpty(elements["sortColumnDir"])))
            {
                viewModelProducts = viewModelProducts.OrderBy(elements["sortColumn"] + " " + elements["sortColumnDir"]);
            }
            var totalRecords = viewModelProducts.ToList().Count();
            var data = viewModelProducts.Skip(pageInfo["skip"]).Take(pageInfo["pageSize"]).ToList();
            return Json(new { draw=elements["draw"], recordsFiltered=totalRecords, recordsTotal=totalRecords, data=data }, JsonRequestBehavior.AllowGet);
           

        }
        public IEnumerable<ProductsTableViewModel> FilterBy(int index, string checkedClass, IEnumerable<ProductsTableViewModel> products, HttpRequestBase httpRequest)
        {
           
             Type productType = typeof(ProductsTableViewModel);

            List<ProductsTableViewModel> productsTable = new List<ProductsTableViewModel>();
            string search = "columns[" + index + "][search][value]";
            var input = httpRequest.Form.GetValues(search).FirstOrDefault();
            if (!string.IsNullOrEmpty(input) && !input.Contains("Выберите"))
            {
                foreach (var model in products)
                {
                    if (model.GetType().GetProperty(checkedClass).GetValue(model).ToString() == input)
                        productsTable.Add(model);
                }
                return productsTable;
            }
            return products;
        }

        //// GET: Articles/Details/5
        //public ActionResult Details(string id)
        //{
        //    return View(_productsRepository.Get(Guid.Parse(id)));
        //}
        //public CatalogViewModel GetPageInfo(IEnumerable<ProductViewModel> viewModelProducts, int page)
        //{
        //    int pageSize = 9;
        //    IEnumerable<ProductViewModel> productsPerPages = viewModelProducts.Skip((page - 1) * pageSize).Take(pageSize);
        //    PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = viewModelProducts.ToList().Count };
        //    return new CatalogViewModel() { PageInfo = pageInfo, Products = productsPerPages };
        //}

        //public ActionResult Create(string id)
        //{

        //    Product model = new Product();
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        model = _productsRepository.Get(Guid.Parse(id));
        //    }
        //    return View(model);
        //}
        //private List<Product> GetProductsBySubcategory(string catalog, string subcategory)
        //{
        //    return _productsRepository.GetAll().Where(p => p.Amount > 0).Where(p => p.Subcategory.Category.Catalog.Title == catalog).Where(p => p.Subcategory.Title == subcategory).OrderBy(p => p.Popularity).ToList();
        //}
        //// POST: Articles/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ArticleId,AuthorId,Title,Photo,Date,Text")] Product product)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _productsRepository.Create(product);
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        //// GET: Articles/Edit/5
        //public ActionResult Edit(string id)
        //{

        //    ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name");
        //    ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
        //    return View(articleRepository.Get(id));
        //}

        //// POST: Articles/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Article article, HttpPostedFileBase image)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (image != null)
        //        {
        //            // get name of the file
        //            string fileName = System.IO.Path.GetFileName(image.FileName);
        //            // save in the folder "Content" the image
        //            image.SaveAs(Server.MapPath("~/Content/" + fileName));
        //            article.Photo = "../../Content/" + fileName;
        //        }
        //        articleRepository.Update(article);
        //        TempData["EditArticle"] = "Updaited Article " + article.ArticleId;

        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name", article.AuthorId);
        //    ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
        //    return View(article);


        //}

        //// GET: Articles/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View(articleRepository.Get(id));

        //}

        //// POST: Articles/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, Article article)
        //{
        //    try
        //    {
        //        articleRepository.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //// GET: Admin/Products
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}