using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : Repository<Category>, ICategoryDal
    {
        private readonly DbContextOptions<Context> _options;

        public EfCategoryDal(DbContextOptions<Context> options) : base(new Context(options))
        {
            _options = options;
        }
    }
}
