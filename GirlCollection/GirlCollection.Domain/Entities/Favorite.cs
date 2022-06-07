namespace GirlCollection.Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }

        public virtual User User { get; set; }
        public virtual Image Image { get; set; }
    }
}