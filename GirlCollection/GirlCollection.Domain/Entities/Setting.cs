using System.Collections.Generic;

namespace GirlCollection.Domain.Entities
{
    public class Setting : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserSetting> UserSettings { get; set; }
        public virtual ICollection<SystemSetting> SystemSettings { get; set; }
    }
}
