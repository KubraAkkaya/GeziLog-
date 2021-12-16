using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziLog.Models.Classes
{
    public class Comment
    {
        [Key]
        public int ID { get; set; } 
        public string UserName { get; set; }   
        public string Mail { get; set; }   
        public string CommentArea { get; set; }  
        public virtual Blog Blog { get; set; } 
    }
}