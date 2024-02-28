CREATE TABLE Organists (
    Id INT PRIMARY KEY Identity (1,1),
    Name NVARCHAR(50),
    CongregationId INT,
    Situation INT,
    Christening BIT,
    MaritalStatus INT,
    CONSTRAINT FK_OrganistModel_Congregations FOREIGN KEY (CongregationId) REFERENCES Congregations(Id));