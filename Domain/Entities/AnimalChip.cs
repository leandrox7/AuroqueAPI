using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AnimalChip
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? SerialNumber { get; set; }

    public string? Manufacturer { get; set; }

    public DateOnly? AcquisitionDate { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CattleAnimalChip> CattleAnimalChips { get; set; } = new List<CattleAnimalChip>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }
}
