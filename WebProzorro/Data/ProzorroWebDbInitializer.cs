﻿using Microsoft.EntityFrameworkCore;
using Prozorro.ClientExtentions;
using Prozorro.Models;
using Prozorro.Models.Enums;
namespace WebProzorro.Data
{
    public class ProzorroWebDbInitializer
    {
        private WebProzorroContext _context;
        private ClientExecutor _executor;

        public ProzorroWebDbInitializer(WebProzorroContext context = null, ClientExecutor executor = null)
        {
            _context = context;//?? new WebProzorroContext();
            _executor = executor ?? new ClientExecutor(Mode.Dev, "https://catalog-api-staging.prozorro.gov.ua");
        }

        public async Task SeedDataAsync(string url = "")
        {
            if (!string.IsNullOrEmpty(url)) _executor = new ClientExecutor(baseUrl: url);
            if (!_context.OfferDTOs.Any())
            {
                var items = await _executor.LoadItems<OfferDTO>("offers");
                await _context.OfferDTOs.AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            if (!_context.CategoryDTOs.Any())
            {
                var items = await _executor.LoadItems<CategoryDTO>("categories");
                _context.CategoryDTOs.UpsertRange(items); await _context.SaveChangesAsync();
            }
            if (!_context.ProductDTOs.Any())
            {
                var items = await _executor.LoadItems<ProductDTO>("products");
                _context.ProductDTOs.UpsertRange(items); await _context.SaveChangesAsync();
            }
            if (!_context.ProfileDTOs.Any())
            {
                var items = await _executor.LoadItems<ProfileDTO>("profiles");
                _context.ProfileDTOs.UpsertRange(items); await _context.SaveChangesAsync();
            }
            if (!_context.VendorDTOs.Any())
            {
                var items = await _executor.LoadItems<VendorDTO>("vendors");
                _context.VendorDTOs.UpsertRange(items); await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
        //public async Task Seed(ProzorroContext context)
        //{
        //    ClientExecutor Client = new(Mode.Dev, "https://catalog-api-staging.prozorro.gov.ua");
        //    Console.OutputEncoding = Encoding.UTF8;

        //    if (!context.Offers.Any())
        //    {
        //        var offers = await ClientExecutor.LoadItems<OfferDTO>(Client, "offers");
        //        context.Offers.AddRange(offers);
        //        await context.SaveChangesAsync();
        //    }
        //    if (!context.Categories.Any())
        //    {
        //        var categories = await ClientExecutor.LoadItems<CategoryDTO>(Client, "categories");
        //        context.Categories.AddRange(categories);
        //        await context.SaveChangesAsync();
        //    }
        //    if (!context.Products.Any())
        //    {
        //        var products = await ClientExecutor.LoadItems<ProductDTO>(Client, "products");
        //        context.Products.AddRange(products);
        //        await context.SaveChangesAsync();
        //    }
        //    if (!context.Profiles.Any())
        //    {
        //        var profiles = await ClientExecutor.LoadItems<ProfileDTO>(Client, "profiles");
        //        context.Profiles.AddRange(profiles);
        //        await context.SaveChangesAsync();
        //    }
        //    if (!context.Vendors.Any())
        //    {
        //        var vendors = await ClientExecutor.LoadItems<VendorDTO>(Client, "vendors");
        //        context.Vendors.AddRange(vendors);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }

}
