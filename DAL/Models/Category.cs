using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }    

    }
}
