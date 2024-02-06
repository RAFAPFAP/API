using CMS.domain.Common;
using CMS.domain.Posts;

namespace CMS.domain.Categories
{
    public class Category : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public Category()
        {
            FechaDeCreacion = DateTime.Now;
        }
    }
}
