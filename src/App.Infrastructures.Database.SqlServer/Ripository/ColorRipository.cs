﻿using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Ripository
{
    public class ColorRipository
    {

        public  AppDbContext _eshop = new();
        public  void Create(Color color)
        {
            _eshop.Colors.Add(color);
            _eshop.SaveChanges();
        }
        public  void Edit(Color model)
        {
            var color = _eshop.Colors.First(p => p.Id == model.Id);
            color.Name = model.Name;
            color.Code = model.Code;
            color.CreationDate = model.CreationDate;
            _eshop.SaveChanges();
        }
        public  void Delete(int id)
        {
            var color = _eshop.Colors.First(p => p.Id == id);
            _eshop.Colors.Remove(color);
            _eshop.SaveChanges();
        }


        public  List GetAll()
        {
            return _eshop.Colors.Include(b => b.ProductColors).ToList();
        }
        public  Color GetById(int id)
        {
            return _eshop.Colors.First(p => p.Id == id);
        }
    }
}