using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class EngineerMachiens
    {
        [Key]      
        public int EngineerMachiensId { get; set; }
        public int MachienId { get; set; }
        public int EngineerId { get; set; }
        public virtual Machine Machiens { get; set; }
        public virtual Engineer Engineers { get; set; }
    }
}