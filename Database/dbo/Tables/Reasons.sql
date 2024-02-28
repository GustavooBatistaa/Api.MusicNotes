CREATE TABLE [dbo].[Reasons] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Reasons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

