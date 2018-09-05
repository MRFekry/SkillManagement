CREATE TABLE [dbo].[Users] (
    [Id]           BIGINT         NOT NULL,
    [UserName]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [IsAdmin]      BIT            NOT NULL,
    [Employee_Id]  BIGINT         NOT NULL,
    [CreatedBy]    NVARCHAR (50)  NULL,
    [DateCreated]  DATETIME       NOT NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [DateModified] DATETIME       NULL
);

