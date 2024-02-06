using CMS.domain.Categories;
using CMS.domain.Comments;
using CMS.domain.Common;

namespace CMS.domain.Posts
{
    public class Post : AuditEntity
    {
        public string Nombre { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public string ImageUrl { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Category>? Categories { get; set; }



    }
}
