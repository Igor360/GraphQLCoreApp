
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3GraphQL.Models
{
    [Table("group_sensors")]
    public class GroupSensors : Model
    {
        [Column("sensor_id")]
        public int SensorId { get; set; }
        
        public SensorDatas Sensor { get; set; }

        [Column("group_id")]
        public int GroupId { get; set; }
        
        public SensorsGroups SensorsGroups{ get; set; }
    }
}