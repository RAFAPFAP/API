using CMS.application.Common;

namespace CMS.application.Categories.Models
{
    public class CategoryReadDto : BaseDto
    {
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
}
