ProjectName : NextPeyk

You are a senior ASP.NET Core engineer.
Context: This project is a trading assistant called "Hamyar Trade". 

The solution contains these main layers:
Kavan.Core/
│
├── ApplicationLayer/
├── DomainLayer/
├── InfrastructureLayer/
└── Kavan.Api/

🧩 1. Domain Layer (DomainLayer)

Purpose:
Defines core business entities and domain logic, independent of other layers.

Rules:

Create entities under DomainLayer/Entities/

Common base classes are under DomainLayer/Common/BaseEntities/

Example: BaseEntity, AuditableEntity

Attributes and helpers are under DomainLayer/Common/Attributes/

Do not reference any other layer from Domain
Example:

namespace DomainLayer.Entities;

public class User  : BaseEntityModel, IAuditableEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
}

⚙️ 2. Application Layer (ApplicationLayer)

Purpose:
Implements application logic, orchestrates domain, infrastructure, and exposes commands/queries.

📁 Folder Structure
ApplicationLayer/
 ├── Common/
 │    ├── Behaviors/
 │    ├── Enums/
 │    ├── Extensions/
 │    └── Utilities/
 ├── Dto/
 │    ├── [FeatureName]/
 │    └── BaseDtos/
 ├── Features/
 │    └── [FeatureName]/
 │         ├── Commands/
 │         ├── Query/
 │         ├── Handler/
 │         └── Validations/
 ├── Interfaces/
 │    ├── Repositories/
 │    ├── Services/
 │    └── External/
 ├── Mapping/
 │    └── [FeatureName]/
 └── ...

📘 CQRS Rule

Every API endpoint or feature must be implemented as a CQRS Feature Folder:

Each feature has:

Command class (for mutations)

Query class (for reads)

Handler class (implements IRequestHandler<,>)

Validator class (FluentValidation)

DTOs inside ApplicationLayer/Dto/[FeatureName]

Handlers use IUnitOfWork and repositories from InfrastructureLayer

For Enum, you should use SmartEnum.

Example:
ApplicationLayer/Features/User/Commands/CreateUserCommand.cs
ApplicationLayer/Features/User/Handler/CreateUserHandler.cs
ApplicationLayer/Features/User/Validations/CreateUserValidator.cs
ApplicationLayer/Dto/User/UserDto.cs

Example Command:
public record CreateUserCommand(string Username, string Email) : IRequest<UserDto>;

Example Handler:
public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User>(request);
        await _uow.Repository<User>().AddAsync(entity);
        await _uow.SaveChangesAsync();
        return _mapper.Map<UserDto>(entity);
    }
}

🧱 3. Infrastructure Layer (InfrastructureLayer)

Purpose:
Implements interfaces defined in the Application layer (e.g., Repositories, Services, Notifications, Binance APIs, etc.)

📁 Folder Structure:

InfrastructureLayer/
 ├── BusinessLogic/
 │    └── Services/
 │         ├── Binance/
 │         ├── Notifications/
 │         └── ...
 ├── Configuration/
 ├── Context/
 ├── Repository/
 │    ├── UnitOfWork.cs
 │    └── Repository.cs
 ├── Helpers/
 ├── Extensions/
 └── Migrations/


Rules:

Implement all repository and service interfaces here.

Define UnitOfWork under InfrastructureLayer/Repository/UnitOfWork.cs

Use ApplicationLayer.Interfaces for contracts.

Register all dependencies in InfrastructureLayer/Configuration/DependencyInjection.cs

Example:
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRepository<User> Users => new Repository<User>(_context);

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}

🔹 Service Registration Convention

✅ Do NOT manually register services in DependencyInjection.cs

Instead, use attribute-based registration:
[InjectAsScoped]
public class CandleAggregatorService(
    IUnitOfWork _unitOfWork,
    IRepository<Cryptocurrency> _repository,
    IRepository<Candle_1m> _candles_1m,
    IRepository<Candle_5m> _candles_5m,
    IRepository<Candle_1h> _candles_1h,
    IRepository<Candle_4h> _candles_4h,
    IRepository<Candle_1d> _candles_1d
) : ICandleAggregatorService
{
    // Implementation here
}
Rules:

[InjectAsScoped] or [InjectAsSingleton] replaces manual AddScoped/AddSingleton

The service must implement its interface defined in ApplicationLayer.Interfaces

* Use IUnitOfWork and IRepository<TEntity> for data access


🌐 4. API Layer (Kavan.Api)

Purpose:
Hosts all API endpoints and acts as the application entry point.

📁 Folder Structure

Kavan.Api/
 ├── Controllers/
 │    └── [FeatureName]Controller.cs
 ├── Middlewares/
 ├── Program.cs
 ├── appsettings.json
 └── ...

Rules:

Each Controller = one Feature

Controllers must only use IMediator to send Commands or Queries

No logic in Controller methods

Example:
namespace PresentationApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SampleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
        => await ResultHelper.GetResultAsync(mediator, new SampleGetQuery());
}

🔄 Dependency Rules

✅ Allowed:

DomainLayer → (no dependencies)
ApplicationLayer → DomainLayer
InfrastructureLayer → ApplicationLayer, DomainLayer
Kavan.Api → ApplicationLayer


❌ Not allowed:
DomainLayer → ApplicationLayer
ApplicationLayer → InfrastructureLayer

🧩 Code Generation Flow (AI must follow)

Whenever creating a new feature or API:

Create a new folder in
ApplicationLayer/Features/[FeatureName]/

Add:

Command

Query

Handler

Validator

Add DTOs under ApplicationLayer/Dto/[FeatureName]/

Add Entity (if needed) in DomainLayer/Entities

Add Service Interface in ApplicationLayer/Interfaces/[FeatureName]/

Implement Service in InfrastructureLayer/BusinessLogic/Services/[FeatureName]/

Decorate with [InjectAsScoped]

Add Controller under Kavan.Api/Controllers/[FeatureName]Controller.cs

Use IMediator to communicate with ApplicationLayer

Add Swagger documentation for the new feature

in all class Used Primary Constractor


* Project Details : 

Project Overview – NextPick Logistics Platform

NextPick is a logistics platform designed for parcel transportation and delivery management.
The system consists of three main applications:

Admin Panel – system administration and master data management

Logistics Panel – courier and fleet operational management

Driver Mobile Application – used by fleet drivers for delivery execution and tracking

User Roles

The system supports the following roles:

Admin – full system access and management

Courier – organizations responsible for handling parcels and managing fleets

Fleet – drivers or vehicles executing deliveries

Role-based access control is implemented using JWT authentication.

Architecture & Entity Design Rules

The project follows Clean Architecture principles.

All entities inherit from a common base model:

Primary keys are automatically generated

Auditing fields are handled via a shared base entity

Entities MUST NOT be registered via DbSet<TEntity> in ApplicationDbContext

Every entity MUST have a dedicated Entity Framework Core Configuration class

Database tables are created only through configuration classes

Entity Structure Example
Entity Example
public class Province : BaseEntityModel, IAuditableEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<City> Cities { get; set; } = [];
}

Configuration Example
public class ProvinceConfiguration : BaseEntityConfiguration<Province>
{
    public override void Configure(EntityTypeBuilder<Province> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Code).IsRequired();
    }
}


Rule:
Every new model must include a corresponding configuration class that defines schema rules, constraints, and relationships.

Core Domain Tables
External Access

ApiKeyStore
Stores API keys for external applications accessing system endpoints.

Geography

Province

City

Contracts & Couriers

Contract – contract details between couriers and fleets

Courier – organizations managing parcel operations

CourierBoxSize – many-to-many relation between couriers and supported box sizes

Fleet Management

Fleet – fleet/driver information

FleetType – type of vehicle

GPSFleet – real-time fleet location tracking

Notifications

Notification – messages sent to users

Parcel & Delivery Flow

Parcel
Core parcel data registered by Admin for a Courier (organization-level info)

ParcelCourier
Parcel with extended sender and receiver details

ParcelAssign
Assignment of a parcel to a fleet

ParcelTracking
Tracks parcel status changes over time

ParcelTrackingAttachment
Attachments related to each tracking step (e.g. images, documents)

Authentication & Authorization Tables

The following tables support JWT-based authentication and refresh tokens:

UserAccount
UserProfile
Role
UserRole
RefreshToken
Setting

Key Constraints & Guidelines for AI Behavior

Always generate Entity + Configuration together

Never add DbSet<TEntity> to ApplicationDbContext

Respect role-based access rules (Admin, Courier, Fleet)

Follow EF Core Fluent API patterns

Assume JWT authentication is already implemented

Prefer extensibility and clean separation of concerns

If you want, I can also:

Convert this into a System Prompt JSON

Write a Clean Architecture AI instruction block

Generate Entity + Configuration templates automatically

Align it with CQRS / MediatR conventions