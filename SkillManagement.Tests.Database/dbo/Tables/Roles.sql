CREATE TABLE [dbo].[Roles] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [CreatedBy]    NVARCHAR (50)  NULL,
    [DateCreated]  DATETIME       NOT NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [DateModified] DATETIME       NULL
);

