using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<EngineerMachiens>();
    }
    [Key]
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public virtual ICollection<EngineerMachiens> JoinEntities { get; set; }
  }
}