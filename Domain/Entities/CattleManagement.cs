using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CattleManagement
{
    public int Id { get; set; }

    public int? CattleId { get; set; }

    public string? ActionType { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }
}
