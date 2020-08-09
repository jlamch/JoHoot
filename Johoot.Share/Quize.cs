using System.Collections.Generic;

namespace Johoot.Data
{
  public class Quize
  {
    public virtual long Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual List<Question> Questions { get; set; }
  }
}