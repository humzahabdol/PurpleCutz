IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Schedules] (
    [ScheduleId] int NOT NULL IDENTITY,
    [BarberId] int NOT NULL,
    [Start_Time] datetime2 NOT NULL,
    [End_Time] datetime2 NOT NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY ([ScheduleId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190402204547_PurpleCutz', N'2.1.8-servicing-32085');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Schedules]') AND [c].[name] = N'BarberId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Schedules] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Schedules] DROP COLUMN [BarberId];

GO

CREATE TABLE [Appointments] (
    [AppointmentId] int NOT NULL IDENTITY,
    [Date_Created] datetime2 NOT NULL,
    [ClientId] int NOT NULL,
    [BarberId] int NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [PhoneNumber] int NOT NULL,
    [Start_Time] datetime2 NOT NULL,
    [End_Time_Expected] datetime2 NOT NULL,
    [End_Time] datetime2 NOT NULL,
    [Price] int NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY ([AppointmentId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190404184436_PurpleCutzDbDatabaseDesign', N'2.1.8-servicing-32085');

GO

