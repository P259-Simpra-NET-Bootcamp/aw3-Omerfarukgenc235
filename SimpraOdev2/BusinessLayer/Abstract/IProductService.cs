using Base;
using EntityLayer.Dto.Product;
using EntityLayer.Models;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<ProductResponse> GetAllWithCategory();
        ProductResponse GetByIdWithCategory(int id);
        ApiResponse Add(ProductRequest product);
        Product GetByID(int id);
        bool Delete(int id);
        ApiResponse Update(ProductRequest product);
    }
}
