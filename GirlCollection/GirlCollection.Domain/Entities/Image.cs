using System.Collections.Generic;

namespace GirlCollection.Domain.Entities
{
    public class Image : BaseEntity
    {
        public int Type { get; set; }
        public string Original { get; set; }
        public string Thumb { get; set; }
        public int Rating { get; set; }
        public int CreatedBy { get; set; }

        public virtual User Creator { get; set; }
        public virtual ImageType ImageType { get; set; }
        public virtual Information Information { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
