using System;
using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Modules.PaymentProviders.Infrastructure.Entity;
using DerTransporte.Modules.PaymentStatuses.Infrastructure.Entity;

namespace DerTransporte.Modules.Payments.Infrastructure.Entity;

public class PaymentsEntity
{
    public Guid id { get; set; }

    public Guid walletid { get; set; }
    public CreditWalletEntity Wallet { get; set; } = null!;

    public Guid paymentproviderid { get; set; }
    public PaymentProvidersEntity PaymentProvider { get; set; } = null!;

    public Guid statusid { get; set; }
    public PaymentStatusesEntity Status { get; set; } = null!;

    public string externalreference { get; set; } = string.Empty;
    public decimal amountmoney { get; set; }
    public DateTime createdat { get; set; }
}