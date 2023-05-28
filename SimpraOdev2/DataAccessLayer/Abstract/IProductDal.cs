using EntityLayer.Dto.Product;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<ProductResponse> GetAllWithCategory();
        ProductResponse GetByIdWithCategory(int id);
    }
}
