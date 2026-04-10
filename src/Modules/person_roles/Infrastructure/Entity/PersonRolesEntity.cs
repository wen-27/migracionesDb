using System;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Roles.Infrastructure.Entity;

namespace DerTransporte.Modules.PersonRoles.Infrastructure.Entity;

public class PersonRolesEntity
{
    public Guid Id { get; set; } 
    // FK → roles
    public Guid? RoleId { get; set; }
    public RolesEntity? Role { get; set; }

    // FK nullable → persons
    public Guid? PersonId { get; set; }
    public PersonsEntity? Person { get; set; }
}
