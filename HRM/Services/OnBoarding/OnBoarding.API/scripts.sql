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

CREATE TABLE [Employee] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NOT NULL,
    [Email] nvarchar(2048) NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    [EmployeeStatusId] int NOT NULL,
    [EndDate] datetime2 NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [HireDate] datetime2 NULL,
    [LastName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [SSN] nvarchar(2048) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [JobStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeStatusCode] nvarchar(64) NOT NULL,
    [EmployeeStatusDescription] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_JobStatusLookUps] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516090657_OnBoardingMigration', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [JobStatusLookUps] DROP CONSTRAINT [PK_JobStatusLookUps];
GO

ALTER TABLE [Employee] DROP CONSTRAINT [PK_Employee];
GO

EXEC sp_rename N'[JobStatusLookUps]', N'EmployeeStatusLookUps';
GO

EXEC sp_rename N'[Employee]', N'Employees';
GO

ALTER TABLE [EmployeeStatusLookUps] ADD CONSTRAINT [PK_EmployeeStatusLookUps] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Employees] ADD CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516091334_OnBoardingMigrationEdited', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230520030127_AddOnBoardingMigration', N'7.0.5');
GO

COMMIT;
GO

