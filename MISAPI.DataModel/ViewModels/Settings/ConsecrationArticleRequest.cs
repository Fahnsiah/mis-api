using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ConsecrationArticleRequest
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public long UserLogId { get; set; }
    }
}
