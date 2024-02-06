using CMS.application.Common;

namespace CMS.application.Posts.Models
{
    public class PostReadDto : BaseDto
    {
        public string Nombre { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public string ImageUrl { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public ICollection<int>? CategoryIds { get; set; }
    }
}
