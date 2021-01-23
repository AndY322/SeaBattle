create table AspNetRoles (
  Id uniqueidentifier not null,
  Name nvarchar(256),
  NormalizedName nvarchar(256),
  ConcurrencyStamp nvarchar(1024),
  constraint pk_AspNetRoles primary key (id)
)
go

-- auto-generated definition
create table AspNetRoleClaims (
  Id int identity,
  RoleId uniqueidentifier not null,
  ClaimType nvarchar(1024),
  ClaimValue nvarchar(1024),
  constraint pk_AspNetRoleClaims primary key (Id),
  constraint fk_AspNetRoleClaims_AspNetRoles
    foreign key (RoleId) references AspNetRoles (Id)
    on delete cascade
    on update cascade
)
go

-- auto-generated definition
create table AspNetUsers (
  Id uniqueidentifier not null,
  UserName nvarchar(256) not null unique,
  NormalizedUserName nvarchar(256) not null unique,
  Email nvarchar(256) not null unique,
  NormalizedEmail nvarchar(256) not null unique,
  EmailConfirmed bit not null,
  PasswordHash nvarchar(1024),
  SecurityStamp nvarchar(1024),
  ConcurrencyStamp nvarchar(1024),
  PhoneNumber nvarchar(1024),
  PhoneNumberConfirmed bit not null,
  TwoFactorEnabled bit not null,
  LockoutEnd datetimeoffset,
  LockoutEnabled bit not null,
  AccessFailedCount int not null,
  constraint pk_AspNetUsers primary key (Id)
)
go

-- auto-generated definition
create table AspNetUserClaims (
  Id int identity,
  UserId uniqueidentifier not null,
  ClaimType nvarchar(1024),
  ClaimValue nvarchar(1024),
  constraint pk_AspNetUserClaims primary key (Id),
  constraint fk_AspNetUserClaims_AspNetUsers
    foreign key (UserId) references AspNetUsers (Id)
    on delete cascade
    on update cascade
)
go

-- auto-generated definition
create table AspNetUserLogins (
  LoginProvider nvarchar(128) not null,
  ProviderKey nvarchar(128) not null,
  ProviderDisplayName nvarchar(1024),
  UserId uniqueidentifier not null,
  constraint pk_AspNetUserLogins primary key (LoginProvider, ProviderKey),
  constraint fk_AspNetUserLogins_AspNetUsers
    foreign key (UserId) references AspNetUsers (Id)
    on delete cascade
    on update cascade
)
go

-- auto-generated definition
create table AspNetUserRoles (
  UserId uniqueidentifier not null,
  RoleId uniqueidentifier not null,
  constraint pk_AspNetUserRoles primary key (UserId, RoleId),
  constraint fk_AspNetUserRoles_AspNetUsers
    foreign key (UserId) references AspNetUsers (Id)
    on delete cascade
    on update cascade,
  constraint fk_AspNetUserRoles_AspNetRoles
    foreign key (RoleId) references AspNetRoles (Id)
    on delete cascade
    on update cascade
)
go

-- auto-generated definition
create table AspNetUserTokens (
  UserId uniqueidentifier not null,
  LoginProvider nvarchar(128) not null,
  Name nvarchar(128) not null,
  Value nvarchar(1024),
  constraint pk_AspNetUserTokens primary key (UserId, LoginProvider, Name),
  constraint fk_AspNetUserTokens_AspNetUsers
    foreign key (UserId) references AspNetUsers
    on delete cascade
    on update cascade
)
go