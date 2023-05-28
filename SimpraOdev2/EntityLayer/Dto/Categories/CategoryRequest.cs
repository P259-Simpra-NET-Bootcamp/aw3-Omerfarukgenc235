using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.Categories
{
    public class CategoryRequest : BaseRequest
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
