using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }
}
