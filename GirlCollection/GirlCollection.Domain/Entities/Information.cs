namespace GirlCollection.Domain.Entities
{
    public class Information : BaseEntity
    {
        public int ImageId { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public virtual Image Image { get; set; }
    }
}
