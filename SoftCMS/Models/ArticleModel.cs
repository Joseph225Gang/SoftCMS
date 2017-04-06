using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class ArticleModel
    {
        public Guid ID { get; set; }
        [Required]
        [DisplayName("內容")]
        [DataType(DataType.MultilineText)]
        public string ContentText { get; set; }
        [DisplayName("發佈日期")]
        public DateTime PublichDate { get; set; }
        [DisplayName("建立者")]
        public string CreateUser { get; set; }
    }
}