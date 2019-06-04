using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogging_system.Models
{
    public class Comment
    {

        [Key]
        [ForeignKey("Member")]
        [Column(Order = 1)]
        public string MemberId { get; set; }
        [Key]
        [ForeignKey("Article")]
        [Column(Order = 2)]
        public int ArticleId { get; set; }
       
        [Display(Name = "Comment Date")]
        [Key]
        [Column(Order = 3)]
        public DateTime CommentDate { get; set; }
      
        //navigation
        public virtual ApplicationUser Member { get; set; }
        public virtual Article Article { get; set; }
    }
}