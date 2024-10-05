using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndTask.Data.Entities
{
    public class ClickZone
    {
        public int Id { get; set; }
        public double XCord { get; set; }
        public double YCord { get; set; }
    }
}
