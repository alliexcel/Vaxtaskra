CREATE TABLE [dbo].[Vaxtaruna_interests]
(
	[Vaxtaruna_InterestsID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Spread] DECIMAL(18, 2) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [VaxtarunaID] INT NOT NULL, 
    [is_current] INT NULL, 
    CONSTRAINT [FK_Vaxtaruna_interests_Vaxtaruna] FOREIGN KEY (VaxtarunaID) REFERENCES Vaxtaruna(VaxtarunaID)
)
