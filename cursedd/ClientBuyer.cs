using System;
using System.Collections.Generic;

namespace cursedd;

public partial class ClientBuyer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Passport { get; set; }

    public string? Phone { get; set; }

    public int? RieltorId { get; set; }

    public virtual Rieltor? Rieltor { get; set; }
}
