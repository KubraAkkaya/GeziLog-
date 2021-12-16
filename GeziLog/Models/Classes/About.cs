using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziLog.Models.Classes
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public string PhotoAboutURL { get; set; }
    }
}