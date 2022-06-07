using System.Collections.Generic;

namespace GirlCollection.Domain.Entities
{
    public class ImageType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
