CREATE TABLE [dbo].[Employees_Skills] (
    [Id]          BIGINT IDENTITY (1, 1) NOT NULL,
    [Employee_Id] BIGINT NOT NULL,
    [Skill_Id]    INT    NOT NULL,
    [Score_Id]    INT    NOT NULL,
    CONSTRAINT [PK_Employees_Skills] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employees_Skills_Employees] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employees] ([Id]),
    CONSTRAINT [FK_Employees_Skills_Scores] FOREIGN KEY ([Score_Id]) REFERENCES [dbo].[Scores] ([Id]),
    CONSTRAINT [FK_Employees_Skills_Skills] FOREIGN KEY ([Skill_Id]) REFERENCES [dbo].[Skills] ([Id]),
    CONSTRAINT [UNIQUE_Table] UNIQUE NONCLUSTERED ([Employee_Id] ASC, [Skill_Id] ASC, [Score_Id] ASC)
);



