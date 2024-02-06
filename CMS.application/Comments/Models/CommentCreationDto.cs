namespace CMS.application.Comments.Models
{
    public class CommentCreationDto
    {
        public string Comentario { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
