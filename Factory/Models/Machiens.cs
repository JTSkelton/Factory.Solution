using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
        {
            this.JoinEntities = new HashSet<EngineerMachiens>();
        }

    [Key]
    public int MachienId { get; set; }
    public string MachienName { get; set; }
    public virtual ICollection<EngineerMachiens> JoinEntities { get;}
    
  }
}