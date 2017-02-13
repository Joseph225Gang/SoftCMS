using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class ReplyModel : ArticleModel
    {
        public Guid ArticleID { get; set; }
        [DisplayName("主內容建立者")]
        public string ArticelMaker { get; set; }
        public virtual MainArticleModel mainArticle { get; set; }
    }
}