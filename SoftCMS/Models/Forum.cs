using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class Forum : Topic
    {
        public Guid TopicID { get; set; }
        public virtual ICollection<MainArticleModel> MainArticles { get; set; }
        public virtual MainThemes MainThemes { get; set; }
    }
}