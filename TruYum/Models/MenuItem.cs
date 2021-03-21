using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price field is Required")]
        public double Price { get; set; }
        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}