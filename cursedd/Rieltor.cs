using System;
using System.Collections.Generic;

namespace cursedd;

public partial class Rieltor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Percent { get; set; }

    public string? Phone { get; set; }

    public int EstateofficeId { get; set; }

    public virtual ICollection<ClientBuyer> ClientBuyers { get; } = new List<ClientBuyer>();

    public virtual ICollection<ClientSeller> ClientSellers { get; } = new List<ClientSeller>();

    public virtual Estateoffice Estateoffice { get; set; } = null!;
}
