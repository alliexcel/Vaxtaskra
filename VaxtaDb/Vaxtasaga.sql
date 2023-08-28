CREATE TABLE [dbo].[Vaxtasaga]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VaxtarunaID] INT NOT NULL, 
    [VaxtafoturID] INT NOT NULL, 
    [Spread] DECIMAL(18, 2) NOT NULL, 
    [Vaxtafotur] DECIMAL(18, 2) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [VextirTotal] DECIMAL(18, 2) NOT NULL
)
