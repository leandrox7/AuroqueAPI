using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cattle
{
    public int Id { get; set; }

    public int? FarmId { get; set; }

    public int? BreedId { get; set; }

    public string? Name { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? FatherId { get; set; }

    public int? MotherId { get; set; }

    public string? Gender { get; set; }

    public bool? Pregnant { get; set; }

    public string? CoatColor { get; set; }

    public string? SisbovId { get; set; }

    public string? PropertyId { get; set; }

    public int? DestinationId { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CattleBreed? Breed { get; set; }

    public virtual ICollection<CattleAnimalChip> CattleAnimalChips { get; set; } = new List<CattleAnimalChip>();

    public virtual ICollection<CattleManagement> CattleManagements { get; set; } = new List<CattleManagement>();

    public virtual CattleDestination? Destination { get; set; }

    public virtual Farm? Farm { get; set; }

    public virtual Cattle? Father { get; set; }

    public virtual ICollection<Cattle> InverseFather { get; set; } = new List<Cattle>();

    public virtual ICollection<Cattle> InverseMother { get; set; } = new List<Cattle>();

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual Cattle? Mother { get; set; }

    public virtual ICollection<WeighingHistory> WeighingHistories { get; set; } = new List<WeighingHistory>();
}
