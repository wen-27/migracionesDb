using System;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Plans.Infrastructure.Entity;
using DerTransporte.Modules.Payments.Infrastructure.Entity;

namespace DerTransporte.Modules.PersonPlans.Infrastructure.Entity;

public class PersonPlansEntity
{
    public Guid id { get; set; }

    public Guid personid { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    public Guid planid { get; set; }
    public PlansEntity Plan { get; set; } = null!;

    public Guid paymentid { get; set; }
    public PaymentsEntity Payment { get; set; } = null!;

    public decimal creditsgranted { get; set; }
    public decimal unitpriceatpurchase { get; set; }
    public DateTime purchasedat { get; set; }
}