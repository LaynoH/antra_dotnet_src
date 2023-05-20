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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [JobCode] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NULL,
    [IsActive] bit NULL,
    [NumberOfPositions] int NOT NULL,
    [ClosedOn] datetime2 NULL,
    [ClosedReason] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512142741_InitialMigration', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Title] nvarchar(80) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Description] nvarchar(2048) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'ClosedReason');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [ClosedReason] nvarchar(1024) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512144837_UpdatingJobsTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidates] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(512) NOT NULL,
    [ResumeURL] nvarchar(2048) NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512151141_CreatingCandidateTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Jobs] ADD [JobStatusLookUpId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [JobStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [JobStatusCode] nvarchar(max) NOT NULL,
    [JobStatusDescription] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_JobStatusLookUps] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Jobs_JobStatusLookUpId] ON [Jobs] ([JobStatusLookUpId]);
GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_JobStatusLookUps_JobStatusLookUpId] FOREIGN KEY ([JobStatusLookUpId]) REFERENCES [JobStatusLookUps] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512152142_JobStatusLookUpTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Submissions] (
    [Id] int NOT NULL IDENTITY,
    [JobId] int NOT NULL,
    [CandidateId] int NOT NULL,
    [SubmittedOn] datetime2 NULL,
    [SelectedForInterview] datetime2 NULL,
    [RejectedOn] datetime2 NULL,
    [RejectedReason] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submissions_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Submissions_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Submissions_CandidateId] ON [Submissions] ([CandidateId]);
GO

CREATE INDEX [IX_Submissions_JobId] ON [Submissions] ([JobId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512153813_SubmissionsTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'FirstName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;
GO

ALTER TABLE [Candidates] ADD [CreatedOn] datetime2 NOT NULL DEFAULT (getdate());
GO

CREATE UNIQUE INDEX [IX_Candidates_Email] ON [Candidates] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512160014_UpdatingCandidateTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Candidates] ADD [CandidateIdentityId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517152326_CandidateMigration', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Candidates_Email] ON [Candidates];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517153632_UpdateCandidateMigration', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Submissions]') AND [c].[name] = N'RejectedReason');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Submissions] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Submissions] ALTER COLUMN [RejectedReason] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517161507_UpdateCandidateMigrationAgain', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517162903_UpdateCandidateMigrationAgain2', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517163257_UpdateCandidateMigrationAgain3', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'CandidateIdentityId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Candidates] DROP COLUMN [CandidateIdentityId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517164021_UpdateCandidateMigrationAgain4', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517171557_UpdateCandidateMigrationAgain5', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517191649_UpdateCandidateMigrationAgain6', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517191819_UpdateCandidateMigrationAgain7', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517193344_UpdateCandidateMigrationAgain8', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517203647_CandidateMigrationRedo', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Submissions] DROP CONSTRAINT [FK_Submissions_Candidates_CandidateId];
GO

ALTER TABLE [Submissions] DROP CONSTRAINT [FK_Submissions_Jobs_JobId];
GO

DROP INDEX [IX_Submissions_CandidateId] ON [Submissions];
GO

DROP INDEX [IX_Submissions_JobId] ON [Submissions];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517205129_CandidateMigrationRedo1', N'7.0.5');
GO

COMMIT;
GO

