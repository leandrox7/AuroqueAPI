using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Observation { get; set; }

    public DateOnly? BirthDate { get; set; }

    public bool? IsActive { get; set; }

    public long? LastUpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Farm> Farms { get; set; } = new List<Farm>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
