using System;
using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Modules.TransactionTypes.Infrastructure.Entity;

namespace DerTransporte.Modules.CreditTransactions.Infrastructure.Entity;

public class CreditTransactionsEntity
{
    public Guid id { get; set; }

    public Guid walletid { get; set; }
    public CreditWalletEntity Wallet { get; set; } = null!;

    public Guid transactiontypeid { get; set; }
    public TransactionTypesEntity TransactionType { get; set; } = null!;

    public decimal amount { get; set; }
    public decimal balanceafter { get; set; }
    public Guid referenceid { get; set; }
    public string description { get; set; } = string.Empty;
    public DateTime createdat { get; set; }
}