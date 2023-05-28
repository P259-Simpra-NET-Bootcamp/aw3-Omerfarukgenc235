using Base;
using EntityLayer.Dto.Categories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        ApiResponse Add(CategoryRequest category);
        Category GetByID(int id);
        bool Delete(int id);
        ApiResponse Update(CategoryRequest category);
    }
}
