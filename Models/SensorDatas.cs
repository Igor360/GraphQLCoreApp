using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3GraphQL.Models
{
    [Table(name: "sensor_data")]
    public class SensorDatas : Model
    {
        [Column("name")]
        public String Name { get; set; }

        [Column("value")]
        public String Value { get; set; }

        [Column("code")]
        public String Code { get; set; }

        public virtual ICollection<GroupSensors> GroupSensorses { get; set; }
    }
}