CREATE TABLE Activitys (
    Id INT PRIMARY KEY Identity (1,1),
    EventId INT,
    CongregationId INT,
    OrganistId INT,
    Accomplish INT,
    Date DATETIME,
    CONSTRAINT FK_Activitys_Events FOREIGN KEY (EventId) REFERENCES Events(Id),
    CONSTRAINT FK_Activitys_Congregations FOREIGN KEY (CongregationId) REFERENCES Congregations(Id),
    CONSTRAINT FK_Activitys_Organists FOREIGN KEY (OrganistId) REFERENCES Organists(Id)
);