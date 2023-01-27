using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class ConsecrationArticleRequest
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public long UserLogId { get; set; }
    }
}
