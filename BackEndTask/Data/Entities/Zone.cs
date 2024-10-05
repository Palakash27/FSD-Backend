using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndTask.Data.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCord { get; set; }
    }
}
