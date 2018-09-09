CREATE TABLE [dbo].[Employees] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [CreatedBy]    NVARCHAR (50)  CONSTRAINT [DF_Employees_CreatedBy] DEFAULT (N'System') NOT NULL,
    [DateCreated]  DATETIME       CONSTRAINT [DF_Employees_DateCreated] DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [DateModified] DATETIME       NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);





