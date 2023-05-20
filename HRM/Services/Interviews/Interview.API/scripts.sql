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

CREATE TABLE [Interview] (
    [Id] int NOT NULL IDENTITY,
    [BeginTime] datetime2 NOT NULL,
    [CandidateEmail] nvarchar(max) NOT NULL,
    [CandidateFirstName] nvarchar(50) NOT NULL,
    [CandidateIdentityId] uniqueidentifier NOT NULL,
    [CandidateLastName] nvarchar(50) NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [Feedback] nvarchar(max) NOT NULL,
    [InterviewerId] int NOT NULL,
    [InterviewTypeId] int NOT NULL,
    [Passed] bit NULL,
    [Rating] int NULL,
    [SubmissionId] int NOT NULL,
    CONSTRAINT [PK_Interview] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Interviewer] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Interviewer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [JobStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [InterviewTypeCode] nvarchar(50) NOT NULL,
    [InterviewTypeDescription] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_JobStatusLookUps] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517022841_AddInterviewMigration', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [JobStatusLookUps] DROP CONSTRAINT [PK_JobStatusLookUps];
GO

EXEC sp_rename N'[JobStatusLookUps]', N'InterviewStatusLookUps';
GO

ALTER TABLE [InterviewStatusLookUps] ADD CONSTRAINT [PK_InterviewStatusLookUps] PRIMARY KEY ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517031954_UpdateInterviewMigration', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517151744_UpdateCandidateMigration', N'7.0.4');
GO

COMMIT;
GO

