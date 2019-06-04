using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogging_system.Models
{
    public class Article
    {

        public Article()
        {
            Comments = new List<Comment>();
        }
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title should be between 3-50 characters")]
        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Article should be between 5-10000 characters")]
        [Display(Name = "Article Body")]
        public string ArticleBody { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime Publish_date { get; set; }

        [Required(ErrorMessage = "*")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        //Navigation
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}