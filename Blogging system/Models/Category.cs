using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogging_system.Models
{
    public class Category
    {
        public Category()
        {
            Articles = new List<Article>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Enter a real name")]
        [Display(Name = "Category Name")]
        public string Category_Name { get; set; }
        //navigation
        public virtual List<Article> Articles { get; set; }
    }
}