using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class Topic
    {
        public Guid ID { get; set; }
        public string ContentText { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayName("發佈日期")]
        public DateTime PublichDate { get; set; }
        [DisplayName("建立者")]
        public string CreateUser { get; set; }
    }
}