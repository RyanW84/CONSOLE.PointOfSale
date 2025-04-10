﻿using Microsoft.EntityFrameworkCore;
using PointOfSale.EntityFramework.RyanW84.Models;
using PointOfSale.RyanW84.RyanW84;

namespace PointOfSale.EntityFramework.RyanW84.Controllers;

internal class ProductController
    {
    internal static void AddProduct(Product product)
        {

        using var db = new ProductsContext();
        db.Add(product);
        db.SaveChanges();
        }

    internal static void DeleteProduct(Product product)
        {
        using var db = new ProductsContext();
        db.Remove(product);
        db.SaveChanges();
        }
    internal static void UpdateProduct(Product product)
        {
        using var db = new ProductsContext();

        db.Update(product);

        db.SaveChanges();
        }


    internal static Product GetProductById(int id)
        {
        using var db = new ProductsContext();
        var product = db.Products
        .Include(x => x.Category)
        .SingleOrDefault(x => x.ProductId == id);

        return product;
        }

    internal static List<Product> GetProducts()
        {
        using var db = new ProductsContext();

        var products = db.Products
        .Include(x => x.Category)
        .ToList();

        return products;
        }







    }

