using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlCollection.Domain.Entities
{
    public class SystemSetting : BaseEntity
    {
        public int SettingId { get; set; }
        public int Value { get; set; }

        public virtual Setting Setting { get; set; }
    }
}
