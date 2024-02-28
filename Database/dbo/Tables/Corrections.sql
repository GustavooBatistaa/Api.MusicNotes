CREATE TABLE [dbo].[Corrections] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [OccurrenceDate] DATETIME2 (7) NOT NULL,
    [HymnId]         INT           NOT NULL,
    [ReasonId]       INT           NOT NULL,
    [Priority]       INT           NOT NULL,
    [Rehearsed]      BIT           NOT NULL,
    [GroupId]        INT           NOT NULL,
    [EventId]        INT           NOT NULL,
    CONSTRAINT [PK_Corrections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Corrections_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Corrections_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Corrections_Hymns_HymnId] FOREIGN KEY ([HymnId]) REFERENCES [dbo].[Hymns] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Corrections_Reasons_ReasonId] FOREIGN KEY ([ReasonId]) REFERENCES [dbo].[Reasons] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Corrections_EventId]
    ON [dbo].[Corrections]([EventId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Corrections_GroupId]
    ON [dbo].[Corrections]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Corrections_HymnId]
    ON [dbo].[Corrections]([HymnId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Corrections_ReasonId]
    ON [dbo].[Corrections]([ReasonId] ASC);

