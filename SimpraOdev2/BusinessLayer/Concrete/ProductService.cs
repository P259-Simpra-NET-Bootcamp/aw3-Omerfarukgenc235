using AutoMapper;
using Base;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto.Product;
using EntityLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductService(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public virtual ApiResponse Add(ProductRequest product)
        {
            try
            {
                var anyName = _productDal.Find(x => x.Name == product.Name);

                if (anyName != null)
                {
                    return new ApiResponse("Böyle bir kategori adı bulunmaktadır.");
                }

                var response = _mapper.Map<Product>(product);
                int status = _productDal.Insert(response);
                return new ApiResponse();
            }
            catch
            {
                return new ApiResponse("Veri eklenirken bir hata meydana gelmiştir.");
            }
        }

        public bool Delete(int id)
        {
            var item = GetByID(id);
            int result = _productDal.Delete(item);
            if (result > 0) return true;
            else return false;
        }

        public List<ProductResponse> GetAllWithCategory()
        {
            return _productDal.GetAllWithCategory();
        }

        public Product GetByID(int id)
        {
            return _productDal.Find(x => x.Id == id);
        }

        public ProductResponse GetByIdWithCategory(int id)
        {
            return _productDal.GetByIdWithCategory(id);
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public virtual ApiResponse Update(ProductRequest product)
        {
            try
            {
                var anyName = _productDal.Find(x => x.Name == product.Name && x.Id != product.Id);

                if (anyName != null)
                {
                    return new ApiResponse("Böyle bir ürün adı bulunmaktadır.");
                }

                var response = _mapper.Map<Product>(product);
                int status = _productDal.Update(response);
                return new ApiResponse();
            }
            catch
            {
                return new ApiResponse("Veri güncellenirken bir hata meydana gelmiştir.");
            }
        }
    }
}
