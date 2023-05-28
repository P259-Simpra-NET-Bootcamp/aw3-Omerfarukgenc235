using AutoMapper;
using Azure;
using Base;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto.Categories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _categoyDal;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryDal categoyDal, IMapper mapper)
        {
            _categoyDal = categoyDal;
            _mapper = mapper;
        }
        public virtual ApiResponse Add(CategoryRequest category)
        {
            try
            {
                var anyName = _categoyDal.Find(x => x.Name == category.Name);

                if(anyName != null)
                {
                    return new ApiResponse("Böyle bir kategori adı bulunmaktadır.");
                }

                var response = _mapper.Map<Category>(category);
                int status = _categoyDal.Insert(response);
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
            int result = _categoyDal.Delete(item);
            if (result > 0) return true;
            else return false;
        }

        public Category GetByID(int id)
        {
            return _categoyDal.Find(x => x.Id == id);
        }

        public List<Category> GetList()
        {
            return _categoyDal.List();
        }

        public virtual ApiResponse Update(CategoryRequest category)
        {
            try
            {
                var anyName = _categoyDal.Find(x => x.Name == category.Name && x.Id != category.Id);

                if (anyName != null)
                {
                    return new ApiResponse("Böyle bir kategori adı bulunmaktadır.");
                }

                var response = _mapper.Map<Category>(category);
                int status = _categoyDal.Update(response);
                return new ApiResponse();
            }
            catch
            {
                return new ApiResponse("Veri güncellenirken bir hata meydana gelmiştir.");
            }
        }
    }
}
