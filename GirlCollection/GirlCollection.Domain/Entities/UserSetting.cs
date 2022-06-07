namespace GirlCollection.Domain.Entities
{
    public class UserSetting : BaseEntity
    {
        public int SettingId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }

        public virtual User User { get; set; }
        public virtual Setting Setting { get; set; }
    }
}
