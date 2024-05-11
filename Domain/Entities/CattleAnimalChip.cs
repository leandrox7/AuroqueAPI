using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CattleAnimalChip
{
    public int Id { get; set; }

    public int? CattleId { get; set; }

    public int? ChipId { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual AnimalChip? Chip { get; set; }
}
