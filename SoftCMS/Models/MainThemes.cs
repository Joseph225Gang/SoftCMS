using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class MainThemes : Topic
    {
        public virtual ICollection<Forum> Topics { get; set; }
    }
}