using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? PersonId { get; set; }

    public string? Login { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime LastLogin { get; set; }

    public int? LoginFailures { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AnimalChip> AnimalChipCreatedByNavigations { get; set; } = new List<AnimalChip>();

    public virtual ICollection<AnimalChip> AnimalChipLastUpdatedByNavigations { get; set; } = new List<AnimalChip>();

    public virtual ICollection<CattleDestination> CattleDestinations { get; set; } = new List<CattleDestination>();

    public virtual ICollection<CattleManagement> CattleManagementCreatedByNavigations { get; set; } = new List<CattleManagement>();

    public virtual ICollection<CattleManagement> CattleManagementLastUpdatedByNavigations { get; set; } = new List<CattleManagement>();

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Farm> Farms { get; set; } = new List<Farm>();

    public virtual Person? Person { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
