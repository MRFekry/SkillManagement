CREATE TABLE [dbo].[Skills] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (MAX) NOT NULL,
    [SkillParentCategory_Id] INT            NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([Id] ASC)
);



