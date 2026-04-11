using DerTransporte.Modules.AssignmentRole.Infrastructure.Entity;
using DerTransporte.Modules.AuditLog.Infrastructure.Entity;
using DerTransporte.Modules.AuthCredentials.Infrastructure.Entity;
using DerTransporte.Modules.AuthSessions.Infrastructure.Entity;
using DerTransporte.Modules.Bids.Infrastructure.Entity;
using DerTransporte.Modules.ChatMessages.Infrastructure.Entity;
using DerTransporte.Modules.ChatParticipants.Infrastructure.Entity;
using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Modules.CityPricingRules.Infrastructure.Entity;
using DerTransporte.Modules.CompaniesStatus.Infrastructure.Entity;
using DerTransporte.Modules.CompanyDocuments.Infrastructure.Entity;
using DerTransporte.Modules.CompanyVehicles.Infrastructure.Entity;
using DerTransporte.Modules.Countries.Infrastructure.Entity;
using DerTransporte.Modules.CreditTransactions.Infrastructure.Entity;
using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Modules.Customers.Infrastructure.Entity;
using DerTransporte.Modules.Disputes.Infrastructure.Entity;
using DerTransporte.Modules.DisputesStatus.Infrastructure.Entity;
using DerTransporte.Modules.DocumentCategory.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsCustomers.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsDrivers.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsVehicles.Infrastructure.Entity;
using DerTransporte.Modules.Drivers.Infrastructure.Entity;
using DerTransporte.Modules.DriversVehicles.Infrastructure.Entity;
using DerTransporte.Modules.LoadDetails.Infrastructure.Entity;
using DerTransporte.Modules.LoadImages.Infrastructure.Entity;
using DerTransporte.Modules.LoadStatusHistory.Infrastructure.Entity;
using DerTransporte.Modules.Loads.Infrastructure.Entity;
using DerTransporte.Modules.MessageType.Infrastructure.Entity;
using DerTransporte.Modules.NotificationType.Infrastructure.Entity;
using DerTransporte.Modules.Notifications.Infrastructure.Entity;
using DerTransporte.Modules.PaymentProviders.Infrastructure.Entity;
using DerTransporte.Modules.PaymentStatuses.Infrastructure.Entity;
using DerTransporte.Modules.Payments.Infrastructure.Entity;
using DerTransporte.Modules.PersonPlans.Infrastructure.Entity;
using DerTransporte.Modules.PersonRoles.Infrastructure.Entity;
using DerTransporte.Modules.PersonStatus.Infrastructure.Entity;
using DerTransporte.Modules.PersonTransport.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Plans.Infrastructure.Entity;
using DerTransporte.Modules.PriceHistory.Infrastructure.Entity;
using DerTransporte.Modules.Ratings.Infrastructure.Entity;
using DerTransporte.Modules.ReasonDisputes.Infrastructure.Entity;
using DerTransporte.Modules.RelationType.Infrastructure.Entity;
using DerTransporte.Modules.ReturnLoadSuggestions.Infrastructure.Entity;
using DerTransporte.Modules.Roles.Infrastructure.Entity;
using DerTransporte.Modules.Stateorregions.Infrastructure.Entity;
using DerTransporte.Modules.StatusBids.Infrastructure.Entity;
using DerTransporte.Modules.StatusChat.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionStatus.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionType.Infrastructure.Entity;
using DerTransporte.Modules.Subscriptions.Infrastructure.Entity;
using DerTransporte.Modules.TransactionTypes.Infrastructure.Entity;
using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;
using DerTransporte.Modules.TravelScale.Infrastructure.Entity;
using DerTransporte.Modules.TripAssignments.Infrastructure.Entity;
using DerTransporte.Modules.TripStatusHistory.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Modules.TypeLoad.Infrastructure.Entity;
using DerTransporte.Modules.TypeVehicles.Infrastructure.Entity;
using DerTransporte.Modules.Vehicles.Infrastructure.Entity;
using DerTransporte.Modules.VehiculesStatus.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;



namespace DerTransporte.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<AssignmentRoleEntity> AssignmentRole { get; set; }
    /*
    public DbSet<AuditLogEntity> AuditLog { get; set; }
    */
    public DbSet<AuthCredentialsEntity> AuthCredentials { get; set; }
    
    public DbSet<AuthSessionsEntity> AuthSessions { get; set; }
    
    public DbSet<BidsEntity> Bids { get; set; }
    /*
    public DbSet<ChatMessagesEntity> ChatMessages { get; set; }
    public DbSet<ChatParticipantsEntity> ChatParticipants { get; set; }
    public DbSet<ChatRoomsEntity> ChatRooms { get; set; }*/
    public DbSet<CitiesormunicipalitiesEntity> Citiesormunicipalities { get; set; }
   /* public DbSet<CityPricingRulesEntity> CityPricingRules { get; set; }
    */
    public DbSet<CompaniesStatusEntity> CompaniesStatus { get; set; }
    public DbSet<CompanyDocumentsEntity> CompanyDocuments { get; set; }

    public DbSet<CompanyVehiclesEntity> CompanyVehicles { get; set; }
    
    public DbSet<CountriesEntity> Countries { get; set; }
    /*
    public DbSet<CreditTransactionsEntity> CreditTransactions { get; set; }
    */
    public DbSet<CreditWalletEntity> CreditWallet { get; set; }
    
    public DbSet<CustomersEntity> Customers { get; set; }
    /*
    public DbSet<DisputesEntity> Disputes { get; set; }
    */
    public DbSet<DisputesStatusEntity> DisputesStatus { get; set; }
    
    public DbSet<DocumentCategoryEntity> DocumentCategory { get; set; }
    
    public DbSet<DocumentsCustomersEntity> DocumentsCustomers { get; set; }
    
    public DbSet<DocumentsDriversEntity> DocumentsDrivers { get; set; }
    
    public DbSet<DocumentsStatusEntity> DocumentsStatus { get; set; }
    
    public DbSet<DocumentsVehiclesEntity> DocumentsVehicles { get; set; }
    
    public DbSet<DriversEntity> Drivers { get; set; }
    /*
    public DbSet<DriversVehiclesEntity> DriversVehicles { get; set; }
*/
    public DbSet<LoadDetailsEntity> LoadDetails { get; set; }
    public DbSet<LoadImagesEntity> LoadImages { get; set; }
    public DbSet<LoadStatusHistoryEntity> LoadStatusHistories { get; set; }
    
    public DbSet<LoadsEntity> Loads { get; set; }
    
    public DbSet<MessageTypeEntity> MessageType { get; set; }
    
    public DbSet<NotificationTypeEntity> NotificationType { get; set; }
    /*
    public DbSet<NotificationsEntity> Notifications { get; set; }
    */
    public DbSet<PaymentProvidersEntity> PaymentProviders { get; set; }
    
    public DbSet<PaymentStatusesEntity> PaymentStatuses { get; set; }
    /*
    public DbSet<PaymentsEntity> Payments { get; set; }
    public DbSet<PersonPlansEntity> PersonPlans { get; set; }
    */
    public DbSet<PersonRolesEntity> PersonRoles { get; set; }

    public DbSet<PersonStatusEntity> PersonStatus { get; set; }
    
    public DbSet<PersonTransportEntity> PersonTransport { get; set; }
    public DbSet<PersonsEntity> Persons { get; set; }
    public DbSet<PlansEntity> Plans { get; set; }
    /*
    public DbSet<PriceHistoryEntity> PriceHistory { get; set; }
    public DbSet<RatingsEntity> Ratings { get; set; }
    */
    public DbSet<ReasonDisputesEntity> ReasonDisputes { get; set; }
    
    public DbSet<RelationTypeEntity> RelationType { get; set; }
    /*
    public DbSet<ReturnLoadSuggestionsEntity> ReturnLoadSuggestions { get; set; }
    */
    public DbSet<RolesEntity> Roles { get; set; }
    public DbSet<StateorregionsEntity> Stateorregions { get; set; }
    public DbSet<StatusBidsEntity> StatusBids { get; set; }
    
    public DbSet<StatusChatEntity> StatusChat { get; set; }
    
    public DbSet<SubscriptionStatusEntity> SubscriptionStatus { get; set; }
    
    public DbSet<SubscriptionTypeEntity> SubscriptionType { get; set; }
    /*
    public DbSet<SubscriptionsEntity> Subscriptions { get; set; }
    */
    public DbSet<TransactionTypesEntity> TransactionTypes { get; set; }
    
    public DbSet<TransportCompaniesEntity> TransportCompanies { get; set; }
    /*
    public DbSet<TravelScaleEntity> TravelScale { get; set; }
    public DbSet<TripAssignmentsEntity> TripAssignments { get; set; }
    public DbSet<TripStatusHistoryEntity> TripStatusHistory { get; set; }
    public DbSet<TripsEntity> Trips { get; set; }*/
    public DbSet<TypeDocumentsEntity> TypeDocuments { get; set; }
    
    public DbSet<TypeLoadEntity> TypeLoad { get; set; }
    
    public DbSet<TypeVehiclesEntity> TypeVehicles { get; set; }
    
    public DbSet<VehiclesEntity> Vehicles { get; set; }
    
    public DbSet<VehiculesStatusEntity> VehiculesStatus { get; set; }
    
}