using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Farm
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Cnpj { get; set; }

    public string? CorporateName { get; set; }

    public string? TradeName { get; set; }

    public string? Size { get; set; }

    public string? Location { get; set; }

    public int? OwnerId { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual Person? Owner { get; set; }
}
