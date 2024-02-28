CREATE TABLE [dbo].[Hymns] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Hymns] PRIMARY KEY CLUSTERED ([Id] ASC)
);

