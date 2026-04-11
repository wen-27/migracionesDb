using System;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionType.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionStatus.Infrastructure.Entity;
using DerTransporte.Modules.Payments.Infrastructure.Entity;

namespace DerTransporte.Modules.Subscriptions.Infrastructure.Entity;

public class SubscriptionsEntity
{
    public Guid id { get; set; }

    public Guid personid { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    public Guid subscriptiontypeid { get; set; }
    public SubscriptionTypeEntity SubscriptionType { get; set; } = null!;

    public DateTime startdate { get; set; }
    public DateTime enddate { get; set; }

    public Guid statusid { get; set; }
    public SubscriptionStatusEntity Status { get; set; } = null!;

    public bool autorenew { get; set; }

    public Guid paymentid { get; set; }
    public PaymentsEntity Payment { get; set; } = null!;
}