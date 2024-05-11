using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CattleDestination
{
    public int Id { get; set; }

    public string? DestinationName { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual User? LastUpdatedByNavigation { get; set; }
}
