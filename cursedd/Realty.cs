using System;
using System.Collections.Generic;

namespace cursedd;

public partial class Realty
{
    public int Id { get; set; }

    public string? RealtyType { get; set; }

    public string? Address { get; set; }

    public string? Rooms { get; set; }

    public string? Price { get; set; }

    public int? ClientSellerId { get; set; }

    public virtual ClientSeller? ClientSeller { get; set; }
}
