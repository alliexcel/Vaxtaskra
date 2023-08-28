CREATE TABLE [dbo].[Vaxtafotur_interests]
(
	[Vaxtafotur_interestsID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VaxtafoturId] INT NOT NULL, 
    [Interest] DECIMAL(18, 2) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Is_Current] INT NOT NULL, 
    CONSTRAINT [FK_Vaxtafotur_interests_Vaxtafotur] FOREIGN KEY (VaxtafoturID) REFERENCES Vaxtafotur(VaxtafoturID)
)
