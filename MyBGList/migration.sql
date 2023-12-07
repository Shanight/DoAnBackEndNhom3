IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BoardGames] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [Year] int NOT NULL,
    [MinPlayers] int NOT NULL,
    [MaxPlayers] int NOT NULL,
    [PlayTime] int NOT NULL,
    [MinAge] int NOT NULL,
    [UsersRated] int NOT NULL,
    [RatingAverage] decimal(4,2) NOT NULL,
    [BGGRank] int NOT NULL,
    [ComplexityAverage] decimal(4,2) NOT NULL,
    [OwnedUsers] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_BoardGames] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Domains] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Domains] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Mechanics] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Mechanics] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BoardGames_Domains] (
    [BoardGameId] int NOT NULL,
    [DomainId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_BoardGames_Domains] PRIMARY KEY ([BoardGameId], [DomainId]),
    CONSTRAINT [FK_BoardGames_Domains_BoardGames_BoardGameId] FOREIGN KEY ([BoardGameId]) REFERENCES [BoardGames] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BoardGames_Domains_Domains_DomainId] FOREIGN KEY ([DomainId]) REFERENCES [Domains] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [BoardGames_Mechanics] (
    [BoardGameId] int NOT NULL,
    [MechanicId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_BoardGames_Mechanics] PRIMARY KEY ([BoardGameId], [MechanicId]),
    CONSTRAINT [FK_BoardGames_Mechanics_BoardGames_BoardGameId] FOREIGN KEY ([BoardGameId]) REFERENCES [BoardGames] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BoardGames_Mechanics_Mechanics_MechanicId] FOREIGN KEY ([MechanicId]) REFERENCES [Mechanics] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BoardGames_Domains_DomainId] ON [BoardGames_Domains] ([DomainId]);
GO

CREATE INDEX [IX_BoardGames_Mechanics_MechanicId] ON [BoardGames_Mechanics] ([MechanicId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231207092036_Initial', N'7.0.13');
GO

COMMIT;
GO

