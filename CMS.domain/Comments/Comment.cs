using CMS.domain.Common;
using CMS.domain.Posts;

namespace CMS.domain.Comments
{
    public class Comment : AuditEntity
    {
        public string Comentario { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
