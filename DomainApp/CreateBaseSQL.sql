CREATE TABLE [dbo].[UserRole]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Role] NVARCHAR (30) NOT NULL
)

CREATE TABLE [dbo].[User] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (50)  NOT NULL,
    [Psw]      NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (50)  NOT NULL,
    [Fullname] NVARCHAR (100) NOT NULL,
    [RoleId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_User_UserRole_Id] FOREIGN KEY ([RoleId]) REFERENCES [UserRole]([Id])
);

CREATE TABLE [dbo].[StatusIssue]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Status] NVARCHAR (50) not null
)

CREATE TABLE [dbo].[TypeIssue]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Type] NVARCHAR (50) not null
) 

Insert into UserRole(Id, Role) values
(1, 'User'),
(2, 'Developer'),
(3, 'Administrator');

Insert into StatusIssue(Id, Status) values
(1, 'Open'),
(2, 'In-progress'),
(3, 'Resolved'),
(4, 'Closed'),
(5, 'Reopened');

Insert into TypeIssue(Id, Type) values
(1, 'Task'),
(2, 'Bug'),
(3, 'New functional');

CREATE TABLE [dbo].[Project] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [ProjectLeadId] INT            NOT NULL,
    [Description]   NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Project_User_Id] FOREIGN KEY ([ProjectLeadId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[ProjVersion] (
    [IdVersion] INT           IDENTITY (1, 1) NOT NULL,
    [Version]   NVARCHAR (50) NOT NULL,
    [ProjectId] INT           NOT NULL,
    [Release]   BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdVersion] ASC),
	CONSTRAINT [FK_ProjVersion_Project_Id] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id])
);


CREATE TABLE [dbo].[Component] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [Description]     NVARCHAR (200) NULL,
    [ComponentLeadId] INT            NOT NULL,
	[ProjectId]     INT not null,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Component_Project_Id] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
	CONSTRAINT [FK_Component_User_Id] FOREIGN KEY ([ComponentLeadId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[Issue] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    [TypeIssueId] INT            NOT NULL,
    [StatusId]    INT            NOT NULL,
    [ReporterId]  INT            NOT NULL,
	[ComponentId] int not null,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Issue_StatusIssue_Id] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[StatusIssue] ([Id]),
	CONSTRAINT [FK_Issue_TypeIssue_Id] FOREIGN KEY ([TypeIssueId]) REFERENCES [dbo].[TypeIssue] ([Id]),
	CONSTRAINT [FK_Issue_User_Id] FOREIGN KEY ([ReporterId]) REFERENCES [dbo].[User] ([Id]),
	CONSTRAINT [FK_Issue_Component_Id] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[Component] ([Id])

);

CREATE TABLE [dbo].[DetailIssue] (
    [IssueId]         INT            NOT NULL,
    [UserId]          INT            NOT NULL,
    [DescriptionWork] NVARCHAR (200) NOT NULL,
    [TimeIn]          SMALLDATETIME  NOT NULL,
    [TimeOut]         SMALLDATETIME  NOT NULL,
    [NewVersion]      BIT            NOT NULL,
    CONSTRAINT [FK_DetailIssue_Issue_Id] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issue] ([Id]),
    CONSTRAINT [FK_DetailIssue_User_Id] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]), 
    CONSTRAINT [PK_DetailIssue] PRIMARY KEY ([IssueId])
);

