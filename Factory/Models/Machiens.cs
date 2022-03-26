using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machien
  {
    public Machien()
        {
            this.JoinEntities = new HashSet<EngineerMachiens>();
        }

    [Key]
    public int MachienId { get; set; }
    public int EngineerId { get; set; }
    public string MachienName { get; set; }
    public virtual ICollection<EngineerMachiens> JoinEntities { get;}
    
  }
}