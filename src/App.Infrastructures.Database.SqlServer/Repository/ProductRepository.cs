﻿using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;

public class ProductRepository
{
    public static AppDbContext _eShop = new();
    public static void Create(Product product )
    {
        _eShop.Products.Add( product );
        _eShop.SaveChanges();
    }
    public static void Edit(Product model)
    {
        var product = _eShop.Products.FirstOrDefault(p => p.Id == model.Id);
        product.Name = model.Name;
        product.Description = model.Description;
        product.Weight=model.Weight;
        product.Price = model.Price;
        product.Count = model.Count;
        product.IsActive = model.IsActive;
        product.CreationDate = model.CreationDate;
        _eShop.SaveChanges();

    }

    public static void Delete(int id)
    {
        var product = _eShop.Products.FirstOrDefault(p => p.Id == id);
        _eShop.Products.Remove(product);
        _eShop.SaveChanges();

    }

    public static List<Product> GetAll()
    {
        return _eShop.Products.ToList();
    }
    public static Product GetById(int id)
    {
        return _eShop.Products.First(p => p.Id == id);
    }
}