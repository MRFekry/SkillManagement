CREATE TABLE [dbo].[Employees] (
    [Id]           BIGINT         NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [CreatedBy]    NVARCHAR (50)  NULL,
    [DateCreated]  DATETIME       NOT NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [DateModified] DATETIME       NULL
);

