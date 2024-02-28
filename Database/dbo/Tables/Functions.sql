CREATE TABLE [dbo].[Functions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

