using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziLog.Models.Classes
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public string PhotoBlogURL { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}