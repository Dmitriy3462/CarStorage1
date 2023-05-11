using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public DateTime Year { get; set; }
        public string Image { get; set; }
        public IEnumerable<Category> Categorys { get; set; }
    }
}
