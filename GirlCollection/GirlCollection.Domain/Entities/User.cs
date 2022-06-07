using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GirlCollection.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string ResetPasswordToken { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}
