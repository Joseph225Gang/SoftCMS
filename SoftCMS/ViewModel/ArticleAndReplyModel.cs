using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftCMS.ViewModel
{
    public class ArticleAndReplyModel
    {
        public MainArticleModel article { get; set; }
        public ReplyModel reply { get; set; }
    }
}