using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? FarmId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Observations { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Farm? Farm { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual Person? Person { get; set; }
}
