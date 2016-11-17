using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class MainArticleModel : ArticleModel
    {
        [DisplayName("主題")]
        public string Subject { get; set; }
        [DisplayName("流覽次數")]
        public int ReplyCount { get; set; }
        public virtual ICollection<ReplyModel> replyArticles { get; set; }
    }
}