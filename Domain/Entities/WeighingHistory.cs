using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WeighingHistory
{
    public int Id { get; set; }

    public int? CattleId { get; set; }

    public decimal? Weight { get; set; }

    public DateOnly? WeighingDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Cattle? Cattle { get; set; }
}
