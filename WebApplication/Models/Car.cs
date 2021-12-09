using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:y}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
    public class CarDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        
    }
}