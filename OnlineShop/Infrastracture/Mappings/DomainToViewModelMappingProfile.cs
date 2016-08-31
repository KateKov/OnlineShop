using AutoMapper;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.DAL.Entities;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastracture.Mappings
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductsTableViewModel>()
                 .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                 .ForMember(vm => vm.Amount, map => map.MapFrom(m => m.Amount))
                 .ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description))
                 .ForMember(vm => vm.Discount, map => map.MapFrom(m => m.Discount))
                 .ForMember(vm => vm.Materials, map => map.MapFrom(m => m.Materials))
                 .ForMember(vm => vm.Popularity, map => map.MapFrom(m => m.Popularity))
                 .ForMember(vm => vm.Price, map => map.MapFrom(m => m.Price))
                 .ForMember(vm => vm.Title, map => map.MapFrom(m => m.Title))
                 .ForMember(vm => vm.Subcategory, map => map.MapFrom(m => m.Subcategory.Title))
                 .ForMember(vm => vm.SubcategoryId, map => map.MapFrom(m => m.SubcategoryId))
                 .ForMember(vm => vm.Category, map => map.MapFrom(m => m.Subcategory.Category.Title))
                 .ForMember(vm => vm.CategoryId, map => map.MapFrom(m => m.Subcategory.Category.Id))
                 .ForMember(vm => vm.Catalog, map => map.MapFrom(m => m.Subcategory.Category.Catalog.Title))
                 .ForMember(vm => vm.CatalogId, map => map.MapFrom(m => m.Subcategory.Category.Catalog.Id))
                 .ForMember(vm => vm.Color, map => map.MapFrom(m => m.Color.Name))
                 .ForMember(vm => vm.CollectionId, map => map.MapFrom(m => m.Collection.Id))
                 .ForMember(vm => vm.Collection, map => map.MapFrom(m => m.Collection.Name))
                .ForMember(vm => vm.Sizes, map => map.MapFrom(m => String.Join(",", m.Sizes.Select(x => x.Number).ToArray())))
                .ForMember(vm => vm.BrandId, map => map.MapFrom(m => m.Collection.BrandId))
                .ForMember(vm => vm.Brand, map => map.MapFrom(m => m.Collection.Brand.Name));
            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.Amount, map => map.MapFrom(m => m.Amount))
                .ForMember(vm => vm.DateOfAddition, map => map.MapFrom(m => m.DateOfAddition))
                .ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description))
                .ForMember(vm => vm.Discount, map => map.MapFrom(m => m.Discount))
                .ForMember(vm => vm.Materials, map => map.MapFrom(m => m.Materials))
                .ForMember(vm => vm.Popularity, map => map.MapFrom(m => m.Popularity))
                .ForMember(vm => vm.Price, map => map.MapFrom(m => m.Price))
                .ForMember(vm => vm.Title, map => map.MapFrom(m => m.Title))
                .ForMember(vm => vm.Subcategory, map => map.MapFrom(m => m.Subcategory.Title))
                .ForMember(vm => vm.SubcategoryId, map => map.MapFrom(m => m.SubcategoryId))
                .ForMember(vm=>vm.Category, map=>map.MapFrom(m=>m.Subcategory.Category.Title))
                .ForMember(vm => vm.CategoryId, map => map.MapFrom(m => m.Subcategory.Category.Id))
                .ForMember(vm => vm.Catalog, map => map.MapFrom(m => m.Subcategory.Category.Catalog.Title))
                .ForMember(vm => vm.CatalogId, map => map.MapFrom(m => m.Subcategory.Category.Catalog.Id))
                .ForMember(vm=> vm.Color, map=> map.MapFrom(m=>m.Color.Name))
                .ForMember(vm => vm.Images, map => map.MapFrom(m => m.Images.Count == 0 ? new List<string>() { "unknown.jpg" } : m.Images.ToList().Select(s => s.ImagePath)))
                .ForMember(vm => vm.ColorImage, map => map.MapFrom(m => string.IsNullOrEmpty(m.Color.CssColor) == true ? "unknown.jpg" : m.Color.CssColor))
                .ForMember(vm => vm.CollectionId, map => map.MapFrom(m => m.Collection.Id))
                .ForMember(vm => vm.Collection, map => map.MapFrom(m => m.Collection.Name))
                .ForMember(vm=>vm.Sizes, map=>map.MapFrom(m=>m.Sizes.ToList().Select(s=>s.Number)))
                .ForMember(vm => vm.BrandId, map => map.MapFrom(m=>m.Collection.BrandId))
                .ForMember(vm => vm.Brand, map => map.MapFrom(m => m.Collection.Brand.Name));

        }
    }
}