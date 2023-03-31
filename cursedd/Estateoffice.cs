using System;
using System.Collections.Generic;

namespace cursedd;

public partial class Estateoffice
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Rieltor> Rieltors { get; } = new List<Rieltor>();
}
