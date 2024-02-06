using CMS.application.Common;

namespace CMS.application.Comments.Models
{
    public class CommentReadDto : BaseDto
    {
        public string Comentario { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
