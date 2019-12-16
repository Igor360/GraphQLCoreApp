using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3GraphQL.Models
{
    [Table("sensors_groups")]
    public class SensorsGroups : Model
    {
        [Column("name")]
        public String Name { get; set; }

        public Users User { get; set; }
        
        
        [Column("user_id")]
        public int UserId { get; set; }
        
        public virtual ICollection<GroupSensors> SensorDatases { get; set; }

    }
}