using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.EF
{
    public  class OnlineShopDbInitializer: DropCreateDatabaseAlways<OnlineShopContext>
    {
        protected override void Seed(OnlineShopContext context)
        {
            //Generate lists with data
            Colors = GenerateColors();
            Catalogs = GenerateCatalogs();
            Categories = GenerateCategories();
            Brands = GenerateBrands();
            Collections = GenerateCollections();
            Subcategories = GenerateSubcategories();
            Shirts = GenerateShirts();
            Images = ImageShirts();
            Sizes = GenerateSizes();
            //Add lists to Database
            Colors.ForEach(c => context.Colors.Add(c));
            Catalogs.ForEach(c => context.Catalogs.Add(c));
            Categories.ForEach(c => context.Categories.Add(c));
            Subcategories.ForEach(c => context.Subcategories.Add(c));
            Brands.ForEach(c => context.Brands.Add(c));
            Collections.ForEach(c => context.Collections.Add(c));
            Shirts.ForEach(c => context.Products.Add(c));
            Images.ForEach(c => context.Images.Add(c));
            Sizes.ForEach(c => context.Sizes.Add(c));

            var manager = new UserManager<User>(new UserStore<User>(context));


            ////create user
            var admin = new User() { UserName = "Admin", Email = "admin@gmail.com", FirstName = "Екатерина", LastName = "Коваленко" };
            context.Users.Add(admin);
            string password = "Aaa333";
            var result = manager.Create(admin, password);

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // create roles
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);



            // add role for user

         
                manager.AddToRole(admin.Id, role1.Name);
                manager.AddToRole(admin.Id, role2.Name);
            
            context.SaveChanges();
        }
        private List<Color> Colors;
        private List<Color> GenerateColors()
        {
            List<Color> colors = new List<Color>
            {
                new Color()
                {
                    Id=Guid.NewGuid(),  Name="Синий", CssColor="#0AA5E2"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Голубой", CssColor="#40E0D0"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Малиновый", CssColor="#B03060"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Темно-синий", CssColor="#000080"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Красный", CssColor="#E60D41"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Зеленый", CssColor="#45BF55"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Оранжевый", CssColor="#FF7F00"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Коричневый", CssColor="#8B4513"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Желтый", CssColor="#FFD700"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Серый", CssColor="#9FA8AB"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Розовый", CssColor="#FFCBDB"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Черный", CssColor="#000000"
                },
                new Color()
                {
                    Id=Guid.NewGuid(), Name="Белый", CssColor="#FFFFFF"
                }

            };
            return colors;
        }
        private List<Size> Sizes;
        private List<Size> GenerateSizes()
        {
            List<Size> sizes = new List<Size>()
            {
                new Size() { Id=Guid.NewGuid(), Number=42, Products=Shirts },
                new Size() { Id=Guid.NewGuid(), Number=44, Products=Shirts },
                new Size() { Id=Guid.NewGuid(), Number=46, Products=Shirts },
                new Size() { Id=Guid.NewGuid(), Number=48, Products=Shirts }
            };
            return sizes;
        }
        private List<Image> Images;
        private List<Image> ImageShirts()
        {
            string path = "~/Content/images/women/clothes/Shirt/";
            List<Image> images = new List<Image>
            {
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"1_aqua_oodji.jpg", ProductId=Shirts[0].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"1_blue_oodji.jpg", ProductId=Shirts[1].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"1_red_oodji.jpg", ProductId=Shirts[2].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"2_black_oodji.jpg", ProductId=Shirts[4].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"2_blue_oodji.jpg", ProductId=Shirts[3].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"3_blue_sela.jpg", ProductId=Shirts[5].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"3_gray_sela.jpg", ProductId=Shirts[6].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"4_gray_incity.jpg", ProductId=Shirts[7].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"4_black_incity.jpg", ProductId=Shirts[8].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"4_white_incity.jpg", ProductId=Shirts[9].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"5_white_ТВОЕ.jpg", ProductId=Shirts[10].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"6_white_ТВОЕ.jpg", ProductId=Shirts[11].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"7_white_oodji.jpg", ProductId=Shirts[12].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"8_black_Bestia.jpg", ProductId=Shirts[13].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"9_green_oodji.jpg", ProductId=Shirts[14].Id },
                new Image() {Id=Guid.NewGuid(), ImagePath=path+"10_blackwhite_sOliver.jpg", ProductId=Shirts[15].Id },

            };
            return images;
        }
        private List<Product> Shirts;
        private List<Product> GenerateShirts()
        {
            List<Product> products = new List<Product>
            {
                new Product() {Id=Guid.NewGuid(),Popularity=4.5, Price=89m, Title="Футболка", Discount=30, Materials="Хлопок - 100%", SubcategoryId=Subcategories[0].Id, CollectionId=Collections[0].Id,  Amount=14, DateOfAddition=DateTime.Parse("2016-08-08"), ColorId=Colors[1].Id, Description="Прекрасная синяя футболка из новой коллекции" },
                new Product() {Id=Guid.NewGuid(), Popularity=4.5, Price=89m, Title="Футболка", Discount=30,Materials="Хлопок - 100%", SubcategoryId=Subcategories[0].Id, CollectionId=Collections[0].Id, Amount=10, DateOfAddition=DateTime.Parse("2016-08-08"), ColorId=Colors[11].Id, Description="Прекрасная черная футболка из новой коллекции" },
                new Product() {Id=Guid.NewGuid(), Popularity=4.5, Price=89m, Title="Футболка", Discount=30, Materials="Хлопок - 100%", SubcategoryId=Subcategories[0].Id, CollectionId=Collections[0].Id,  Amount=12, DateOfAddition=DateTime.Parse("2016-08-08"), ColorId=Colors[4].Id, Description="Прекрасная красная футболка из новой коллекции" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=95m, Title="Футболка со звездой", Discount=45, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[0].Id,  Amount=14, DateOfAddition=DateTime.Parse("2016-08-08"), ColorId=Colors[0].Id, Description="Прекрасная синяя футболка со звездой" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=95m, Title="Футболка со звездой", Discount=45, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[0].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-08-08"), ColorId=Colors[11].Id, Description="Прекрасная черная футболка со звездой" },
                new Product() {Id=Guid.NewGuid(), Popularity=4.5, Price=155m, Title="Поло", Discount=0, Materials="Вискоза - 95%; Эластан - 5%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[1].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[1].Id, Description="Поло голубого цвета" },
                new Product() {Id=Guid.NewGuid(), Popularity=4.5, Price=155m, Title="Поло", Discount=0, Materials="Вискоза - 95%; Эластан - 5%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[1].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[9].Id, Description="Поло серого цвета" },
                new Product() {Id=Guid.NewGuid(), Popularity=5, Price=85m, Title="Майка", Discount=75, Materials="Хлопок - 50%, Полиэстер - 50%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[2].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[9].Id, Description="Чудесная серая майка" },
                new Product() {Id=Guid.NewGuid(), Popularity=5, Price=85m, Title="Майка", Discount=75, Materials="Хлопок - 50%, Полиэстер - 50%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[2].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[11].Id, Description="Чудесная черная майка" },
                new Product() {Id=Guid.NewGuid(), Popularity=5, Price=85m, Title="Майка", Discount=75, Materials="Хлопок - 50%, Полиэстер - 50%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[2].Id,  Amount=10, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[12].Id, Description="Чудесная белая майка" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=170m, Title="Футболка с собачкой", Discount=25, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[3].Id,  Amount=15, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[12].Id, Description="Классная футболка с принтом в виде собачки" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=170m, Title="Футболка с принтом", Discount=25, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[3].Id,  Amount=13, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[12].Id, Description="Классная футболка с городским принтом" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=150m, Title="Футболка с принтом", Discount=50, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[3].Id,  Amount=15, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[12].Id, Description="Классная футболка с принтом" },
                new Product() {Id=Guid.NewGuid(), Popularity=4, Price=85m, Title="Футболка с цветами", Discount=75, Materials="Хлопок - 100%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[0].Id,  Amount=7, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[11].Id, Description="Черная футболка с цветами" },
                new Product() {Id=Guid.NewGuid(), Popularity=5, Price=250m, Title="Свитерок", Discount=25, Materials="Вискоза - 95%; Эластан - 5%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[4].Id,  Amount=15, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[5].Id, Description="Зеленый свитерок" },
                new Product() {Id=Guid.NewGuid(), Popularity=5, Price=250m, Title="Свитерок в полоску", Discount=25, Materials="Вискоза - 95%; Эластан - 5%",SubcategoryId=Subcategories[0].Id,  CollectionId=Collections[5].Id,  Amount=15, DateOfAddition=DateTime.Parse("2016-07-07"), ColorId=Colors[12].Id, Description="Черно-белый свитерок" },
        };
            return products;
        }
        private List<Collection> Collections;
        private List<Collection> GenerateCollections()
        {
            List<Collection> collections = new List<Collection>
            {
                new Collection() {Id = Guid.NewGuid(), Name = "ВеснаЛето-2016", Description = "Коллекция Oodji", BrandId=Brands[0].Id},
                new Collection() {Id = Guid.NewGuid(), Name = "Осень-Зима-2016", Description = "Коллекция Sela", BrandId=Brands[1].Id},
                new Collection() {Id = Guid.NewGuid(), Name = "Летно-2016", Description = "Коллекция Incity", BrandId=Brands[2].Id},
                new Collection() {Id = Guid.NewGuid(), Name = "Весна-2016", Description = "Коллекция ТВОЕ", BrandId=Brands[3].Id},
                 new Collection() {Id = Guid.NewGuid(), Name = "Летний сезон", Description = "Коллекция Bestia", BrandId=Brands[4].Id},
                 new Collection() {Id = Guid.NewGuid(), Name = "Осенний сезон", Description = "Коллекция S.Oliver", BrandId=Brands[4].Id},



            };
            return collections;
        }
        private List<Brand> Brands;
        private List<Brand> GenerateBrands()
        {
            List<Brand> brands = new List<Brand>
            {
                new Brand() {Name = "Oodji", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге." },
                new Brand() {Name = "Sela", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге."},
                new Brand() {Name = "Incity", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге."},
                new Brand() {Name = "ТВОЕ", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге." },
                new Brand() {Name = "Bestia", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге." },
                new Brand() {Name = "S.Oliver", Id = Guid.NewGuid(), Description = "Российская компания, управляющая сетью магазинов молодёжной одежды. Основана в 1998 году в Санкт-Петербурге." }

            };
            return brands;
        }
        private List<Subcategory> Subcategories;
        private List<Subcategory> GenerateSubcategories()
        {
            List<Subcategory> dresses = new List<Subcategory> {
                new Subcategory() {Id = Guid.NewGuid(), Title="Футболки и поло",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Платья и сарафаны",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Брюки",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Юбки",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Джинсы",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Пиджаки и костюмы",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Блузы, рубашки",  CategoryId=Categories[0].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Свитера",  CategoryId=Categories[0].Id},

                new Subcategory() {Id = Guid.NewGuid(), Title="Сумки и рюкзаки",  CategoryId=Categories[1].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Головные уборы",  CategoryId=Categories[1].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Кошельки",  CategoryId=Categories[1].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Очки",  CategoryId=Categories[1].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Украшения, часы",  CategoryId=Categories[1].Id},

                new Subcategory() {Id = Guid.NewGuid(), Title="Фубтолки, майки",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Брюки",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Джинсы",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Пиджаки и костюмы",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Рубашки, поло",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Брюки",  CategoryId=Categories[2].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Свитера",  CategoryId=Categories[2].Id},

                new Subcategory() {Id = Guid.NewGuid(), Title="Сумки и рюкзаки",  CategoryId=Categories[3].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Головные уборы",  CategoryId=Categories[3].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Кошельки",  CategoryId=Categories[3].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Очки",  CategoryId=Categories[3].Id},
                new Subcategory() {Id = Guid.NewGuid(), Title="Часы",  CategoryId=Categories[3].Id}
            };
            return dresses;

        }
        private List<Category> Categories;
        private List<Category> GenerateCategories()
        {
            List<Category> category = new List<Category>
            {
                new Category() {  Title = "Одежда", Id = Guid.NewGuid(), CatalogId=Catalogs[0].Id },
                new Category() {  Title = "Аксессуары", Id = Guid.NewGuid(), CatalogId=Catalogs[0].Id },
                new Category() {  Title = "Одежда", Id = Guid.NewGuid(), CatalogId=Catalogs[1].Id },
                new Category() {  Title = "Аксессуары", Id = Guid.NewGuid(), CatalogId=Catalogs[1].Id }
            };
            return category;
        }
        private List<Catalog> Catalogs;
        private List<Catalog> GenerateCatalogs()
        {
            List<Catalog> catalogs = new List<Catalog>
            {
                new Catalog() {Id = Guid.NewGuid(), Title = "Для женщин" },
                new Catalog() {Id = Guid.NewGuid(), Title = "Для мужчин" }
            };
            return catalogs;
        }
        
        private List<IdentityRole> GenerateRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole()
                {
                    Name="Admin"
                },
                new IdentityRole()
                {
                    Name="User"
                },
                new IdentityRole()
                {
                    Name="Manager"
                }
            };

            return roles;
        }
    }
}
