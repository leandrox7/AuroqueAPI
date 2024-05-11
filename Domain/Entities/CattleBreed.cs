using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CattleBreed
{
    public int Id { get; set; }

    public string? BreedName { get; set; }

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();
}
