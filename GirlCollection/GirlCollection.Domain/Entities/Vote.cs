namespace GirlCollection.Domain.Entities
{
    public class Vote : BaseEntity
    {
        public int Value { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Image Image { get; set; }
    }
}
