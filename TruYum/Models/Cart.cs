using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
    }

}