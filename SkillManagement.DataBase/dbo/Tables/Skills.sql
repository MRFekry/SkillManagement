CREATE TABLE [dbo].[Skills] (
    [Id]               INT            NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [SkillCategory_Id] INT            NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([Id] ASC)
);

