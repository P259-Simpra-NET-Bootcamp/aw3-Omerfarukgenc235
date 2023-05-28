using Azure;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Dto.Product;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : Repository<Product>, IProductDal
    {
        private readonly DbContextOptions<Context> _options;

        public EfProductDal(DbContextOptions<Context> options) : base(new Context(options))
        {
            _options = options;
        }

        public List<ProductResponse> GetAllWithCategory()
        {
            using (var context = new Context(_options))
            {
                return (from cs in context.Products
                             join category in context.Categories on cs.CategoryId equals category.Id
                             orderby cs.Id ascending
                             select new ProductResponse
                             {
                                 Id = cs.Id,
                                 Name = cs.Name,
                                 Category = category,
                                 CategoryId = cs.CategoryId,
                                 Tag = cs.Tag,
                                 Url = cs.Url
                             }).ToList();
            }
        }

        public ProductResponse GetByIdWithCategory(int id)
        {
            using (var context = new Context(_options))
            {
                return (from cs in context.Products
                        join category in context.Categories on cs.CategoryId equals category.Id
                        where cs.Id == id
                        orderby cs.Id ascending
                        select new ProductResponse
                        {
                            Id = cs.Id,
                            Name = cs.Name,
                            Category = category,
                            CategoryId = cs.CategoryId,
                            Tag = cs.Tag,
                            Url = cs.Url
                        }).FirstOrDefault();
            }
        }
    }
}
